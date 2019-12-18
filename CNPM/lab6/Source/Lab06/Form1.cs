using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab06
{
    public partial class Form1 : Form
    {
        private StudentDAO studentDao;
        public Form1()
        {
            studentDao = new StudentDAO();
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Em đã thay đổi connectionString cho phù hợp với máy mình chưa?","Connection String" , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoadData();
                SetEditingMode(false);
            }
            else
            {
                MessageBox.Show("Vậy thì thay đi rồi thử lại");
                Hide();
                Application.Exit();
            }
            
        }

        private void LoadData()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JRNC7GN\SQLEXPRESS;Initial Catalog=Lab06;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from student", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
             
            DataTable table = new DataTable();
            adapter.Fill(table);
            conn.Close();

            gridStudents.DataSource = table;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridStudents.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a student first");
                return;
            }
            int index = gridStudents.SelectedCells[0].RowIndex;
            if (index < 0 || index >= gridStudents.RowCount)
            {
                MessageBox.Show("Please select a student first");
                return;
            }

            DataGridViewRow row = gridStudents.Rows[index];
            int id = int.Parse(row.Cells[0].Value.ToString());
            String name = row.Cells[1].Value.ToString();


            DialogResult result = MessageBox.Show("Xóa sinh viên " + name + "?", "Connection String", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }

            if (DeleleById(id))
            {
                gridStudents.ClearSelection();
                LoadData();
                btnClear_Click(null, null);
                SetEditingMode(false);
            }
            else
            {
                MessageBox.Show("Xóa không thành công");
            }
        }

        private bool DeleleById(int id)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JRNC7GN\SQLEXPRESS;Initial Catalog=Lab06;Integrated Security=True");
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("delete from student where maso = @id", conn);

            //SqlParameter param1 = new SqlParameter("@id", id);
            //SqlParameter[] parameters = { param1 }; // you may add more params

            //cmd.Parameters.AddRange(parameters);
            //int rows = cmd.ExecuteNonQuery();
            //conn.Close();

            //return rows == 1;
            return studentDao.DeleteById(id);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtEmail.Text = "";
            rbMale.Checked = true;
            rbFemale.Checked = false;
            dtBirth.Value = DateTime.Now;
            SetEditingMode(false);
            txtName.Focus();
        }

        private void SetEditingMode(bool enable)
        {
            if (!enable)
            {
                gridStudents.ClearSelection();
            }
            btnAdd.Enabled = !enable;
            btnClear.Enabled = true;
            btnDelete.Enabled = enable;
            btnUpdate.Enabled = enable;
        }

        private void gridStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0 || index >= gridStudents.RowCount)
            {
                return;
            }

            DataGridViewRow row = gridStudents.Rows[index];
            String name = Convert.ToString(row.Cells[1].Value);
            DateTime birth = Convert.ToDateTime(row.Cells[2].Value);
            bool isMale = Convert.ToBoolean(row.Cells[3].Value);
            String email = Convert.ToString(row.Cells[4].Value);

            // update UI
            txtName.Text = name;
            txtEmail.Text = email;
            dtBirth.Value = birth;
            rbMale.Checked = isMale;
            rbFemale.Checked = !isMale;

            SetEditingMode(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            String name = txtName.Text;
            Boolean isMale = rbMale.Checked;

            DialogResult result = MessageBox.Show("Thêm sinh viên " + name + "?", "Connection String", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }

          

            String email = txtEmail.Text;
            DateTime birth = dtBirth.Value;

            Student student = new Lab06.Student(name, birth, isMale, email);
            if (AddStudent(student))
            {
                gridStudents.ClearSelection();
                LoadData();
                btnClear_Click(null, null);
                SetEditingMode(false);
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
        }

        public bool AddStudent(Student student)
        {
            return studentDao.AddStudent(student);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (gridStudents.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a student first");
                return;
            }
            int index = gridStudents.SelectedCells[0].RowIndex;
            if (index < 0 || index >= gridStudents.RowCount)
            {
                MessageBox.Show("Please select a student first");
                return;
            }

            DataGridViewRow row = gridStudents.Rows[index];
            int id = int.Parse(row.Cells[0].Value.ToString());

            String name = txtName.Text;
            Boolean isMale = rbMale.Checked;

            DialogResult result = MessageBox.Show("Cập nhật thông tin sinh viên " + name + "?", "Connection String", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }



            String email = txtEmail.Text;
            DateTime birth = dtBirth.Value;

            Student student = new Lab06.Student(id,name, birth, isMale, email);
            if (UpdateStudent(student))
            {
                gridStudents.ClearSelection();
                LoadData();
                btnClear_Click(null, null);
                SetEditingMode(false);
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công");
            }
        }

        public bool UpdateStudent(Student student)
        {
            return studentDao.UpdateStudent(student);
        }
    }
}
