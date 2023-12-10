#ifndef C_H_INCLUDED
#define C_H_INCLUDED

typedef struct liste_Hopital liste_Hopital;
typedef struct Patient Patient;
typedef struct Liste_Salle Liste_Salle;
typedef struct Liste_historique Liste_historique;
typedef struct liste_patient liste_patient;
typedef struct Liste_file Liste_file;
typedef struct Liste_quarantaine Liste_quarantaine;
typedef struct Hotel Hotel;

typedef struct{

int JJ,MM,AAA;

}Date;




struct Liste_historique{
char nom[15];
char prenom[15];
Date *date;
Liste_historique *suiv;
Liste_historique *prec;
};




typedef struct{
char ville[15];
char cartier[15];
int code_postal;
}Adresse;

typedef struct{
int NO_salle;
char salle_besoins[20];
int nbr_lit_dipot;
int nbr_lit_max;
}Salle;

struct Liste_Salle{
Salle *salle;
Liste_Salle *suiv;
Liste_Salle *prec;
};


struct Liste_file{
  Liste_file *suiv;
  Patient *patient;
};


typedef struct{

int NO_hopital;
char nom[15];
Adresse *adresse;
int nbr_lit_dispo;
int nbr_lit_max;
int nbr_salle_total;
int nbr_salle_dispot;
int nbr_medecin;
int nbr_paramedicaux;
Liste_Salle *salles;
liste_patient *Patients;
Liste_historique *liste_historique;
}Hopital;

struct liste_Hopital{
Hopital *Hopital;
liste_Hopital *suiv;
liste_Hopital *prec;
Liste_file *liste_file;
int Nbr_hopital;
};


struct liste_patient{
Patient *patient;
liste_patient *suiv;
liste_patient *prec;
};

struct Patient{
int NO_patient;
char nom[15];
char prenom[15];
Adresse *adresse;
int age;
char **maladies;
int nbr_maladies;
char etat_patient[10];
char nom_hopital;
int NO_salle;
};

typedef struct{
int id;
char nom[15];
char prenom[15];
int age;
Adresse *adresse;
char **maladies;
int nbr_maldie;
char contaminateur[15];
char type_contamination[15];
char affectation[15];
}citoyen;

struct Liste_quarantaine{
citoyen *citoyen;
Liste_quarantaine *suiv;
Liste_quarantaine *prec;
};

struct Hotel{
char nom[15];
Adresse *adresse;
int nbr_lit_dispot;
Hotel *suiv;
Hotel *prec;
};

#endif // C_H_INCLUDED
