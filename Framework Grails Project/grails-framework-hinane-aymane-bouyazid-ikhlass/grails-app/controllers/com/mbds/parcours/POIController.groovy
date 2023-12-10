package com.mbds.parcours

import grails.plugin.springsecurity.annotation.Secured
import grails.validation.ValidationException
import static org.springframework.http.HttpStatus.*

@Secured(['ROLE_ADMIN','ROLE_USER'])
class POIController {

    POIService POIService
    ParcoursService parcoursService

    static allowedMethods = [save: "POST", update: "PUT", delete: "DELETE"]

    def index(Integer max) {
        params.max = Math.min(max ?: 10, 100)
        respond POIService.list(params), model:[POICount: POIService.count()]
    }

    def show(Long id) {
        respond POIService.get(id)
    }

    def create() {
        respond new POI(params)
    }

    def save(POI POI) {


        print params

        try {

            POIService.save(POI)


        } catch (ValidationException e) {
            respond POI.errors, view: 'create'
            return
        }


        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.created.message', args: [message(code: 'POI.label', default: 'POI'), POI.id])
                redirect POI
            }
            '*' { respond POI, [status: CREATED] }
        }
    }

    def edit(Long id) {
        respond POIService.get(id)
    }

    def update(POI POI) {

        if (POI == null) {
            notFound()
            return
        }

        def illustrationName = params.illustrationName
        def img =  request.getPart("illustrationImg")

        try {

            if(illustrationName && img) {
                def illustration = new Illustration(name: illustrationName)
                POI.illustrationList.add(illustration)
                POIService.save(POI)
                String fileName = "avatar_${illustration.id}.jpg"
               // String destinationDirectoryPath = "C:/Users/bouya/Downloads/IIR_5éme/MBDS/grails_23/grails-framework-hinane-aymane-bouyazid-ikhlass/grails-app/assets/images"
                String destinationDirectoryPath = grailsApplication.config.illustrations.path
                img.write("${destinationDirectoryPath}/${fileName}")

            }else{
                POIService.save(POI)
            }

            redirect(controller: 'parcours', action: 'index')
            return

        } catch (ValidationException e) {
            respond POI.errors, view:'edit'
            return
        }

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.updated.message', args: [message(code: 'POI.label', default: 'POI'), POI.id])
                redirect POI
            }
            '*'{ respond POI, [status: OK] }
        }
    }

    def delete(Long id) {
        if (id == null) {
            notFound()
            return
        }
        POI.get(id)?.delete(flush: true)
       // POIService.delete(id)

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.deleted.message', args: [message(code: 'POI.label', default: 'POI'), id])
                redirect action:"index", method:"GET"
            }
            '*'{ render status: NO_CONTENT }
        }
    }

    protected void notFound() {
        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.not.found.message', args: [message(code: 'POI.label', default: 'POI'), params.id])
                redirect action: "index", method: "GET"
            }
            '*'{ render status: NOT_FOUND }
        }
    }
}