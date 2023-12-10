package com.mbds.parcours

import grails.plugin.springsecurity.SpringSecurityService


import grails.plugin.springsecurity.annotation.Secured
import org.grails.core.io.ResourceLocator

import static org.springframework.http.HttpStatus.*

@Secured(['ROLE_ADMIN','ROLE_USER'])
class ParcoursController {

    ParcoursService parcoursService
    SpringSecurityService springSecurityService
    ResourceLocator grailsResourceLocator


    static allowedMethods = [save: "POST", update: "PUT", delete: "DELETE"]

    def index(Integer max) {
        params.max = Math.min(max ?: 10, 100)

        def isAdmin = true
        def roles = springSecurityService.getPrincipal().getAuthorities()

        if (roles.any { it.authority == 'ROLE_USER' }) {
            isAdmin = false
        }

        respond parcoursService.list(params), model: [parcoursCount: parcoursService.count(),isAdmin:isAdmin]
    }

    def indexUserParcours(Integer max) {

        def user = springSecurityService.currentUser
        def parcoursList = Parcours.findAllByAuthor(user)

        def isAdmin = false

        def roles = springSecurityService.getPrincipal().getAuthorities()

        if (roles.any { it.authority == 'ROLE_USER' }) {
            isAdmin = true
        }

        render(view: "index", model: [parcoursList: parcoursList, parcoursCount: parcoursList.size(),isAdmin:isAdmin])
    }


    def show(Long id) {
        respond parcoursService.get(id)
    }

    def create() {
        respond new Parcours(params)
    }


    def save(Parcours parcours){

        if(parcours==null){
            notFound()
            return
        }

        def illustrationName=params.illustrationName
        def img=request.getPart("illustrationImg")

        try{

            if(parcours.name && parcours.description && illustrationName && img){

                def illustration=new Illustration(name:illustrationName)

                parcours.illustrationList=[]
                parcours.illustrationList.add(illustration)

                if(springSecurityService.isLoggedIn()){
                    def user=springSecurityService.currentUser
                    if(user){

                        parcours.author=user

                        parcoursService.save(parcours)

                       // String destinationDirectoryPath = "C:/Users/bouya/Downloads/IIR_5éme/MBDS/grails_23/grails-framework-hinane-aymane-bouyazid-ikhlass/grails-app/assets/images"
                        String destinationDirectoryPath = grailsApplication.config.illustrations.path

//                        def destinationDirectoryPath = System.getProperty("user.dir")
//                        print destinationDirectoryPath



                        String fileName="avatar_${illustration.id}.jpg"

                        img.write("${destinationDirectoryPath}/${fileName}")

                        redirect(controller: 'parcours', action: 'index')
                        return
                    }
                }
            }
        }catch(ValidationExceptione){
            respond parcours.errors,view:'create'
            return
        }

        request.withFormat{
            form multipartForm{
                flash.message=message(code:'default.created.message',args:[message(code:'parcours.label',default:'Parcours'),parcours.id])
                redirect parcours
            }
            '*'{respond parcours,[status:CREATED]}
        }
    }

    def edit(Long id) {

        if (springSecurityService.isLoggedIn()) {
            def user = springSecurityService.currentUser
            if (user) {
                Long userId = user.id

                // Check if the user has the ROLE_ADMIN role
                if (user.authorities.any { it.authority == 'ROLE_ADMIN' }) {
                    // User has ROLE_ADMIN, so they can access directly
                    respond parcoursService.get(id)
                } else {
                    def parcours = parcoursService.get(id)

                    // Check if the user is associated with the parcours
                    if (user.parcoursList.contains(parcours) || UserParcours.findByUserAndParcours(User.get(userId),Parcours.get(id))) {
                        // The user has access to the parcours
                        respond parcours
                    } else {
                        // The user does not have access to the parcours
                        // Handle the case where the user doesn't have access, e.g., show an error message or redirect
                        render(status: 403, text: "You do not have access to this parcours")
                    }
                }
            }
        }
    }



    def update(Parcours parcours){
        if(parcours==null){
            notFound()
            return
        }

        def parcoursIllustrationName =  params.parcoursIllustrationName
        def parcoursIllustrationImg = request.getPart("parcoursIllustrationImg")

        def newModeratorName=params.moderateur


        def pointName = params.pointName
        def pointDescription = params.pointDescription
        def pointLongitude =  params.pointLongitude
        def pointLatitude =  params.pointLatitude
        def illustrationName = params.illustrationName
        def img =  request.getPart("illustrationImg")


        if (parcoursIllustrationName && parcoursIllustrationImg) {

            def illustration = new Illustration(name: parcoursIllustrationName)

            parcours.illustrationList.add(illustration)

            parcoursService.save(parcours)
           // String destinationDirectoryPath = "C:/Users/bouya/Downloads/IIR_5éme/MBDS/grails_23/grails-framework-hinane-aymane-bouyazid-ikhlass/grails-app/assets/images"
            String destinationDirectoryPath = grailsApplication.config.illustrations.path
//            def destinationDirectoryPath =System.getProperty("user.dir")
//            print destinationDirectoryPath

            String fileName="avatar_${illustration.id}.jpg"

            parcoursIllustrationImg.write("${destinationDirectoryPath}/${fileName}")

        }



        if(newModeratorName){

            def newModerator=User.findByUsername(newModeratorName)

            if(newModerator){

                def userParcours=new UserParcours(user:newModerator,parcours:parcours)
                userParcours.save()

            }
        }


        if (pointName && pointDescription && pointLongitude && pointLatitude && illustrationName && img) {

            def point = new POI(name:pointName,description: pointDescription,latitude: Float.parseFloat(pointLatitude),longitude: Float.parseFloat(pointLongitude));
            def illustration = new Illustration(name: illustrationName)

            if(point.illustrationList == null)
                point.illustrationList = []

            point.illustrationList.add(illustration)
            illustration.save()
            point.save()
            parcours.poiList.add(point)
            //  parcours.illustrationList.add(illustration)



            String fileName = "avatar_${illustration.id}.jpg"
          //  String destinationDirectoryPath = "C:/Users/bouya/Downloads/IIR_5éme/MBDS/grails_23/grails-framework-hinane-aymane-bouyazid-ikhlass/grails-app/assets/images"
            String destinationDirectoryPath = grailsApplication.config.illustrations.path

            img.write("${destinationDirectoryPath}/${fileName}")

        }


        try{
            parcoursService.save(parcours)

            redirect(controller: 'parcours', action: 'index')
            return

        }catch(ValidationExceptione){
            respond parcours.errors,view:'edit'
            return
        }

        request.withFormat {
            form multipartForm{
                flash.message=message(code:'default.updated.message',args:[message(code:'parcours.label',default:'Parcours'),parcours.id])
                redirect parcours
            }
            '*'{respond parcours,[status:OK]}
        }
    }







    def delete(Long id) {
        if (id == null) {
            notFound()
            return
        }

        parcoursService.delete(id)

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.deleted.message', args: [message(code: 'parcours.label', default: 'Parcours'), id])
                redirect action:"index", method:"GET"
            }
            '*'{ render status: NO_CONTENT }
        }
    }

    protected void notFound() {
        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.not.found.message', args: [message(code: 'parcours.label', default: 'Parcours'), params.id])
                redirect action: "index", method: "GET"
            }
            '*'{ render status: NOT_FOUND }
        }
    }
}