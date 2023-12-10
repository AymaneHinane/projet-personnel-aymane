# Objectifs du projet


Création d'une plateforme touristique qui permettra au utilisateur de créer des parcours touristiques.



# Les entités


User / parcours / Poi / Illustration / Role / UserParcours / UserRole




# Fonctionnalité de la palteforme



## Gestion des users

- création d'un user

- suppression d'un user


## Parcours

- création d'un parcours

- suppression d'un parcours

- modification d'un parcours

- ajout des illustrations à un parcours

- ajouter un nouveau modérateur à un poi existant



## Point

- créer un point

- assigner une illustration à un point

-assigner  un point à un parcours 



## securiter

- création d'un nouveau user sur la page sign up

- connect user

- vérifier l'identité du user

- appliquer des règles de securiter sur l'acces aux pages et interaction sur l'interface



## Parcours

- un parcours est un ensemble de poi représentant des lieu touristique a visiter

- chaque parcours a un auteur, et un ou plusieurs modérateur

- un parcours a plusieurs illustrations.

- les parcours sont visibles à tout le monde, mais les modifications sont uniquement réserver aux :
Autheur / modérateur / admin

- un parcours a plusieurs poi



## Poi

- c'est un lieu touristique et il est identifié par un titre, une description, une latitude et une

Longitude afin d'être capable de le placer sur une carte.

- un Poi a plusieurs illustrations.



## Illustration

- une illustration représente une image

- l'image en question est affecter soit à un parcours , soit à un poi

- une illustration d'un peut avoir plusieurs images

- l'id de l'image est stocker dans la table illustration

- l'image est stocker dans le fichier assets/images sous la forme: "avatar_${illustration.id}.jpg"



## Utilisateur

- un utilisateur peut être l'auteur de plusieurs parcours

- un utilisateur peut être le modérateur d'un parcours

- un user a un role: Role_Admin / Role_User



# Conclusion


Ce projet nous a permis d'obtenir des bases et connaissances techniques solides sur Groovy/Grails

Cette expérience que nous avions vécue durant 1 semaine, nous a fait acquérir de nouvelles compétences

Qui nous serons très utiles dans notre vie professionnelle.

Nous tenons à vous remercier monsieur, pour votre engagement et l'effort que vous aviez fourni dans ce

Cours, on vous souhaite une bonne continuation dans votre carrier d'enseignant. Merci à vous

# Video Presentation du projet 

https://drive.google.com/drive/folders/1s7hxQc0Ja6wnrjxVf45mU9NW-Nw_v-oQ?usp=drive_link