namespace WinFormsApp2
{
    partial class LigneCommande
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
            this.dataGridViewCommande = new System.Windows.Forms.DataGridView();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.dataGridViewLigneCommande = new System.Windows.Forms.DataGridView();
            this.CommandeQuantity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddCommande = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Supprimer = new System.Windows.Forms.Button();
            this.Modifier = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCommande)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLigneCommande)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCommande
            // 
            this.dataGridViewCommande.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCommande.Location = new System.Drawing.Point(12, 27);
            this.dataGridViewCommande.Name = "dataGridViewCommande";
            this.dataGridViewCommande.RowTemplate.Height = 25;
            this.dataGridViewCommande.Size = new System.Drawing.Size(379, 150);
            this.dataGridViewCommande.TabIndex = 0;
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Location = new System.Drawing.Point(422, 27);
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.RowTemplate.Height = 25;
            this.dataGridViewProduct.Size = new System.Drawing.Size(366, 150);
            this.dataGridViewProduct.TabIndex = 1;
            // 
            // dataGridViewLigneCommande
            // 
            this.dataGridViewLigneCommande.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLigneCommande.Location = new System.Drawing.Point(357, 217);
            this.dataGridViewLigneCommande.Name = "dataGridViewLigneCommande";
            this.dataGridViewLigneCommande.RowTemplate.Height = 25;
            this.dataGridViewLigneCommande.Size = new System.Drawing.Size(431, 221);
            this.dataGridViewLigneCommande.TabIndex = 2;
            // 
            // CommandeQuantity
            // 
            this.CommandeQuantity.Location = new System.Drawing.Point(191, 248);
            this.CommandeQuantity.Name = "CommandeQuantity";
            this.CommandeQuantity.Size = new System.Drawing.Size(100, 23);
            this.CommandeQuantity.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(2, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Entrer la quantite a commander";
            // 
            // AddCommande
            // 
            this.AddCommande.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AddCommande.Location = new System.Drawing.Point(6, 341);
            this.AddCommande.Name = "AddCommande";
            this.AddCommande.Size = new System.Drawing.Size(102, 33);
            this.AddCommande.TabIndex = 5;
            this.AddCommande.Text = "Ajouter";
            this.AddCommande.UseVisualStyleBackColor = true;
            this.AddCommande.Click += new System.EventHandler(this.AddCommande_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Label2.Location = new System.Drawing.Point(114, 3);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(126, 22);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "COMMANDE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(544, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "PRODUCT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(479, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "LIGNE_COMMANDE";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Supprimer
            // 
            this.Supprimer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Supprimer.Location = new System.Drawing.Point(123, 341);
            this.Supprimer.Name = "Supprimer";
            this.Supprimer.Size = new System.Drawing.Size(107, 32);
            this.Supprimer.TabIndex = 10;
            this.Supprimer.Text = "Supprimer";
            this.Supprimer.UseVisualStyleBackColor = true;
            this.Supprimer.Click += new System.EventHandler(this.Supprimer_Click);
            // 
            // Modifier
            // 
            this.Modifier.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Modifier.Location = new System.Drawing.Point(245, 341);
            this.Modifier.Name = "Modifier";
            this.Modifier.Size = new System.Drawing.Size(106, 33);
            this.Modifier.TabIndex = 11;
            this.Modifier.Text = "Modifier";
            this.Modifier.UseVisualStyleBackColor = true;
            this.Modifier.Click += new System.EventHandler(this.Modifier_Click);
            // 
            // LigneCommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Modifier);
            this.Controls.Add(this.Supprimer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.AddCommande);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CommandeQuantity);
            this.Controls.Add(this.dataGridViewLigneCommande);
            this.Controls.Add(this.dataGridViewProduct);
            this.Controls.Add(this.dataGridViewCommande);
            this.Name = "LigneCommande";
            this.Text = "LigneCommande";
            this.Load += new System.EventHandler(this.LigneCommande_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCommande)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLigneCommande)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridViewCommande;
        private DataGridView dataGridViewProduct;
        private DataGridView dataGridViewLigneCommande;
        private TextBox CommandeQuantity;
        private Label label1;
        private Button AddCommande;
        private Label Label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button Supprimer;
        private Button Modifier;
    }
}