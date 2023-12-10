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
    public partial class LoginForm : Form
    {
        public DbContext dbContext = new DbContext();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            if (dbContext.Login(this.pseudo.Text, this.password.Text))
            {
                this.Hide();
                MenuForm menu = new MenuForm(dbContext);
                menu.Show();
            }
            else{
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "the pseudo or the password are not correct. Please Retry";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                //if (result == System.Windows.Forms.DialogResult.Yes)
                //{
                //    // Closes the parent form.
                //    this.Close();
                //}
            }            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
