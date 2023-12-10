using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.DB;

namespace WinFormsApp2
{
    public partial class LigneCommande : Form
    {
        private DbContext dbContext;
        public LigneCommande(DbContext _dbContext)
        {
            InitializeComponent();
            dbContext = _dbContext;
        }

        private void LigneCommande_Load(object sender, EventArgs e)
        {
            dbContext.GetDataGenerique("Commande");
            this.dataGridViewCommande.DataSource = dbContext.DataSet.Tables["Commande"];

            dbContext.GetDataGenerique("Product");
            this.dataGridViewLigneCommande.DataSource = dbContext.DataSet.Tables["LigneCommande"];

            dbContext.GetDataGenerique("LigneCommande");
            this.dataGridViewProduct.DataSource= dbContext.DataSet.Tables["Product"];
        }

        private void AddCommande_Click(object sender, EventArgs e)
        {
            string message = null;
            if (string.IsNullOrWhiteSpace(this.CommandeQuantity.Text))
            {
                message = "Please enter the quantity. Please Retry";
                
            }
            else
            {
                int? quantity = null;
                try
                {
                     quantity= int.Parse(this.CommandeQuantity.Text);
                }
                catch (FormatException)
                {
                    message = "the type of quatity are incorrect. Please Retry";
                }

                if (dataGridViewCommande.CurrentRow == null)
                    return;

                string CommandeId = dataGridViewCommande.CurrentRow.Cells["Id"].Value.ToString();
                string ProductId = dataGridViewProduct.CurrentRow.Cells["Id"].Value.ToString();
                int quantityNow = int.Parse(dataGridViewProduct.CurrentRow.Cells["Quantity"].Value.ToString());
                string GuidProduct = dataGridViewProduct.CurrentRow.Cells["Id"].Value.ToString();

                if (quantity != null & quantity > 0 && quantityNow > 0 && (quantityNow - quantity) >= 0)
                {

                    dbContext.UpdateDataGenrique("product", GuidProduct, new Dictionary<string, Object>() { ["quantity"] = (quantityNow - quantity) });
                    Dictionary<string, Object> Data = new()
                    {
                        ["CommandeId"] = CommandeId,
                        ["ProductId"] = ProductId,
                        ["Quantity"] = quantity
                    };

                    dbContext.AddDataGenerique("LigneCommande", Data);
                    dbContext.GetDataGenerique("LigneCommande");
                    dbContext.GetDataGenerique("Product");
                    return;
                }
                else if(quantity == 0 || quantityNow < 0 || (quantityNow - quantity) < 0)
                {
                    message = "Quantity are not siffisant. Please Retry";
                }

            }
 
                
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuForm menuForm = new MenuForm(dbContext);
            menuForm.Show();
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            if (dataGridViewLigneCommande.CurrentRow == null)
                return;

            string LigneCommandeId = dataGridViewLigneCommande.CurrentRow.Cells["Id"].Value.ToString();
            dbContext.DeleteDataGenerique("LigneCommande",LigneCommandeId);
            dbContext.GetDataGenerique("LigneCommande");
        }

        private void Modifier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.CommandeQuantity.Text) || dataGridViewLigneCommande.CurrentRow == null || dataGridViewProduct.CurrentRow == null)
                return;

            int quantity = int.Parse(this.CommandeQuantity.Text);
            string LigneCommandeId = dataGridViewLigneCommande.CurrentRow.Cells["Id"].Value.ToString();
            string ProductId = dataGridViewProduct.CurrentRow.Cells["Id"].Value.ToString();

            int ProductQte = int.Parse(dataGridViewProduct.CurrentRow.Cells["Quantity"].Value.ToString());
            int LigneCommandeQte = int.Parse(dataGridViewLigneCommande.CurrentRow.Cells["Quantity"].Value.ToString());

            if (quantity != 0)
            {
                if (quantity < LigneCommandeQte)
                {
                    var QteDiff = LigneCommandeQte - quantity;


                    dbContext.UpdateDataGenrique("Product", ProductId, new Dictionary<string, object>()
                    {
                        ["Quantity"] = ProductQte + QteDiff
                    }) ;
                    dbContext.UpdateDataGenrique("LigneCommande", LigneCommandeId, new Dictionary<string, object>()
                    {
                        ["Quantity"] = quantity
                    });
                }
                else if(quantity > LigneCommandeQte)
                {
                    if (quantity < ProductQte)
                    {
                        dbContext.UpdateDataGenrique("Product", ProductId, new Dictionary<string, object>()
                        {
                            ["Quantity"] = ProductQte - quantity
                        }) ;

                        dbContext.UpdateDataGenrique("LigneCommande", LigneCommandeId, new Dictionary<string, object>()
                        {
                            ["Quantity"] = quantity
                        });
                    }
                }
            }

            dbContext.GetDataGenerique("Product");
            dbContext.GetDataGenerique("LigneCommande");

        }
    }
}
