namespace WinFormsApp2
{
    partial class FormCommandes
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
            this.dataGridViewClient = new System.Windows.Forms.DataGridView();
            this.dataGridViewCommande = new System.Windows.Forms.DataGridView();
            this.dateTimeCommande = new System.Windows.Forms.DateTimePicker();
            this.Ajouter = new System.Windows.Forms.Button();
            this.Supprimer = new System.Windows.Forms.Button();
            this.comboBoxClientId = new System.Windows.Forms.ComboBox();
            this.RechercherIdInput = new System.Windows.Forms.TextBox();
            this.RechercherInput = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.exit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.PasserCommande = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCommande)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewClient
            // 
            this.dataGridViewClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClient.Location = new System.Drawing.Point(53, 22);
            this.dataGridViewClient.Name = "dataGridViewClient";
            this.dataGridViewClient.RowTemplate.Height = 25;
            this.dataGridViewClient.Size = new System.Drawing.Size(425, 150);
            this.dataGridViewClient.TabIndex = 0;
            this.dataGridViewClient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClient_CellContentClick);
            // 
            // dataGridViewCommande
            // 
            this.dataGridViewCommande.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCommande.Location = new System.Drawing.Point(53, 189);
            this.dataGridViewCommande.Name = "dataGridViewCommande";
            this.dataGridViewCommande.RowTemplate.Height = 25;
            this.dataGridViewCommande.Size = new System.Drawing.Size(425, 150);
            this.dataGridViewCommande.TabIndex = 1;
            this.dataGridViewCommande.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCommande_CellContentClick);
            // 
            // dateTimeCommande
            // 
            this.dateTimeCommande.Location = new System.Drawing.Point(588, 44);
            this.dateTimeCommande.Name = "dateTimeCommande";
            this.dateTimeCommande.Size = new System.Drawing.Size(200, 23);
            this.dateTimeCommande.TabIndex = 2;
            // 
            // Ajouter
            // 
            this.Ajouter.Location = new System.Drawing.Point(513, 173);
            this.Ajouter.Name = "Ajouter";
            this.Ajouter.Size = new System.Drawing.Size(127, 33);
            this.Ajouter.TabIndex = 3;
            this.Ajouter.Text = "Ajouter";
            this.Ajouter.UseVisualStyleBackColor = true;
            this.Ajouter.Click += new System.EventHandler(this.Ajouter_Click);
            // 
            // Supprimer
            // 
            this.Supprimer.Location = new System.Drawing.Point(646, 173);
            this.Supprimer.Name = "Supprimer";
            this.Supprimer.Size = new System.Drawing.Size(119, 33);
            this.Supprimer.TabIndex = 5;
            this.Supprimer.Text = "Supprimer";
            this.Supprimer.UseVisualStyleBackColor = true;
            this.Supprimer.Click += new System.EventHandler(this.Supprimer_Click);
            // 
            // comboBoxClientId
            // 
            this.comboBoxClientId.FormattingEnabled = true;
            this.comboBoxClientId.Location = new System.Drawing.Point(588, 82);
            this.comboBoxClientId.Name = "comboBoxClientId";
            this.comboBoxClientId.Size = new System.Drawing.Size(200, 23);
            this.comboBoxClientId.TabIndex = 6;
            // 
            // RechercherIdInput
            // 
            this.RechercherIdInput.Location = new System.Drawing.Point(488, 304);
            this.RechercherIdInput.Name = "RechercherIdInput";
            this.RechercherIdInput.Size = new System.Drawing.Size(219, 23);
            this.RechercherIdInput.TabIndex = 7;
            // 
            // RechercherInput
            // 
            this.RechercherInput.Location = new System.Drawing.Point(713, 304);
            this.RechercherInput.Name = "RechercherInput";
            this.RechercherInput.Size = new System.Drawing.Size(75, 23);
            this.RechercherInput.TabIndex = 8;
            this.RechercherInput.Text = "Rechercher";
            this.RechercherInput.UseVisualStyleBackColor = true;
            this.RechercherInput.Click += new System.EventHandler(this.RechercherInput_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(484, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "Date Commande";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(482, 82);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 23);
            this.textBox3.TabIndex = 10;
            this.textBox3.Text = "ID du Client";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(488, 264);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(139, 23);
            this.textBox4.TabIndex = 11;
            this.textBox4.Text = "Rechercher Client par Id";
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(639, 388);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 12;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(53, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 39);
            this.button1.TabIndex = 13;
            this.button1.Text = "Add Product To Commande";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PasserCommande
            // 
            this.PasserCommande.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PasserCommande.Location = new System.Drawing.Point(322, 392);
            this.PasserCommande.Name = "PasserCommande";
            this.PasserCommande.Size = new System.Drawing.Size(231, 35);
            this.PasserCommande.TabIndex = 14;
            this.PasserCommande.Text = "Passer Commande";
            this.PasserCommande.UseVisualStyleBackColor = true;
            this.PasserCommande.Click += new System.EventHandler(this.PasserCommande_Click);
            // 
            // FormCommandes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PasserCommande);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.RechercherInput);
            this.Controls.Add(this.RechercherIdInput);
            this.Controls.Add(this.comboBoxClientId);
            this.Controls.Add(this.Supprimer);
            this.Controls.Add(this.Ajouter);
            this.Controls.Add(this.dateTimeCommande);
            this.Controls.Add(this.dataGridViewCommande);
            this.Controls.Add(this.dataGridViewClient);
            this.Name = "FormCommandes";
            this.Text = "FormCommandes";
            this.Load += new System.EventHandler(this.FormCommandes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCommande)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridViewClient;
        private DataGridView dataGridViewCommande;
        private DateTimePicker dateTimeCommande;
        private Button Ajouter;
        private Button Supprimer;
        private ComboBox comboBoxClientId;
        private TextBox RechercherIdInput;
        private Button RechercherInput;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button exit;
        private Button button1;
        private Button PasserCommande;
    }
}