#include"c.h"
#include <windows.h>
#include<string.h>



void date_systeme(Date *D)
{
    SYSTEMTIME Time;
    GetLocalTime(&Time);

      D->JJ=Time.wDay;
      D->MM=Time.wMonth;
      D->AAA=Time.wYear;


}


void creer_hopital(Hopital *P)
{

    static int id=1;
    P->NO_hopital=id;
    id++;
    printf("entrer le nom de l'hopitale \n");
    scanf("%s",&P->nom);
    P->adresse=malloc(sizeof(Adresse));
    printf("entrer l'adresse de l'hopitale \n");
    printf("la ville: \n");
    scanf("%s",&P->adresse->ville);
    printf("le cartier: \n");
    scanf("%s",&P->adresse->cartier);
    rewind(stdin);
    printf("le code postale: \n");
    scanf("%d",&P->adresse->code_postal);

    P->nbr_lit_dispo=0;
    P->nbr_lit_max=0;
    printf("entrer le nbr de salle total \n");
    scanf("%d",&P->nbr_salle_total);
    printf("entrer le nbr de salle disponible \n");
    scanf("%d",&P->nbr_salle_dispot);

    printf("entrer le nbr de medecin \n");
    scanf("%d",&P->nbr_medecin);
    printf("entrer le nbr de paramedicaux \n");
    scanf("%d",&P->nbr_paramedicaux);

}

liste_Hopital* ajouter_hopital(liste_Hopital *l)
{
    static int id=1;
    liste_Hopital *debut=malloc(sizeof(liste_Hopital));
    liste_Hopital *nouv=malloc(sizeof(liste_Hopital));
    liste_Hopital *r=l;
    Hopital *H=malloc(sizeof(Hopital));

    if(l ==NULL)
    {
        debut->prec=NULL;
        debut->suiv=NULL;
        creer_hopital(H);
        debut->Hopital=H;
        debut->Nbr_hopital=id;
        debut->Hopital->salles=NULL;
        debut->Hopital->Patients=NULL;
        debut->liste_file=NULL;
        id++;

        return debut;

    }else{

        while(r->suiv != NULL)
        {
            r=r->suiv;
        }
          nouv->suiv=NULL;
          nouv->prec=r;
          r->suiv=nouv;
          creer_hopital(H);
          nouv->Hopital=H;
          l->Nbr_hopital=id;
          nouv->Hopital->salles=NULL;
          nouv->Hopital->Patients=NULL;
          debut->liste_file=NULL;
          id++;
          return l;
        }
}

void creer_salle(Salle *L)
{

   static int id=1;

   L->NO_salle=id;
   id++;
   printf("entrer le besoin medicale de cette salle \n");
   scanf("%s",&L->salle_besoins);
   rewind(stdin);
   printf("entrer le nbr de lit disponible \n");
   scanf("%d",&L->nbr_lit_dipot);
   printf("entrer le nbr de lit max \n");
   scanf("%d",&L->nbr_lit_max);

}



liste_Hopital* ajouter_salle(liste_Hopital *H)
{

    liste_Hopital *r3=H;
    Liste_Salle *r1;
    Liste_Salle *nouv;
    char search;

    printf("entrer le nom ou bien le num de l'hopitale: \n");
    scanf("%s",&search);

     while(r3 !=NULL)
    {


        if(r3->Hopital->NO_hopital==search-'0' || strcmp(r3->Hopital->nom,&search)==0)
        {
              if(r3->Hopital->salles == NULL)
                {

                    r3->Hopital->salles=malloc(sizeof(Liste_Salle));
                    r3->Hopital->salles->salle=malloc(sizeof(Salle));
                    creer_salle(r3->Hopital->salles->salle);
                    r3->Hopital->nbr_lit_dispo=r3->Hopital->nbr_lit_dispo+r3->Hopital->salles->salle->nbr_lit_dipot;
                    r3->Hopital->nbr_lit_max=r3->Hopital->nbr_lit_max+r3->Hopital->salles->salle->nbr_lit_max;
                    r3->Hopital->salles->suiv=NULL;
                    r3->Hopital->salles->prec=NULL;
                    return H;
                }else{

                    r1=r3->Hopital->salles;
                    while(r1->suiv != NULL)
                    {
                        r1=r1->suiv;
                    }


                      nouv=malloc(sizeof(Liste_Salle));
                      nouv->salle=malloc(sizeof(Salle));
                      creer_salle(nouv->salle);
                      r1->suiv=nouv;
                      r3->Hopital->nbr_lit_dispo=r3->Hopital->nbr_lit_dispo+nouv->salle->nbr_lit_dipot;
                      r3->Hopital->nbr_lit_max=r3->Hopital->nbr_lit_max+nouv->salle->nbr_lit_max;
                      nouv->prec=r1;
                      nouv->suiv=NULL;

                  return H;
                }
        }

        r3=r3->suiv;
    }

    printf("accun hopital de se nom n'a etait trouver \n");

}


void creer_Patient(Patient *P)
{
    int i,j,choix;
    static int id=1;
    P->NO_patient=id;
    id++;
    printf("entrer le nom du patient: \n");
    scanf("%s",&P->nom);
    printf("entrer le prenom du patient: \n");
    scanf("%s",&P->prenom);

    P->adresse=malloc(sizeof(Patient));
    printf("entrer l'adresse du patient: \n");
    printf("la ville: \n");
    scanf("%s",&P->adresse->ville);
    printf("le cartier: \n");
    scanf("%s",&P->adresse->cartier);
    rewind(stdin);
    printf("le code postal: \n");
    scanf("%d",&P->adresse->code_postal);

    printf("entrer l'age du patient: \n");
    scanf("%d",&P->age);
    printf("entrer le nbr de maladie du patient: \n");
    scanf("%d",&P->nbr_maladies);
    rewind(stdin);
    P->maladies=malloc(P->nbr_maladies*sizeof(char*));

    for(i=0;i<P->nbr_maladies;i++)
    {
        P->maladies[i]=malloc(20*sizeof(char*));
        printf("entrer la maladie %d: \n",i+1);
        gets(P->maladies[i]);
    }
    printf("determiner l'etat du patient (1)normal,(2)critique : \n");
    scanf("%d",&choix);
    if(choix == 1)
    {
        strcpy(P->etat_patient,"normal");
    }else if(choix == 2){
        strcpy(P->etat_patient,"critique");
    }




}





liste_Hopital* historique(Hopital *H,Patient *P)
{
    Liste_historique *h;
    Liste_historique *nouv;

    if(H->liste_historique == NULL)
    {
        H->liste_historique=malloc(sizeof(Liste_historique));
        H->liste_historique->date=malloc(sizeof(Date));
        date_systeme(H->liste_historique->date);
        strcpy(H->liste_historique->nom,P->nom);
        strcpy(H->liste_historique->prenom,P->prenom);
        H->liste_historique->suiv=NULL;
        H->liste_historique->prec=NULL;
        return H;
    }else{
         h=H->liste_historique;

         while(h->suiv != NULL)
         {
             h=h->suiv;
         }

         nouv=malloc(sizeof(Liste_historique));

         nouv->date=malloc(sizeof(Date));
         date_systeme(nouv->date);
         h->suiv=nouv;
         nouv->suiv=NULL;
         nouv->prec=h;
         strcpy(nouv->nom,P->nom);
         strcpy(nouv->prenom,P->prenom);
         return H;
    }

}


liste_Hopital* ajouter_patient(liste_Hopital *H)
{

    liste_Hopital *r3=H;
    liste_patient *r1;
    liste_patient *nouv;
    Liste_historique *h;
    Liste_historique *aide;
    Hopital *hopital=malloc(sizeof(Hopital));
    int choix;
    char city;
    char cartier;
    int code_postal;
    char name;
    int trouver =0;
    /*************/
    liste_Hopital *r=H;
    Adresse *A;
    Patient *P;
    char HN[15];
    int aid=0;
    /*************/


       printf("----------------\n");
       printf("\nfaite un choix de recherche par:\n");
       printf("1.par nom d'hopital \n");
       printf("2.par adresse \n");
       printf("3.recherche automatique \n");
       printf("4.Quitte \n");
       scanf("%d",&choix);



     switch(choix)
       {
         case 1://nom
             printf("entrer le nom ou bien le num de l'hopitale: \n");
             scanf("%s",&name);
         break;

         case 2://adresse
             printf("entrer la ville: \n");
             scanf("%s",&city);
             printf("entrer le cartier: \n");
             scanf("%s",&cartier);
             rewind(stdin);
             printf("entrer le code postale: \n");
             scanf("%d",&code_postal);
         break;
          case 4:
              return H;
          break;

         default:
         break;
      };

      if(choix == 3)
      {
         if(H !=NULL)
                 {
                     P=malloc(sizeof(Patient));
                     creer_Patient(P);
                     while(r !=NULL)
                        {
                             A=r->Hopital->adresse;
                             if(strcmp(A->ville,P->adresse->ville)==0 ||strcmp(A->cartier,P->adresse->cartier)==0 || A->code_postal==P->adresse->code_postal)
                               {
                                  if(r->Hopital->nbr_lit_dispo >0)
                                     {
                                          strcpy(HN,r->Hopital->nom);
                                          aid =1;
                                     }else{
                                         printf("il n y'a plus de plase disponible dans l'hopital qui se situe dans votre region \n");
                                         return H;
                                     }

                              }

                             r=r->suiv;
                      }

                             printf("aucun Hopital n'a etait trouver !!! \n");


                 }else{
                    printf("la liste des Hopitaux est vide !!!! \n");
                    return H;
                 }
      }








     while(r3 !=NULL)
    {
         if(r3->Hopital->NO_hopital==name-'0' || strcmp(r3->Hopital->nom,&name)==0 || strcmp(r3->Hopital->adresse->ville,&city)==0 || strcmp(r3->Hopital->adresse->cartier,&cartier)==0 || r3->Hopital->adresse->code_postal == code_postal || strcmp(r3->Hopital->nom,hopital->nom)==0 || strcmp(r3->Hopital->nom,HN)==0)
        {
            printf("\nl'hopital %s a etait touver \n",r3->Hopital->nom);
            trouver=1;

            if(r3->Hopital->Patients == NULL)
            {
                 if(r3->Hopital->nbr_lit_dispo > 0)
                 {
                     r3->Hopital->Patients=malloc(sizeof(liste_patient));
                     r3->Hopital->Patients->patient=malloc(sizeof(Patient));
                     if(aid == 0)
                      {
                        creer_Patient(r3->Hopital->Patients->patient);
                      }else{
                        r3->Hopital->Patients->patient=P;
                      }
                    r3->Hopital->Patients->suiv=NULL;
                    r3->Hopital->Patients->prec=NULL;
                    r3->Hopital->Patients->patient->nom_hopital=r3->Hopital->nom;

                    r3->Hopital->nbr_lit_dispo-=1;
                 }else{
                    printf("nbr de lit insuffisant \n");
                    ajouter_file_attente(H);
                 }

                return H;
            }else{
                    if(r3->Hopital->nbr_lit_dispo > 0)
                      {
                        r1=r3->Hopital->Patients;

                       while(r1->suiv != NULL)
                        {
                          r1=r1->suiv;
                        }

                        nouv=malloc(sizeof(liste_patient));
                        nouv->patient=malloc(sizeof(Patient));
                        if(aid == 0)
                         {
                            creer_Patient(nouv->patient);
                         }else{
                         nouv->patient=P;
                         }
                        r1->suiv=nouv;
                        nouv->prec=r1;
                        nouv->suiv=NULL;
                        nouv->patient->nom_hopital=r3->Hopital->nom;

                        r3->Hopital->nbr_lit_dispo-=1;
                    }else{
                    printf("nbr de lit insuffisant \n");
                    ajouter_file_attente(H);

                  }

                  return H;
                 }
        }

        r3=r3->suiv;
    }

    if(trouver == 0)
    {
        printf("aucun hopital ne correspond a ces donnes \n");
        return H;
    }


}


void afficher_hopital(liste_Hopital *H)
{
    liste_Hopital *r=H;
    char search;
    printf("entrer le nom de l'hopitale: \n");
    scanf("%s",&search);

 if(H != NULL)
{
        while(r !=NULL)
        {
             if(r->Nbr_hopital ==search-'0' || strcmp(r->Hopital->nom,&search)==0)
               {
                  printf("No: %d\n",r->Hopital->NO_hopital);
                  printf("nom: %s\n",r->Hopital->nom);

                  printf("l'adresse de l'hopitale \n");
                  printf("la ville: %s \n",r->Hopital->adresse->ville);
                  printf("le cartier: %s \n",r->Hopital->adresse->cartier);
                  printf("le code postale: %d \n",r->Hopital->adresse->code_postal);

                  printf("nbr de lit diponible: %d\n",r->Hopital->nbr_lit_dispo);
                  printf("nbr de lit max: %d\n",r->Hopital->nbr_lit_max);
                  printf("nbr total de salle: %d\n",r->Hopital->nbr_salle_total);
                  printf("nbr total de salle disponible: %d\n",r->Hopital->nbr_salle_dispot);
                  printf("nbr de medecin: %d\n",r->Hopital->nbr_medecin);
                  printf("nbr de paramedicaux: %d\n",r->Hopital->nbr_paramedicaux);
                  break;
              }
              r=r->suiv;
        }

}else{
        printf("aucun hopital n'a etait trouver  \n");
    }

}




void afficher_salle(liste_Hopital *H)
{
    liste_Hopital *r3=H;
    Liste_Salle *r1;
    int trouver=0;
    char search;
    printf("entrer le nom ou bien le num de l'hopitale: \n");
    scanf("%s",&search);

    while(r3 !=NULL)
    {
        if(r3->Hopital->NO_hopital==search-'0' || strcmp(r3->Hopital->nom,&search)==0)
        {
            r1=r3->Hopital->salles;
            while(r1 !=NULL)
            {
               printf("no: %d \n",r1->salle->NO_salle);
               printf("besoin de : %s\n",r1->salle->salle_besoins);
               printf("le nbr de lit disponible: %d\n",r1->salle->nbr_lit_dipot);
               printf("le nbr de lit max: %d\n",r1->salle->nbr_lit_max);
               printf("---- \n");
               r1=r1->suiv;
            }
            break;
        }
          r3=r3->suiv;
    }
    printf("aucun sale n'a etait trouver \n");

}


void afficher_Hopitaux(liste_Hopital *H)
{
    liste_Hopital *r=H;


    if(H != NULL)
    {
        printf("\nle nbr d'hopitaux: %d \n\n",H->Nbr_hopital);
    while(r !=NULL)
    {
            printf("No: %d\n",r->Hopital->NO_hopital);
            printf("nom: %s\n",r->Hopital->nom);
            printf("---- \n");
        r=r->suiv;
    }
    }else{
         printf("la liste des hopiatux est vide \n");
    }

}

void afficher_liste_patient(liste_Hopital *H)
{
    int i,j;
    liste_Hopital *r3=H;
    liste_patient *r1;
    int choix,choix1,ageS=0,ageI=0,age=0,passer=0,snt=0;
    char city;
    char cartier;
    int code_postal;
    char name,sante;



       printf("----------------\n");
       printf("\nfaite un choix de recherche par:\n");
       printf("1.par nom d'hopital \n");
       printf("2.par adresse \n");
       printf("3.par age \n");
       printf("4.par etat de sante \n");
       printf("5.Quitte \n");
       scanf("%d",&choix);



     switch(choix)
       {
         case 1://nom
             printf("entrer le nom ou bien le num de l'hopitale: \n");
             scanf("%s",&name);
             passer=1;
         break;

         case 2://adresse
             printf("entrer la ville: \n");
             scanf("%s",&city);
             printf("entrer le cartier: \n");
             scanf("%s",&cartier);
             rewind(stdin);
             printf("entrer le code postale: \n");
             scanf("%d",&code_postal);
             passer=1;
         break;
         case 3:
             printf("1.age superieur ou egale a \n");
             printf("2.age inferieur ou egale a \n");
             scanf("%d",&choix);
             if(choix == 1)
             {
                 printf("entrer l'age \n");
                 scanf("%d",&ageS);
                 age=1;
             }else if(choix == 2){
                 printf("entrer l'age \n");
                 scanf("%d",&ageI);
                 age=1;
             }
         break;
         case 4:
         printf("rechercher par eta de sante (1)normal (2)critique \n");
         scanf("%d",&choix);
             if(choix == 1)
             {
                 strcpy(&sante,"normal");
                 snt=1;
             }else if(choix == 2){
                 strcpy(&sante,"critique");
                 snt=1;
             }
         default:
         break;
      };


     while(r3 !=NULL)
    {
         if(snt==1 || age==1||r3->Hopital->NO_hopital==name-'0' || strcmp(r3->Hopital->nom,&name)==0 || strcmp(r3->Hopital->adresse->ville,&city)==0 || strcmp(r3->Hopital->adresse->cartier,&cartier)==0 || r3->Hopital->adresse->code_postal == code_postal )
        {
            r1=r3->Hopital->Patients;

                   while(r1 !=NULL)
                   {
                       if((r1->patient->age>=ageS&&ageS !=0)||(r1->patient->age<=ageI&&ageI!=0) || passer==1 || strcmp(r1->patient->etat_patient,&sante)==0)
                       {
                         printf("\nle nom du patient: %s \n",r1->patient->nom);
                         printf("le prenom du patient: %s\n",r1->patient->prenom);
                         printf("l'etat du patient: %s\n",r1->patient->etat_patient);
                       }else{
                           printf("aucun patient ne correspant a ses donnes \n");
                       }


                      printf("----------\n");

                      r1=r1->suiv;
                   }

        }

        r3=r3->suiv;
    }



}

void afficher_patient(liste_Hopital *H)
{
    int i,j;
    liste_Hopital *r3=H;
    liste_patient *r1;
    int choix;
    char city;
    char cartier;
    int code_postal;
    char name;
    char nom;




       printf("----------------\n");
       printf("\nfaite un choix de recherche par:\n");
       printf("1.par nom d'hopital \n");
       printf("2.par adresse \n");
       printf("3.Quitte \n");
       scanf("%d",&choix);



     switch(choix)
       {
         case 1://nom
             printf("entrer le nom ou bien le num de l'hopitale: \n");
             scanf("%s",&name);
         break;

         case 2://adresse
             printf("entrer la ville: \n");
             scanf("%s",&city);
             printf("entrer le cartier: \n");
             scanf("%s",&cartier);
             rewind(stdin);
             printf("entrer le code postale: \n");
             scanf("%d",&code_postal);
         break;
         default:
         break;
      };


     while(r3 !=NULL)
    {
         if(r3->Hopital->NO_hopital==name-'0' || strcmp(r3->Hopital->nom,&name)==0 || strcmp(r3->Hopital->adresse->ville,&city)==0 || strcmp(r3->Hopital->adresse->cartier,&cartier)==0 || r3->Hopital->adresse->code_postal == code_postal )
        {
            r1=r3->Hopital->Patients;

                    printf("hopital %s trouver =>> \n",r3->Hopital->nom);
                    printf("entrer le nom du patient que vous rechercher: \n");
                    scanf("%s",&nom);

                   while(r1 !=NULL)
                   {
                       if(strcmp(r1->patient->nom,&nom)==0)
                       {
                           printf("\nle nom du patient: %s \n",r1->patient->nom);
                           printf("le prenom du patient: %s\n",r1->patient->prenom);
                           printf("l'adresse du patient: %s\n");
                           printf("la ville: %s\n",r1->patient->adresse->ville);
                           printf("le cartier: %s\n",r1->patient->adresse->cartier);
                           printf("le code postale: %d\n",r1->patient->adresse->code_postal);
                           printf("l'age du patient: %d\n",r1->patient->age);
                           printf("le nbr de maladie du patient: %d\n",r1->patient->nbr_maladies);

                          for(i=0;i<r1->patient->nbr_maladies;i++)
                          {
                           printf("maladie %d: %s\n",i,r1->patient->maladies[i]);
                          }
                          printf("l'etat du patient: %s\n",r1->patient->etat_patient);

                           printf("----------\n");
                       }

                      r1=r1->suiv;
                   }

        }

        r3=r3->suiv;
    }


}

void afficher_historique(liste_Hopital *H)
{
    Liste_historique *r;
    liste_Hopital *h=H;

if(H!=NULL)
{
    while(h !=NULL)
    {
        r=h->Hopital->liste_historique;

       if(h->Hopital->liste_historique != NULL)
       {
           while(r != NULL)
        {
           printf("%s %s |",r->nom,r->prenom);
           printf("%s %s |",h->Hopital->nom,h->Hopital->adresse->ville);
           printf("%d/%d/%d \n",r->date->JJ,r->date->MM,r->date->AAA);
           r=r->suiv;
        }
       }else{
          printf("aucun patient n'a etait encore rajouter dans l'hopital: %s \n",h->Hopital->nom);
       }




        h=h->suiv;
    }

}else{
    printf("l'historique est vide \n");
}


}


liste_Hopital* supprimer_patient(liste_Hopital *H)
{
    int i,j;
    liste_Hopital *r3=H;
    liste_patient *r1;
    int choix;
    char city;
    char cartier;
    int code_postal;
    char name;
    char nom;




       printf("----------------\n");
       printf("\nfaite un choix de recherche par:\n");
       printf("1.par nom d'hopital \n");
       printf("2.par adresse \n");
       printf("3.Quitte \n");
       scanf("%d",&choix);



     switch(choix)
       {
         case 1://nom
             printf("entrer le nom ou bien le num de l'hopitale: \n");
             scanf("%s",&name);
         break;

         case 2://adresse
             printf("entrer la ville: \n");
             scanf("%s",&city);
             printf("entrer le cartier: \n");
             scanf("%s",&cartier);
             rewind(stdin);
             printf("entrer le code postale: \n");
             scanf("%d",&code_postal);
         break;
         default:
         break;
      };


     while(r3 !=NULL)
    {
         if(r3->Hopital->NO_hopital==name-'0' || strcmp(r3->Hopital->nom,&name)==0 || strcmp(r3->Hopital->adresse->ville,&city)==0 || strcmp(r3->Hopital->adresse->cartier,&cartier)==0 || r3->Hopital->adresse->code_postal == code_postal )
        {
            r1=r3->Hopital->Patients;

                    printf("hopital %s trouver =>> \n",r3->Hopital->nom);
                    printf("entrer le nom du patient que vous vouller supprimer: \n");
                    scanf("%s",&nom);

                   while(r1 !=NULL)
                   {
                       if(strcmp(r1->patient->nom,&nom)==0)
                       {
                         printf("le patient %s a etait suprimer avec succe !!!\n",r1->patient->nom);

                         if(r1->suiv==NULL && r1->prec != NULL)
                         {
                             r1->prec->suiv=NULL;
                             r3->Hopital->nbr_lit_dispo+=1;
                             return H;
                         }else if(r1->prec == NULL && r1->suiv != NULL)
                         {
                             r1->suiv->prec=NULL;
                             r3->Hopital->Patients=r1->suiv;
                             r3->Hopital->nbr_lit_dispo+=1;
                             return H;
                         }else if(r1->prec != NULL && r1->suiv != NULL){
                            r1->suiv->prec=r1->prec;
                            r1->prec->suiv=r1->suiv;
                            r3->Hopital->nbr_lit_dispo+=1;
                            return H;
                         }else if(r1->suiv == NULL && r1->prec == NULL){
                             r3->Hopital->Patients=NULL;
                             r3->Hopital->nbr_lit_dispo+=1;
                             return H;
                         }

                       }

                      r1=r1->suiv;
                   }

        }

        r3=r3->suiv;
    }

        printf("aucun patient de se nom n'a etait trouver\n");
        return H;

}


liste_Hopital* modifier_hopital(liste_Hopital *H)
{

    liste_Hopital *r=H;
    char search;
    int choix;


    if(H != NULL)
     {
         printf("entrer le nom ou bien le num de l'hopitale: \n");
         scanf("%s",&search);
        while(r !=NULL)
        {
             if(r->Nbr_hopital ==search-'0' || strcmp(r->Hopital->nom,&search)==0)
               {

                   printf("veillez selectionner la donner que vous voulez modifier\n");
                   printf("1.le nom\n");
                   printf("2.le nbr de lit disponible\n");
                   printf("3.le nbr de salle disponble\n");
                   printf("4.le nbr de medecin \n");
                   printf("5.le nbr de paramedicaux \n");
                   printf("6.Quitte \n");
                   scanf("%d",&choix);
                   switch(choix)
                   {
                       case 1:
                           printf("entrer le nouveau nom \n");
                           scanf("%s",&r->Hopital->nom);
                           printf("la modification a etait effectuer avec succe !!!!\n");
                           return H;
                       break;
                       case 2:
                           printf("entrer le nbr de lit disponible \n");
                           scanf("%d",&r->Hopital->nbr_lit_dispo);
                           printf("la modification a etait effectuer avec succe !!!!\n");
                           return H;
                       break;
                       case 3:
                           printf("entrer le nbr de salle disponible \n");
                           scanf("%d",&r->Hopital->nbr_salle_dispot);
                           printf("la modification a etait effectuer avec succe !!!!\n");
                           return H;
                       break;
                       case 4:
                           printf("entrer le nbr de medecin \n");
                           scanf("%d",&r->Hopital->nbr_medecin);
                           printf("la modification a etait effectuer avec succe !!!!\n");
                           return H;
                       break;
                       case 5:
                           printf("entrer le nbr de paramedicaux \n");
                           scanf("%d",&r->Hopital->nbr_paramedicaux);
                           printf("la modification a etait effectuer avec succe !!!!\n");
                           return H;
                       break;
                       case 6:
                       return H;
                       break;

                       default:
                       break;
                   }

              }
              r=r->suiv;
        }

     }else{
        printf("la liste des hopitaux est vide \n");
        return H;
     }
     printf("aucun hopital n'a etait trouver \n");
     return H;
}


liste_Hopital* modifier_etat_patient(liste_Hopital *H)
{
        int i,j;
    liste_Hopital *r3=H;
    liste_patient *r1;
    int choix;
    char city;
    char cartier;
    int code_postal;
    char name;
    char nom;




       printf("----------------\n");
       printf("\nfaite un choix de recherche par:\n");
       printf("1.par nom d'hopital \n");
       printf("2.par adresse \n");
       printf("3.Quitte \n");
       scanf("%d",&choix);



     switch(choix)
       {
         case 1://nom
             printf("entrer le nom ou bien le num de l'hopitale: \n");
             scanf("%s",&name);
         break;

         case 2://adresse
             printf("entrer la ville: \n");
             scanf("%s",&city);
             printf("entrer le cartier: \n");
             scanf("%s",&cartier);
             rewind(stdin);
             printf("entrer le code postale: \n");
             scanf("%d",&code_postal);
         break;
         default:
         break;
      };


     while(r3 !=NULL)
    {
         if(r3->Hopital->NO_hopital==name-'0' || strcmp(r3->Hopital->nom,&name)==0 || strcmp(r3->Hopital->adresse->ville,&city)==0 || strcmp(r3->Hopital->adresse->cartier,&cartier)==0 || r3->Hopital->adresse->code_postal == code_postal )
        {
            r1=r3->Hopital->Patients;

                    printf("hopital %s trouver =>> \n",r3->Hopital->nom);
                    printf("entrer le nom du patient que vous rechercher: \n");
                    scanf("%s",&nom);

                   while(r1 !=NULL)
                   {
                       if(strcmp(r1->patient->nom,&nom)==0)
                       {

                          printf("l'etat du patient %s est: %s\n",r1->patient->nom,r1->patient->etat_patient);
                          printf("determiner le nouveau etat (1)normal,(2)critique : /n");
                          scanf("%d",&choix);
                          if(choix == 1)
                           {
                              strcpy(r1->patient->etat_patient,"normal");
                              printf("l'etat du patient a etait modifier avec succe /n");
                              return H;
                           }else if(choix == 2){
                              strcpy(r1->patient->etat_patient,"critique");
                              printf("l'etat du patient a etait modifier avec succe /n");
                              return H;
                           }

                           printf("----------\n");
                       }

                      r1=r1->suiv;
                   }

        }

        r3=r3->suiv;
    }

   printf("aucun patient n'a etait trouver \n");
   return H;
}


Hotel* ajouter_hotel(Hotel *h)
{
   Hotel *r1=h;
   Hotel *nouv;

   if(h == NULL)
   {
       h=malloc(sizeof(Hotel));
       printf("entrer le nom de l'hotel \n");
       scanf("%s",&h->nom);
       h->adresse=malloc(sizeof(Adresse));
       printf("entrer l'adresse \n");
          printf("la ville: \n");
          scanf("%s",&h->adresse->ville);
          printf("le cartier: \n");
          scanf("%s",&h->adresse->cartier);
          rewind(stdin);
          printf("le code postale: \n");
          scanf("%d",&h->adresse->code_postal);
       printf("entrer le nbr de lit disponible \n");
       scanf("%d",&h->nbr_lit_dispot);
       h->suiv=NULL;
       h->prec=NULL;
       return h;
   }else{

      while(r1->suiv != NULL)
      {
          r1=r1->suiv;
      }
      nouv=malloc(sizeof(Hotel));
       printf("entrer le nom de l'hotel \n");
       scanf("%s",&nouv->nom);
       nouv->adresse=malloc(sizeof(Adresse));
       printf("entrer l'adresse \n");
          printf("la ville: \n");
          scanf("%s",&nouv->adresse->ville);
          printf("le cartier: \n");
          scanf("%s",&nouv->adresse->cartier);
          rewind(stdin);
          printf("le code postale: \n");
          scanf("%d",&nouv->adresse->code_postal);
       printf("entrer le nbr de lit disponible \n");
       scanf("%d",&nouv->nbr_lit_dispot);
       nouv->suiv=NULL;
       nouv->prec=r1;
       r1->suiv=nouv;
       return h;

   }

}


void afficher_liste_hotel(Hotel *h)
{
   Hotel *r1=h;
   int choix;
   char nom;
   Adresse *A=malloc(sizeof(Adresse));
   printf("rechercher l'hotel par \n");
   printf("1.nom\n");
   printf("2.par adresse \n");
   printf("3.afficher tous les hoteles \n");
   printf("4.Quitte \n");
   scanf("%d",&choix);
   rewind(stdin);
   switch(choix)
   {
       case 1:
          printf("entrer le nom de l'hotel \n");
          scanf("%s",&nom);
        break;

       case 2:
       printf("entrer la ville: \n");
       scanf("%s",&A->ville);
       rewind(stdin);
       printf("entrer le cartier: \n");
       scanf("%s",&A->cartier);
       rewind(stdin);
       printf("entrer le code postale: \n");
       scanf("%d",&A->code_postal);
        break;

       case 4:
        break;

       default:
        break;
   }

   if(h != NULL)
   {
       while(r1 != NULL)
       {
          if(choix == 3||strcmp(r1->nom,&nom)==0 || strcmp(r1->adresse->ville,A->ville)==0 || strcmp(r1->adresse->cartier,A->cartier)==0 || r1->adresse->code_postal == A->code_postal)
          {
            printf("\nle nom de l'hotel %s\n",r1->nom);
            printf("la ville: %s\n",r1->adresse->ville);
            printf("le cartier: %s\n",r1->adresse->cartier);
            printf(" nbr de lit disponible: %d\n",r1->nbr_lit_dispot);
            printf("-----------------\n");
          }


         r1=r1->suiv;
       }

   }else{
       printf("aucun hotel n'a etait trouver !!! \n");
   }


}

void creer_citoyen(citoyen *C,liste_Hopital *H)
{
    int nbr,i,select,num=-1;
    liste_Hopital *r1=H;
    liste_patient *P;
    static int id=1;
    C->id=id;
    id++;
    printf("entrer le nom \n");
    scanf("%s",&C->nom);
    printf("entrer le prenom \n");
    scanf("%s",&C->prenom);
    rewind(stdin);
    printf("entrer l'age \n");
    scanf("%d",&C->age);
    C->adresse=malloc(sizeof(Adresse));
    printf("entrer l'adresse \n");
    printf("la ville \n");
    scanf("%s",&C->adresse->ville);
    printf("le cartier \n");
    scanf("%s",&C->adresse->cartier);
    rewind(stdin);
    printf("le code postale \n");
    scanf("%d",&C->adresse->code_postal);
    printf("entrer le nbr de maladie de cette personne \n");
    scanf("%d",&C->nbr_maldie);
    C->maladies=malloc(C->nbr_maldie*sizeof(char*));
    for(i=0;i<C->nbr_maldie;i++)
    {
        printf("entrer la maladie %d:\n",i+1);
        scanf("%s",C->maladies[i]);
    }
    rewind(stdin);
    printf("comment la propagation du veruse a eu lieu (1)local (2)en etranger \n");
    scanf("%d",&select);
    if(select == 1)
    {
       printf("entrer le num du patient avec lequelle a ou le contact \n");
       scanf("%d",&num);
       if(r1!= NULL)
       {
          while(r1 != NULL)
              {
                 P=r1->Hopital->Patients;
                 while(P != NULL)
                 {
                     if(P->patient->NO_patient == num)
                      {
                        strcpy(C->contaminateur,P->patient->nom);
                        printf("le patient %s correspont au num %d\n",P->patient->nom,num);
                        num=1;
                      }
                }
           r1=r1->suiv;
             }
           if(num == -1)
             {
           printf("auncun patient ne correspond a se numero \n");
           strcpy(C->contaminateur,"aucun personne n'est determiner");
             }
       }else{
          printf("la liste des patient est vide \n");
       }

       strcpy(C->type_contamination,"local");
    }else if(select == 2){
       strcpy(C->type_contamination,"d'un autre pays");
       strcpy(C->contaminateur,"aucun");
    }
    strcpy(C->affectation,"aucun lieu");
}

Liste_quarantaine* ajouter_personne_quarantaine(Liste_quarantaine *Q,liste_Hopital *H)
{
    Liste_quarantaine *nouv;
    Liste_quarantaine *r1=Q;

    if(Q==NULL)
    {
        Q=malloc(sizeof(Liste_quarantaine));
        Q->citoyen=malloc(sizeof(citoyen));
        creer_citoyen(Q->citoyen,H);
        Q->suiv=NULL;
        Q->prec=NULL;
        return Q;
    }else{
        while(r1->suiv != NULL)
        {
            r1=r1->suiv;
        }
        nouv=malloc(sizeof(Liste_quarantaine));
        nouv->citoyen=malloc(sizeof(citoyen));
        creer_citoyen(nouv->citoyen,H);
        nouv->suiv=NULL;
        nouv->prec=r1;
        r1->suiv=nouv;
        return Q;
    }
}


void afficher_liste_quarantaine(Liste_quarantaine *Q)
{
    Liste_quarantaine *r1=Q;

    if(r1 != NULL)
    {
       while(r1 != NULL)
       {
        printf("id: %d \n",r1->citoyen->id);
        printf("nom: %s\n",r1->citoyen->nom);
        printf("prenom: %s\n",r1->citoyen->prenom);
        printf("l'age: %d\n",r1->citoyen->age);
        printf("le contaminateur: %s\n",r1->citoyen->contaminateur);
        printf("types de contamination: %s\n",r1->citoyen->type_contamination);
        printf("lieu d'affectation: %s\n",r1->citoyen->affectation);
        printf("-------------\n");
        r1=r1->suiv;
       }
    }else{
       printf("la liste est vide \n");
    }

}



void ajouter_file_attente(liste_Hopital *H)
{
   Liste_file *r=H->liste_file;
   Liste_file *nouv;

    if(H->liste_file ==NULL)
    {
        H->liste_file=malloc(sizeof(Liste_file));
        H->liste_file->patient=malloc(sizeof(Patient));
        creer_Patient(H->liste_file->patient);
        H->liste_file->suiv=NULL;
    }else{

        while(r->suiv != NULL)
        {
            r=r->suiv;
        }

        nouv=malloc(sizeof(Liste_file));

        nouv->patient=malloc(sizeof(Patient));
        creer_Patient(nouv->patient);
        r->suiv=nouv;
        nouv->suiv=NULL;
    }
}


void afficher_file_attente(liste_Hopital *H)
{
    Liste_file *r=H->liste_file;

    while(r != NULL)
    {
        printf("nom: %s\n",r->patient->nom);
        r=r->suiv;
    }

}



Liste_quarantaine* affecter_citoyen(Liste_quarantaine *Q,Hotel *h)
{
    Hotel *r=h;
    Liste_quarantaine *r1=Q;
    int choix,touver=0,num;
    char nom;


     printf("affectation a un hotel \n");
     printf("1.affectation manuelle \n");
     printf("2.affectation automatique \n");
     printf("3.Quitte \n");
     scanf("%d",&choix);

     switch(choix)
       {
         case 1:
             printf("entrer le nom de l'hotel \n");
             scanf("%s",&nom);

             while(h !=NULL)
             {
                 if(strcmp(h->nom,&nom)==0)
                 {
                     printf("hotel %s a etait trouver \n",h->nom);

                     if(h->nbr_lit_dispot >0)
                     {
                          printf("entrer le num du citoyens que vous voulez affecter \n");
                          scanf("%d",&num);
                            while(r1 != NULL)
                            {
                              if(r1->citoyen->id == num)
                                {
                                  printf("le citoyen %s a etait trouver \n",r1->citoyen->nom);
                                  strcpy(r1->citoyen->affectation,h->nom);
                                  h->nbr_lit_dispot-=1;
                                  return Q;
                                }
                                r1=r1->suiv;
                              }
                     printf("aucun citoyen n'a etait trouver \n");
                     return Q;
                     }else{
                        printf("nbr de lit insuffisant \n");
                        return Q;
                     }

                 }
                 h=h->suiv;
             }
             printf("aucun hotel n'a etait trouver \n");
             return Q;
         break;

         case 2:
              printf("entrer le num du citoyen que vous voulez affecter \n");
              scanf("%d",&num);
              while(r1 !=NULL)
              {
                  if(r1->citoyen->id == num)
                  {
                      printf("le citoyen %s a etait trouver \n",r1->citoyen->nom);

                      while(r != NULL)
                      {
                        if(strcmp(r1->citoyen->adresse->ville,r->adresse->ville)==0)
                        {
                            printf("hotel %s a etait trouver \n",r->nom);
                            if(r->nbr_lit_dispot >0)
                            {
                                strcpy(r1->citoyen->affectation,r->nom);
                                h->nbr_lit_dispot-=1;
                                return Q;
                            }else{
                               printf("nbr de lit insuffisant\n");
                               return Q;
                            }
                        }
                      }
                      printf("aucun hotel n'a etait trouver \n");
                      return Q;
                  }
                  r1=r1->suiv;
              }
              printf("aucun citoyen ne correspant a se numero \n");
              return Q;
         break;

         case 3:
            break;


         default:
         break;
      };

}


Liste_quarantaine* supprimer_citoyen_quarantaine(Liste_quarantaine *Q,Hotel *h)
{
    int num;

    Liste_quarantaine *r=Q;
    Hotel *r1=h;

    printf("entrer le numero du citoyen que vous voulez supprimer \n");
    scanf("%d",&num);

    while(r !=NULL)
    {
        if(r->citoyen->id == num)
        {
            printf("le citoyen(ne) %s a etait trouver \n",r->citoyen->nom);

               if(r->prec == NULL && r->suiv!=NULL)
               {
                   r->suiv->prec=NULL;
                   return r->suiv;
               }else if(r->suiv==NULL && r->prec!=NULL){
                   r->prec->suiv=NULL;
                   return Q;
               }else if(r->suiv!=NULL && r->prec!=NULL){
                   r->suiv->prec=r->prec;
                   r->prec->suiv=r->suiv;
                   return Q;
               }else if(r->prec == NULL && r->suiv==NULL){
                    Q=NULL;
                    return Q;
               }


            while(r1 != NULL)
            {
                if(strcmp(r->citoyen->affectation,r1->nom)==0)
                {

                    r1->nbr_lit_dispot+=1;
                    return Q;
                }
                r1=r1->suiv;
            }
            printf("se citoyen n'a encore etait affecter a aucun hotel \n");

        }
        r=r->suiv;
    }

    printf("aucun citoyen ne correspant a se nom \n");
    return Q;
}



Liste_file* supprimer_file(liste_Hopital *H)
{

    return H->liste_file->suiv;

}
Patient* retourner_file(liste_Hopital *H)
{
    return H->liste_file->patient;
}

liste_Hopital* ajout_fille_attente(liste_Hopital *H)
{
    Patient *P;
    liste_patient *r1;
    liste_patient*nouv;
    liste_Hopital *r3=H;
    Liste_historique *h;
    Hopital *hopital=malloc(sizeof(Hopital));

    int choix;
    char city;
    char cartier;
    int code_postal;
    char name;
    int trouver =0;
    /*************/




       printf("----------------\n");
       printf("\nfaite un choix de recherche par:\n");
       printf("1.par nom d'hopital \n");
       printf("2.par adresse \n");
       printf("4.Quitte \n");
       scanf("%d",&choix);



     switch(choix)
       {
         case 1://nom
             printf("entrer le nom ou bien le num de l'hopitale: \n");
             scanf("%s",&name);
         break;

         case 2://adresse
             printf("entrer la ville: \n");
             scanf("%s",&city);
             printf("entrer le cartier: \n");
             scanf("%s",&cartier);
             rewind(stdin);
             printf("entrer le code postale: \n");
             scanf("%d",&code_postal);
         break;
          case 4:
              return H;
          break;

         default:
         break;
      };










     while(r3 !=NULL)
    {
         if(r3->Hopital->NO_hopital==name-'0' || strcmp(r3->Hopital->nom,&name)==0 || strcmp(r3->Hopital->adresse->ville,&city)==0 || strcmp(r3->Hopital->adresse->cartier,&cartier)==0 || r3->Hopital->adresse->code_postal == code_postal || strcmp(r3->Hopital->nom,hopital->nom)==0)
        {
            printf("\nl'hopital %s a etait touver \n",r3->Hopital->nom);

          if(r3->Hopital->nbr_lit_dispo >0)
          {
              if( r3->Hopital->Patients == NULL)
            {
                printf("ok \n");
                r3->Hopital->Patients=malloc(sizeof(liste_patient));
                r3->Hopital->Patients->patient=malloc(sizeof(Patient));
                r3->Hopital->Patients->patient=retourner_file(H);
                r3->Hopital->Patients->suiv=NULL;
                r3->Hopital->Patients->prec=NULL;
                r3->Hopital->nbr_lit_dispo-=1;
                r3->liste_file=supprimer_file(H);


                return H;
            }else{
              while(r3->Hopital->Patients->suiv != NULL)
              {
                r3->Hopital->Patients=r3->Hopital->Patients->suiv;
              }

              P=malloc(sizeof(Patient));
              P=retourner_file(H);
              nouv=malloc(sizeof(liste_patient));
              nouv->patient=malloc(sizeof(Patient));
              nouv->patient=P;
              nouv->suiv=NULL;
              nouv->prec=r3->Hopital->Patients;
              r3->Hopital->Patients->suiv=nouv;
              r3->Hopital->nbr_lit_dispo-=1;
              H->liste_file=supprimer_file(H);

            return H;
            }

          }else{
             printf("le nbr de lit est insuffisant \n");
             return H;
          }


         }


        r3=r3->suiv;
    }


        printf("aucun hopital ne correspond a ces donnes \n");
        return H;



}










