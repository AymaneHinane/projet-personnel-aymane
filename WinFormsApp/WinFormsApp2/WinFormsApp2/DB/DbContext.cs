using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.DB
{
    public class DbContext
    {
        //Server=localhost,1433;Database=SHOP;User=sa;Password=fdalate1964
        private readonly string connetionString = @"Server=tcp:aymane.database.windows.net,1433;Initial Catalog=BDCommande;Persist Security Info=False;User ID=aymane;Password=One1ForAll.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection connection;
        public DataSet DataSet;
        public SqlDataAdapter dataAdapter;

        public DbContext()
        {
            connection = new SqlConnection(connetionString);
           
        }
        

        public void OpenConnection()
        {
            connection.Open();
        }
        public void CloseConnection()
        {
            connection.Close();
            
        }

        public void GetDataGenerique(string tableName)
        {
            // AddTableToDataSetGenerique();
            this.OpenConnection();

            DataSet.Tables[tableName].Clear();
            string request = $"select * from {tableName}";
            dataAdapter = new SqlDataAdapter(request, connection);
            dataAdapter.Fill(DataSet, tableName);

            this.CloseConnection();
        }

        public void DeleteDataGenerique(string tableName, string guid)
        {
            this.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            string sql3 = @$"delete from {tableName} where Id = '{guid}'";
            da.DeleteCommand = new SqlCommand(sql3, connection);
            da.DeleteCommand.ExecuteNonQuery();
            this.CloseConnection();
        }

        public bool Login(string pseudo, string password)
        {
            
            DataSet = new DataSet("DBCommand");

            DataTable Login = new DataTable("Login");
            Login.Columns.Add("Id", typeof(Guid));
            Login.Columns.Add("Pseudo", typeof(string));
            Login.Columns.Add("Password", typeof(string));


            DataSet.Tables.Add(Login);


            this.OpenConnection();
            dataAdapter = new SqlDataAdapter($"select * from Login where Pseudo='{pseudo}' and Password='{password}'", connection);
            dataAdapter.Fill(DataSet, "Login");
            this.CloseConnection();



            DataView dv = new DataView(DataSet.Tables["Login"]);

            if (dv.Count > 0)
            {
                AddTableToDataSetGenerique();
                return true;

            }
            return false;
            

        }

        public void AddTableToDataSetGenerique()
        {
            DataTable Customer = new DataTable("Customer");
            Customer.Columns.Add("Id", typeof(Guid));
            Customer.Columns.Add("FirstName", typeof(string));
            Customer.Columns.Add("LastName", typeof(string));
            Customer.Columns.Add("Adresse", typeof(string));        
            Customer.Columns.Add("NumTelephone", typeof(string));
            Customer.Columns.Add("DateNaissance", typeof(DateTime));

            DataTable Commande = new DataTable("Commande");
            Commande.Columns.Add("Id", typeof(Guid));
            Commande.Columns.Add("CustomerId", typeof(Guid));
            Commande.Columns.Add("OrderDate", typeof(DateTime));
            Commande.Columns.Add("Status", typeof(String));

            DataTable Product = new DataTable("Product");
            Product.Columns.Add("Id", typeof(Guid));
            Product.Columns.Add("Name", typeof(string));
            Product.Columns.Add("Price", typeof(decimal));
            Product.Columns.Add("CategorieID", typeof(Guid));
            Product.Columns.Add("Quantity", typeof(int));

            DataTable Departement = new DataTable("Departement");
            Departement.Columns.Add("Id", typeof(Guid));
            Departement.Columns.Add("Nom", typeof(string));

            DataTable Categorie = new DataTable("Categorie");
            Categorie.Columns.Add("Id", typeof(Guid));
            Categorie.Columns.Add("Nom", typeof(string));
            Categorie.Columns.Add("DepartementId", typeof(Guid));

            DataTable LigneCommande = new DataTable("LigneCommande");
            LigneCommande.Columns.Add("Id", typeof(Guid));
            LigneCommande.Columns.Add("CommandeId",typeof(Guid));
            LigneCommande.Columns.Add("ProductId",typeof(Guid));
            LigneCommande.Columns.Add("Quantity",typeof(int));


            DataTable Facture = new DataTable("Facture");
            Facture.Columns.Add("Id", typeof(Guid));
            Facture.Columns.Add("CustomerId", typeof(Guid));
            Facture.Columns.Add("Customer_FullName", typeof(string));
            Facture.Columns.Add("OrderDate", typeof(DateTime));
            Facture.Columns.Add("DeliveredDate", typeof(DateTime));
            Facture.Columns.Add("Order_Total", typeof(decimal));
            Facture.Columns.Add("OrderID", typeof(Guid));

            DataSet.Tables.Add(Customer);           
            DataSet.Tables.Add(Departement);
            DataSet.Tables.Add(Product);
            DataSet.Tables.Add(Commande);
            DataSet.Tables.Add(Categorie);
            DataSet.Tables.Add(LigneCommande);
            DataSet.Tables.Add(Facture);





        }


      

        public void AddDataGenerique(string tableName,Dictionary<string, Object> newData)
        {
            this.OpenConnection();
            
            SqlDataAdapter da = new SqlDataAdapter();

            string sql4 = @$"INSERT INTO {tableName} VALUES(NEWID()";

            foreach (KeyValuePair<string, Object> entry in newData)
            {
                              
                if (entry.Value is int || entry.Value is decimal)
                {

                    sql4 += $@",{entry.Value}";
                }
                else
                {
                    sql4 += $@",'{entry.Value}'";
                }
                             
            }
           
               
                sql4 += $");";
            


            da.InsertCommand = new SqlCommand(sql4, connection);
            da.InsertCommand.ExecuteNonQuery();

            this.CloseConnection();
        }

     


        public void FilterDataGenerique(string tableName,Dictionary<string,Object> FilterData)
        {
            string sql=$"select * ";


            sql += $" from {tableName} where ";

            foreach (KeyValuePair<string, Object> entry in FilterData)
            {
                if(entry.Value is int || entry.Value is decimal )
                  sql += $"{entry.Key}={entry.Value}";
                else
                   sql += $"{entry.Key}='{entry.Value}'";

                if (entry.Key != FilterData.Last().Key)
                {
                    sql += " and ";
                }
            }
            sql += ";";

            this.OpenConnection();
            DataSet.Tables[tableName].Clear();
            dataAdapter = new SqlDataAdapter(sql, connection);
            dataAdapter.Fill(DataSet, tableName);
            this.CloseConnection();

        }

        public void UpdateDataGenrique(string tableName,string guid,Dictionary<string,Object> UpdateData)
        {
            string sql = $"update {tableName} set ";

            foreach (KeyValuePair<string, Object> entry in UpdateData)
            {
                if (entry.Value is int || entry.Value is decimal)
                    sql += $"{entry.Key}={entry.Value}";
                else
                    sql += $"{entry.Key}='{entry.Value}'";

                if (entry.Key != UpdateData.Last().Key)
                {
                    sql += ",";
                }
            }
            sql += $" where Id='{guid}';";

            this.OpenConnection();
            DataSet.Tables[tableName].Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.UpdateCommand = new SqlCommand(sql, connection);
            da.UpdateCommand.ExecuteNonQuery();
            this.CloseConnection();

        }

        public void PasserCommande(string CommandeId)
        {
            string sql = $"EXECUTE dbo.CreateFacture '{CommandeId}'";
            this.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            da.UpdateCommand = new SqlCommand(sql, connection);
            da.UpdateCommand.ExecuteNonQuery();
            this.CloseConnection();
        }
    }
}
