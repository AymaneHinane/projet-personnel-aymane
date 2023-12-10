package com.mbds.parcours

import grails.plugin.springsecurity.annotation.Secured
import grails.validation.ValidationException

import static org.springframework.http.HttpStatus.CREATED


@Secured(['permitAll'])
class RegistrationController {

    def springSecurityService

    UserService userService


//    def index() {
//        print "hello"
//    }

    def register() {

        print "hello"
        // This action should handle the registration form display.
    }

//    def create() {
//        print params
//        respond new User(params)
//    }

    def save() {
        def username = params.username
        def password = params.password
        def email = "${username}@parcours.com"

        // Create a new User instance
        def user = new User(username: username, password: password, email: email)

        // Save the user first
        user.save(flush: true)  // Use 'flush: true' to save the user immediately

        // Create a new Role instance (e.g., 'ROLE_USER')
        def role = Role.findByAuthority('ROLE_USER')
        print role

        def instance = new UserRole(user: user, role: role)
        instance.save(flush: true)

        redirect(controller: 'login')
    }



}
