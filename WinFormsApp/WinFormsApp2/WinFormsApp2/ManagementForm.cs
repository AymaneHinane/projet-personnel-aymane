using ADO.Net.Client.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.DB;

namespace WinFormsApp2
{
    public partial class ManagementForm : Form
    {
        public string TableName;
        DbContext dbContext;
        public ManagementForm(string tableName, DbContext _dbContext)
        {
            TableName = tableName;
            dbContext = _dbContext;
            InitializeComponent();
        }



        private void ManagementForm_Load(object sender, EventArgs e)
        {
            dbContext.GetDataGenerique(TableName);
            this.dataGridView.DataSource = dbContext.DataSet.Tables[TableName];

            if (TableName != "Facture")
            {
                LoadInputData();
                LoadInputFilter();
            }
        }

        private void LoadInputFilter()
        {
            int Point_x_label = 10, Point_y_label = 10;
            int Point_x_textBox = 10, Point_y_textBox = 30;
            DataTable table = dbContext.DataSet.Tables[TableName];

            foreach (DataColumn column in table.Columns)
            {

                Label Mylablel = new Label();
                Mylablel.Location = new Point(Point_x_label, Point_y_label);
                Mylablel.Text = column.ColumnName;
                Mylablel.AutoSize = true;
                this.Controls.Add(Mylablel);

                if (column.DataType != typeof(DateTime))
                {
                    TextBox Mytextbox = new TextBox();
                    Mytextbox.Location = new Point(Point_x_textBox, Point_y_textBox);
                    Mytextbox.AutoSize = true;
                    Mytextbox.Name = column.ColumnName+"_Filter";
                    this.Controls.Add(Mytextbox);
                }
                else
                {
                    DateTimePicker date = new DateTimePicker();
                    date.Location = new Point(Point_x_textBox, Point_y_textBox);
                    date.AutoSize = true;
                    date.Name = column.ColumnName+"_Filter";
                    this.Controls.Add(date);
                }

                 Point_x_label += 110;
                 Point_x_textBox += 110;
            }


        }

        private void LoadInputData()
        {
            int Point_x_label = 96, Point_y_label = 290;
            int Point_x_textBox = 187, Point_y_textBox = 290;

            DataTable table = dbContext.DataSet.Tables[TableName];

            foreach (DataColumn column in table.Columns)
            {

                if (column.ColumnName != "Id" )
                {
                    Label Mylablel = new Label();
                    Mylablel.Location = new Point(Point_x_label, Point_y_label);
                    Mylablel.Text = column.ColumnName;
                    Mylablel.AutoSize = true;
                    this.Controls.Add(Mylablel);

                    if (column.DataType != typeof(DateTime))
                    {
                        TextBox Mytextbox = new TextBox();
                        Mytextbox.Location = new Point(Point_x_textBox, Point_y_textBox);
                        Mytextbox.AutoSize = true;
                        Mytextbox.Name = column.ColumnName;
                        this.Controls.Add(Mytextbox);
                    }
                    else if(column.DataType == typeof(DateTime))
                    {
                        DateTimePicker date = new DateTimePicker();
                        date.Location = new Point(Point_x_textBox, Point_y_textBox);
                        date.AutoSize = true;
                        date.Name = column.ColumnName;
                        this.Controls.Add(date);
                    }

                    Point_y_label += 25;
                    Point_y_textBox += 25;
                }
                
            }

           
        }

        private void Save_Click(object sender, EventArgs e)
        {
            DataTable table = dbContext.DataSet.Tables[TableName];
            Dictionary<string, Object> newData = new();

           if (TableName != "Facture")
            foreach (DataColumn column in table.Columns)
            {
                if (column.ColumnName != "Id" && column.DataType != typeof(DateTime))
                {
                    TextBox tb = Controls.Find(column.ColumnName, true).FirstOrDefault() as TextBox;

                    if (tb != null  )
                    {
                            if (!String.IsNullOrEmpty(tb.Text))
                            {
                                Type T = column.DataType;

                                if (T == null)
                                    return;

                                try
                                {
                                    var converter = TypeDescriptor.GetConverter(T);
                                    if (converter != null)
                                    {
                                       var d = converter.ConvertFromString(tb.Text);
                                    }
                                }
                                catch (ArgumentException)
                                {
                                    string message = $"the type of input {column.ColumnName} are not correct. Please Retry";
                                    string caption = "Error Detected in Input";
                                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                    DialogResult result;
                                    result = MessageBox.Show(message, caption, buttons);
                                    return;
                                }


                                bool isNumber = int.TryParse(tb.Text, out var number_val);
                                bool isDecimal = int.TryParse(tb.Text, out var decimal_val);
                                if(isNumber)
                                  newData.Add(column.ColumnName,number_val);
                                else if(isDecimal)
                                    newData.Add(column.ColumnName, decimal_val);
                                else
                                    newData.Add(column.ColumnName, tb.Text);
                            }
                    }

                }

                if(column.DataType == typeof(DateTime))
                {
                        DateTimePicker date  = Controls.Find(column.ColumnName, true).FirstOrDefault() as DateTimePicker;

                        if(date != null)
                        {
                            newData.Add(column.ColumnName, DateTime.Parse(date.Text));
                        }
                }

            }

            if (newData.Count > 0 && newData.Count == (table.Columns.Count-1))
            {
                dbContext.AddDataGenerique(TableName, newData);
                dbContext.GetDataGenerique(TableName);
            }
        }

        private void quitter_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuForm menuForm = new MenuForm(dbContext);
            menuForm.Show();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                string id = dataGridView.CurrentRow.Cells["Id"].Value.ToString();
                dbContext.DeleteDataGenerique(TableName, id);
                dbContext.GetDataGenerique(TableName);
            }
        }

        private void Rechercher_Click(object sender, EventArgs e)
        {

            DataTable table = dbContext.DataSet.Tables[TableName];

            Dictionary<string, Object> FilterData = new();

            foreach (DataColumn column in table.Columns)
            {
                if (column.DataType != typeof(DateTime))
                {
                    string ctlToFind = column.ColumnName;
                    TextBox tb = Controls.Find(ctlToFind + "_Filter", true).FirstOrDefault() as TextBox;
                    if (tb.Text != "")
                    {
                        Type T = column.DataType;

                        if (T == null)
                            return;

                        try
                        {
                            var converter = TypeDescriptor.GetConverter(T);
                            if (converter != null)
                            {
                                var d = converter.ConvertFromString(tb.Text);
                            }
                        }
                        catch (ArgumentException)
                        {
                            string message = $"the type of input {column.ColumnName} are not correct. Please Retry";
                            string caption = "Error Detected in Input";
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result;
                            result = MessageBox.Show(message, caption, buttons);
                            return;
                        }

                        bool isNumber = int.TryParse(tb.Text, out var number_val);
                        bool isDecimal = int.TryParse(tb.Text, out var decimal_val);
                        if (isNumber)
                            FilterData.Add(column.ColumnName, number_val);
                        else if (isDecimal)
                            FilterData.Add(column.ColumnName, decimal_val);
                        else
                            FilterData.Add(column.ColumnName, tb.Text);
                    }
                }


                if (column.DataType == typeof(DateTime))
                {
                    DateTimePicker date = Controls.Find(column.ColumnName+"_Filter", true).FirstOrDefault() as DateTimePicker;

                    if (date != null)
                    {
                        FilterData.Add(column.ColumnName, DateTime.Parse(date.Text));
                    }
                }
            }

            if (FilterData.Count > 0)
            {
                dbContext.FilterDataGenerique(TableName, FilterData);

            }
            else
            {
                dbContext.GetDataGenerique(TableName);
            }

        }



        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataTable table = dbContext.DataSet.Tables[TableName];


            foreach (DataColumn column in table.Columns)
            {
                if (column.ColumnName != "Id")
                {
                    TextBox tb = Controls.Find(column.ColumnName, true).FirstOrDefault() as TextBox;
                    if(tb != null)
                        //if(! String.IsNullOrEmpty(tb.Text))
                           tb.Text = dataGridView.CurrentRow.Cells[column.ColumnName].Value.ToString();
                }
            }

        }

        private void update_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
                return;

            DataTable table = dbContext.DataSet.Tables[TableName];
            string id = dataGridView.CurrentRow.Cells["Id"].Value.ToString();
            Dictionary<string, Object> updatedata = new();

            if(TableName != "Facture")
             foreach (DataColumn column in table.Columns)
             {
                if (column.ColumnName != "Id" && column.DataType != typeof(DateTime))
                {
                    TextBox tb = Controls.Find(column.ColumnName, true).FirstOrDefault() as TextBox;

                        if (tb != null)
                            if (!String.IsNullOrEmpty(tb.Text))
                            {
                                bool isNumber = int.TryParse(tb.Text, out var number_val);
                                bool isDecimal = int.TryParse(tb.Text, out var decimal_val);
                                if (isNumber)
                                    updatedata.Add(column.ColumnName, number_val);
                                else if (isDecimal)
                                    updatedata.Add(column.ColumnName, decimal_val);
                                else
                                    updatedata.Add(column.ColumnName, tb.Text);
                            }
                }


                if (column.DataType == typeof(DateTime))
                {
                    DateTimePicker date = Controls.Find(column.ColumnName, true).FirstOrDefault() as DateTimePicker;

                    if (date != null)
                    {
                        updatedata.Add(column.ColumnName, DateTime.Parse(date.Text));
                    }
                }
            }

            if (updatedata.Count > 0)
            {
                dbContext.UpdateDataGenrique(TableName, id, updatedata);
                dbContext.GetDataGenerique(TableName);
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            DataTable table = dbContext.DataSet.Tables[TableName];

            foreach (DataColumn column in table.Columns)
            {
                if (column.ColumnName != "Id")
                {
                    TextBox tb = Controls.Find(column.ColumnName, true).FirstOrDefault() as TextBox;
                    if(tb != null)
                        if(!string.IsNullOrWhiteSpace(tb.Text))
                            tb.Text = string.Empty;
                }
            }
        }

        private void Reload_Click(object sender, EventArgs e)
        {
            dbContext.GetDataGenerique(TableName);
        }
    }
}