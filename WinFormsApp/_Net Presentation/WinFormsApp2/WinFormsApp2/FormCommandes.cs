using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WinFormsApp2.DB;

namespace WinFormsApp2
{
    public partial class FormCommandes : Form
    {
        DbContext dbContext;
        public FormCommandes( DbContext _dbContext)
        {
            dbContext = _dbContext;
            InitializeComponent();
        }

        private void FormCommandes_Load(object sender, EventArgs e)
        {

            dbContext.GetDataGenerique("Customer");
            this.dataGridViewClient.DataSource = dbContext.DataSet.Tables["Customer"];


            dbContext.GetDataGenerique("Commande");
            this.dataGridViewCommande.DataSource = dbContext.DataSet.Tables["Commande"];


            int count = this.dataGridViewClient.Rows.Count;

            for (int i = 0; i < count-1; i++)
            {
                this.comboBoxClientId.Items.Add(this.dataGridViewClient["Id",i].Value);
            }
              
        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
            string ClientId = null;
            if (!String.IsNullOrWhiteSpace(this.comboBoxClientId.Text))
            {
                ClientId = this.comboBoxClientId.Text;
            }
            else
            {               
                  ClientId = dataGridViewClient.CurrentRow.Cells["Id"].Value.ToString();
            }
            DateTime date =DateTime.Parse(this.dateTimeCommande.Text);
            Dictionary<string, Object> newOrder = new();

            if(!String.IsNullOrWhiteSpace(ClientId))
               newOrder.Add("CustomerId", ClientId);

            newOrder.Add("OrderDate", date);
            newOrder.Add("Status","Non Livrer");

            if (newOrder.Count == (dbContext.DataSet.Tables["Commande"].Columns.Count - 1))
            {
                dbContext.AddDataGenerique("Commande", newOrder);
                dbContext.GetDataGenerique("Commande");
            }
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            if (dataGridViewCommande.CurrentRow != null)
            {
                string id = dataGridViewCommande.CurrentRow.Cells["Id"].Value.ToString();
                dbContext.DeleteDataGenerique("Commande", id);
                dbContext.GetDataGenerique("Commande");
            }
        }

        private void RechercherInput_Click(object sender, EventArgs e)
        {
            string id = this.RechercherIdInput.Text;

            

            if (Guid.TryParse(id, out var IdGuid))// (!string.IsNullOrWhiteSpace(id))
            {
                Dictionary<string, Object> SearchData = new();
                SearchData.Add("CustomerId", IdGuid);
                dbContext.FilterDataGenerique("Commande", SearchData);
                
            }else{
                  dbContext.GetDataGenerique("Commande");
            }
        }

        private void dataGridViewClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.comboBoxClientId.Text = dataGridViewClient.CurrentRow.Cells["Id"].Value.ToString(); 
            
        }

        private void dataGridViewCommande_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.comboBoxClientId.Text = dataGridViewCommande.CurrentRow.Cells["Id"].Value.ToString();
           // this.dateTimePicker.DataBindings = dataGridViewCommande.CurrentRow.Cells["OrderDate"].Value;

        }

        private void exit_Click(object sender, EventArgs e)
        {

            this.Close();
            MenuForm menuForm = new MenuForm(dbContext);
            menuForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
            LigneCommande LigneCommandeForm = new LigneCommande(dbContext);
            LigneCommandeForm.Show();
        }

        private void PasserCommande_Click(object sender, EventArgs e)
        {
            if (dataGridViewCommande.CurrentRow != null)
            {
                string CommandeId = dataGridViewCommande.CurrentRow.Cells["Id"].Value.ToString();
                dbContext.PasserCommande(CommandeId);
                dbContext.GetDataGenerique("Commande");
            }
        }
    }
}
