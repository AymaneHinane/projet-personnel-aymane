package mbds_emsi_23_24

class UrlMappings {

    static mappings = {
        "/$controller/$action?/$id?(.$format)?"{
            constraints {
                // apply constraints here
            }
        }

        "/userParcours"(controller: "parcours", action: "indexUserParcours") {
            constraints {
                // Define any constraints here (e.g., request methods)
            }
        }

        "/register"(controller: "registration", action: "register") {
            // Additional mappings or constraints if needed
        }


        "/" {
            controller = "parcours"
            action = "index"
        }
        "500"(view:'/error')
        "404"(view:'/notFound')
    }
}