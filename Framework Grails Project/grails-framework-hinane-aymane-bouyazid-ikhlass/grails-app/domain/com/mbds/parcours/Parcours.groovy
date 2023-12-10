package com.mbds.parcours

class Parcours {
    String name
    String description

    static belongsTo = [author: User]

    static hasMany = [poiList: POI, illustrationList: Illustration,userParcours: UserParcours]




    static constraints = {
        name blank: false, nullable: false
        description blank: false, nullable: false
        author nullable: false
    }

    static mapping = {
        description type: 'text'
        userParcours cascade: "all-delete-orphan"
    }

    static namedQueries = {
        findByAuthorId { authorId ->
            eq('author.id', authorId)
        }
    }
}