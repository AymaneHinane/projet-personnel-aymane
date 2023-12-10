#include <stdio.h>
#include <stdlib.h>
#include"c.c"
#include <windows.h>

int main()
{
   liste_Hopital *H;
   Hotel *h;
   Liste_quarantaine *Q;
   H=NULL;
   h=NULL;
   Q=NULL;
   int choix;


do{
   system("cls"); // pour effacer l'ecran
   printf("Menu\n----\n");
   printf("1.Gestion des hopitaux\n");
   printf("2.Gestion des salles\n");
   printf("3.Gestion des patients\n");
   printf("4.Gestion des personnes en quarantaine\n");
   printf("5.Gestion de la fille d'attente\n");
   printf("10.Quitter\n\n");
   scanf("%d",&choix);

   switch(choix)
   {
      case 1:
             do{
                system("cls");
                printf("1.ajouter un hopital \n");
                printf("2.afficher un hopital \n");
                printf("3.afficher la liste des hopitaux \n");
                printf("4.Modifier un hopital \n");
                printf("5.Quitte \n");
                scanf("%d",&choix);
                switch(choix)
                {
                    case 1://ajouter un hopital
                       H=ajouter_hopital(H);
                       break;
                    case 2://afficher hopitaux
                         afficher_hopital(H);
                       break;
                    case 3://afficher la listes des hopitaux
                        afficher_Hopitaux(H);
                       break;
                    case 4://Modifier un hopital
                        H=modifier_hopital(H);
                    break;
                    default:
                      break;
                }
                 system("pause");
             }while(choix != 5);
         break;

         case 2:
             do{
                system("cls");
                printf("1.ajouter une salle\n");
                printf("2.afficher la liste des salles d'un hopital\n");
                printf("3.Quitte \n");
                scanf("%d",&choix);
                switch(choix)
                {
                    case 1://ajouter une salle
                        H=ajouter_salle(H);
                       break;
                    case 2://afficher la listes des salles
                          afficher_salle(H);
                       break;
                    default:
                      break;
                }
                 system("pause");
             }while(choix != 3);
         break;

         case 3:
             do{
                system("cls");
                printf("1.ajouter un patient\n");
                printf("2.afficher un patient\n");
                printf("3.afficher la listes des patient d'un hopital\n");
                printf("4.modifier l'etat d'un patient\n");
                printf("5.supprimer un patient\n");
                printf("6.Quitte \n");
                scanf("%d",&choix);
                switch(choix)
                {
                    case 1://ajouter un patient
                            H=ajouter_patient(H);
                       break;
                    case 2://afficher un patient
                             afficher_patient(H);
                       break;
                    case 3://afficher listes des patient
                             afficher_liste_patient(H);
                       break;
                    case 4://modifier l'etat d'un patient
                            H=modifier_etat_patient(H);
                       break;
                    case 5://supprimer un patient
                             H=supprimer_patient(H);
                       break;
                    default:
                      break;
                }
                 system("pause");
             }while(choix != 6);
         break;

         case 4://Gestion des personnes en quarantaine
              do{
                system("cls");
                printf("1.ajouter un hotel\n");
                printf("2.afficher la liste des hotel \n");
                printf("3.ajouter une personne en quarantaine \n");
                printf("4.afficher la liste des personne en quarantaine \n");
                printf("5.affecter une personne en quarantaine a un hotel \n");
                printf("6.retirer une personne de la liste de quarantaine \n");
                printf("7.Quitte \n");
                scanf("%d",&choix);
                switch(choix)
                {
                    case 1://ajouter un hotel
                            h=ajouter_hotel(h);
                       break;
                    case 2://afficher la liste des hotel
                             afficher_liste_hotel(h);
                       break;
                    case 3:
                             Q=ajouter_personne_quarantaine(Q,H);
                    break;
                    case 4://afficher la liste des personnes en quarantaine
                          afficher_liste_quarantaine(Q);
                    break;

                    case 5://affecter une personne en quarantaine a un hotel
                          Q=affecter_citoyen(Q,h);
                    break;

                    case 6://retirer une personne de la liste de quarantaine
                        Q=supprimer_citoyen_quarantaine(Q,h);
                    break;

                    default:
                      break;
                }
                 system("pause");
             }while(choix !=7);
         break;

         case 5://Gestion de la file d'attente
              do{
                system("cls");
                printf("1.afficher la fille d'attente\n");
                printf("2.affecter une personne de cette file a un hopital\n");
                printf("5.Quitte \n");
                scanf("%d",&choix);
                switch(choix)
                {
                    case 1://afficher la file d'attente
                            afficher_file_attente(H);
                       break;
                    case 2://affecter une personne de cette file au un hopital
                            H=ajout_fille_attente(H);
                       break;
                    default:
                      break;
                }
                 system("pause");
             }while(choix !=5);
         break;



      default:
         break;
   }
   system("pause");

}while(choix !=10);

   system("pause");



    return 0;
}
