using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAPI
{
    public partial class EmployeeInfo : Form
    {
        private List<Employee> employees;
        private int ID_TMP;
        public EmployeeInfo()
        {
            InitializeComponent();
        }

        HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("http://192.168.110.205:2222/api/")
        };

        private List<Employee> GetEmployees()
        {

            var response = client.GetAsync("employees").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<Employee>>().Result;
            }
            return null;
        }


        private bool Add(Employee employee)
        {
            var response = client.PostAsJsonAsync("employees", employee).Result;
            return response.IsSuccessStatusCode;
        }

        private bool Update(Employee employee)
        {
            var response = client.PutAsJsonAsync("employees", employee).Result;
            return response.IsSuccessStatusCode;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            employees = GetEmployees();
            renderData.DataSource = GetEmployees();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee()
            {
                Code = txtCode.Text,
                FullName = txtFullName.Text,
                BirthDate = txtBirthDate.Value,
                Gender = radMale.Checked
            };
            if (Add(employee))
            {
                employees = GetEmployees();
                renderData.DataSource = employees;
            }
            else MessageBox.Show("Khong them duoc nhan vien!");
        }

        //private void renderData_SelectionChanged(object sender, EventArgs e)
        //{
        //    var row = renderData.CurrentRow;
        //    txtCode.Text = row.Cells["Code"].Value.ToString();
        //    txtBirthDate.Value = Convert.ToDateTime(row.Cells["BirthDate"].Value);
        //    txtFullName.Text = row.Cells["FullName"].Value.ToString();
        //    if (Convert.ToBoolean(row.Cells["Gender"].Value))
        //    {
        //        radMale.Checked = true;
        //    }
        //    else
        //    {
        //        radFemale.Checked = true;
        //    }

        //}

        private void renderData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = renderData.CurrentRow;
            ID_TMP = Convert.ToInt32(row.Cells["ID"].Value);
            txtCode.Text = row.Cells["Code"].Value.ToString();
            txtBirthDate.Value = Convert.ToDateTime(row.Cells["BirthDate"].Value);
            txtFullName.Text = row.Cells["FullName"].Value.ToString();
            if (Convert.ToBoolean(row.Cells["Gender"].Value)) radMale.Checked = true;
            else radFemale.Checked = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Employee employee = employees.FirstOrDefault(x => x.ID == ID_TMP);
            if (employee != null)
            {
                employee.FullName = txtFullName.Text;
                employee.BirthDate = Convert.ToDateTime(txtBirthDate.Value);
                employee.Gender = radMale.Checked;
                if (Update(employee))
                {
                    employees = GetEmployees();
                    renderData.DataSource = employees;
                }
                else
                {
                    MessageBox.Show("Khong sua duoc nhan vien!");
                }
            }
            else
            {
                MessageBox.Show("Khong tim thay nhan vien!");
            }
        }
    }
}
