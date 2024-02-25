using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumeAPI
{
    public partial class EmployeeInfo : Form
    {
        private List<Employee> employees;
        private int iD;
        public EmployeeInfo()
        {
            InitializeComponent();
        }
        private List<Employee> GetEmployees()
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:6034/api/")
            };
            var respone = client.GetAsync("employee").Result;
            if (respone.IsSuccessStatusCode)
            {
                return respone.Content.ReadAsAsync<List<Employee>>().Result;
            }
            else
                return null;
        }
        private bool Add(Employee employee)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:6034/api/")
            };
            var respone = client.PostAsJsonAsync("employee", employee).Result;
            return respone.IsSuccessStatusCode;
        }
        private bool Update(Employee employee)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:6034/api/")
                //BaseAddress = new Uri("http://localhost:52031/api/")
            };
            var respone = client.PutAsJsonAsync("employee", employee).Result;
            return respone.IsSuccessStatusCode;
        }
        private bool Delete(int iD)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:6034/api/")
                //BaseAddress = new Uri("http://localhost:52031/api/")
            };
            var respone = client.DeleteAsync($"employee?ID={iD}").Result;
            return respone.IsSuccessStatusCode;
        }
        private void EmployeeInfo_Load(object sender, EventArgs e)
        {
            employees = GetEmployees();
            dgvEmployeeInfo.DataSource = employees;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee()
            {
                Code = txtCode.Text,
                FullName = txtFullName.Text,
                BirthDate = dtpBirthDate.Value,
                Gender = rbtMale.Checked
            };
            if (Add(employee))
            {
                employees = GetEmployees();
                dgvEmployeeInfo.DataSource = GetEmployees();
            }
            else
                MessageBox.Show("Không thêm được nhân viên");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Employee employee = employees.FirstOrDefault(emp => emp.ID == iD);
            employee.Code = txtCode.Text;
            employee.FullName = txtFullName.Text;
            employee.BirthDate = dtpBirthDate.Value;
            employee.Gender = rbtMale.Checked;
            if (Update(employee))
            {
                employees = GetEmployees();
                dgvEmployeeInfo.DataSource = employees;
            }   
            else
                MessageBox.Show("Không sửa được nhân viên");
        }

        private void dgvEmployeeInfo_SelectionChanged(object sender, EventArgs e)
        {
            var row = dgvEmployeeInfo.CurrentRow;
            iD = Convert.ToInt32(row.Cells["ID"].Value);
            txtCode.Text = row.Cells["Code"].Value.ToString();
            txtFullName.Text = row.Cells["FullName"].Value.ToString();
            dtpBirthDate.Value = Convert.ToDateTime(row.Cells["BirthDate"].Value);
            rbtMale.Checked = Convert.ToBoolean(row.Cells["Gender"].Value);
            rbtFemale.Checked = !Convert.ToBoolean(row.Cells["Gender"].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa nhân viên này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (Delete(iD))
                {
                    employees = GetEmployees();
                    dgvEmployeeInfo.DataSource = GetEmployees();
                } 
                else
                    MessageBox.Show("Không xóa được nhân viên");
            }
        }
    }
}
