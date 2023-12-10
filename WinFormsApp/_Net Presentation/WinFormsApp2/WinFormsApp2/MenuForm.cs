using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.DB;

namespace WinFormsApp2
{
    public partial class MenuForm : Form
    { 
        DbContext dbContext;
       public MenuForm(DbContext _dbContext)
        {
            InitializeComponent();
            dbContext = _dbContext;
        }

        private void Clients_Click(object sender, EventArgs e)
        {
            this.Close();
           
            ManagementForm managementForm = new ManagementForm("Customer",dbContext);
            managementForm.Show();
        }

        private void products_Click(object sender, EventArgs e)
        {
            this.Close();

            ManagementForm managementForm = new ManagementForm("Product", dbContext);
            managementForm.Show();
        }

        private void Departement_Click(object sender, EventArgs e)
        {
            this.Close();

            ManagementForm managementForm = new ManagementForm("Departement", dbContext);
            managementForm.Show();
        }

        private void Commande_Click(object sender, EventArgs e)
        {
            this.Close();
            FormCommandes formCommandes = new FormCommandes(dbContext);
            formCommandes.Show();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void Categorie_Click(object sender, EventArgs e)
        {

            this.Close();

            ManagementForm managementForm = new ManagementForm("Categorie", dbContext);
            managementForm.Show();
        }

        private void LigneCommande_Click(object sender, EventArgs e)
        {
            this.Close();
            LigneCommande ligneCommandeForm = new LigneCommande(dbContext);
            ligneCommandeForm.Show();
        }

        private void Facture_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagementForm managementForm = new ManagementForm("Facture", dbContext);
            managementForm.Show();
        }
    }
}
