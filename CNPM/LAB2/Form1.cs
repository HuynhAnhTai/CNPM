using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private SqlConnection con;
        private SqlDataAdapter adapter;
        private DataTable studentTable;
        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=DESKTOP-JRNC7GN\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");
            con.Open();
            adapter = new SqlDataAdapter("select * from student", con);  
        }

        private DataTable loadData()
        {
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            studentTable = loadData();
            dataGridStudent.DataSource = studentTable;
        }

        private void dataGridStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if(e.RowIndex<0 || e.RowIndex >= studentTable.Rows.Count)
            {
                return;
            }
            int index = e.RowIndex;
            DataRow row = studentTable.Rows[index];

            String name = (String)row[1];
            DateTime birth = (DateTime)row[2];
            bool gender = (bool)row[3];
            String email = (String)row[4];

            textBoxName.Text = name;
            radioFemale.Checked = gender;
            radioMale.Checked = !gender;
            dateTimePickerBirth.Value = birth;
            textBoxEmail.Text = email;

            buttonAdd.Visible = false;
            buttonUpdate.Visible = true;
            buttonDelete.Visible = true;
            buttonClear.Visible = true;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            radioFemale.Checked = false;
            radioMale.Checked = false;
            dateTimePickerBirth.Value = DateTime.Now;
            textBoxEmail.Text = "";

            buttonAdd.Visible = true;
            buttonUpdate.Visible = true;
            buttonDelete.Visible = true;
            buttonClear.Visible = true;
        }
    }
}
