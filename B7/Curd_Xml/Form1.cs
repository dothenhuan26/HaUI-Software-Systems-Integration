using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curd_Xml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataUtil data = new DataUtil();



        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }


        private void DisplayData()
        {
            dataGridView1.DataSource = data.GetAllStudents();
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 200;
            lblCount.Text = dataGridView1.Rows.Count + "";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string city = txtCity.Text;
            List<Student> li = data.FindByCity(city);
            if(li.Count>0)
            {
                dataGridView1.DataSource = li;
                lblCount.Text = dataGridView1.Rows.Count + "";
            } else
            {
                MessageBox.Show("Không tìm thấy sinh viên nào", "Thông báo");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.id = txtId.Text;
            s.name = txtName.Text;
            s.age = txtAge.Text;
            s.city = txtCity.Text;
            data.AddStudent(s);
            ClearTextBoxs();
            DisplayData();
        }

        private void ClearTextBoxs()
        {
            txtId.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtCity.Clear();
            ActiveControl = txtId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void GetAStudent(object sender, DataGridViewCellEventArgs e)
        {
            Student s = (Student)dataGridView1.CurrentRow.DataBoundItem;
            txtId.Text = s.id;
            txtName.Text = s.name;
            txtAge.Text = s.age;
            txtCity.Text = s.city;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.id = txtId.Text;
            s.name = txtName.Text;
            s.age = txtAge.Text;
            s.city = txtCity.Text;
            bool kt = data.UpdateStudent(s);
            if (!kt)
            {
                MessageBox.Show("Khong cap nhat duoc sinh vien co id=" + s.id);
                return;
            }
            DisplayData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxs();
        }

        private void btnFindByID_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            List<Student> li = new List<Student>();
            Student s = data.FindByID(id);
            if (s != null)
            {
                li.Add(s);
                dataGridView1.DataSource = li;
                lblCount.Text = dataGridView1.Rows.Count + "";
                txtId.Text = s.id;
                txtAge.Text = s.age;
                txtCity.Text = s.city;
                txtName.Text = s.name;
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên có id=" + id);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắc chắn xóa?", "Thông báo", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (d == DialogResult.Yes)
            {
                bool kt = data.DeleteStudent(txtId.Text);
                if (!kt)
                {
                    MessageBox.Show("Có lỗi khi xóa", "Thông báo");
                    return;
                }
                DisplayData();
                ClearTextBoxs();
            }
        }


    }
}
