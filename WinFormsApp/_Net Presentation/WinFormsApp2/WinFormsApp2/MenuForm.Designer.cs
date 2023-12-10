namespace WinFormsApp2
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Clients = new System.Windows.Forms.Button();
            this.Departement = new System.Windows.Forms.Button();
            this.products = new System.Windows.Forms.Button();
            this.Commande = new System.Windows.Forms.Button();
            this.Categorie = new System.Windows.Forms.Button();
            this.LigneCommande = new System.Windows.Forms.Button();
            this.Facture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Clients
            // 
            this.Clients.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Clients.Location = new System.Drawing.Point(170, 31);
            this.Clients.Name = "Clients";
            this.Clients.Size = new System.Drawing.Size(150, 50);
            this.Clients.TabIndex = 0;
            this.Clients.Text = "Clients";
            this.Clients.UseVisualStyleBackColor = true;
            this.Clients.Click += new System.EventHandler(this.Clients_Click);
            // 
            // Departement
            // 
            this.Departement.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Departement.Location = new System.Drawing.Point(170, 279);
            this.Departement.Name = "Departement";
            this.Departement.Size = new System.Drawing.Size(150, 50);
            this.Departement.TabIndex = 1;
            this.Departement.Text = "Departements";
            this.Departement.UseVisualStyleBackColor = true;
            this.Departement.Click += new System.EventHandler(this.Departement_Click);
            // 
            // products
            // 
            this.products.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.products.Location = new System.Drawing.Point(170, 158);
            this.products.Name = "products";
            this.products.Size = new System.Drawing.Size(150, 50);
            this.products.TabIndex = 2;
            this.products.Text = "Products";
            this.products.UseVisualStyleBackColor = true;
            this.products.Click += new System.EventHandler(this.products_Click);
            // 
            // Commande
            // 
            this.Commande.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Commande.Location = new System.Drawing.Point(490, 31);
            this.Commande.Name = "Commande";
            this.Commande.Size = new System.Drawing.Size(150, 50);
            this.Commande.TabIndex = 3;
            this.Commande.Text = "Commande";
            this.Commande.UseVisualStyleBackColor = true;
            this.Commande.Click += new System.EventHandler(this.Commande_Click);
            // 
            // Categorie
            // 
            this.Categorie.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Categorie.Location = new System.Drawing.Point(500, 158);
            this.Categorie.Name = "Categorie";
            this.Categorie.Size = new System.Drawing.Size(150, 50);
            this.Categorie.TabIndex = 4;
            this.Categorie.Text = "Categorie";
            this.Categorie.UseVisualStyleBackColor = true;
            this.Categorie.Click += new System.EventHandler(this.Categorie_Click);
            // 
            // LigneCommande
            // 
            this.LigneCommande.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LigneCommande.Location = new System.Drawing.Point(500, 281);
            this.LigneCommande.Name = "LigneCommande";
            this.LigneCommande.Size = new System.Drawing.Size(201, 48);
            this.LigneCommande.TabIndex = 7;
            this.LigneCommande.Text = "LigneCommande";
            this.LigneCommande.UseVisualStyleBackColor = true;
            this.LigneCommande.Click += new System.EventHandler(this.LigneCommande_Click);
            // 
            // Facture
            // 
            this.Facture.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Facture.Location = new System.Drawing.Point(343, 366);
            this.Facture.Name = "Facture";
            this.Facture.Size = new System.Drawing.Size(143, 51);
            this.Facture.TabIndex = 9;
            this.Facture.Text = "Facture";
            this.Facture.UseVisualStyleBackColor = true;
            this.Facture.Click += new System.EventHandler(this.Facture_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Facture);
            this.Controls.Add(this.LigneCommande);
            this.Controls.Add(this.Categorie);
            this.Controls.Add(this.Commande);
            this.Controls.Add(this.products);
            this.Controls.Add(this.Departement);
            this.Controls.Add(this.Clients);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button Clients;
        private Button Departement;
        private Button products;
        private Button Commande;
        private Button Categorie;
        private Button LigneCommande;
        private Button Facture;
    }
}