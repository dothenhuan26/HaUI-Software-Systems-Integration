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

namespace _2021600381_DoTheNhuan_call
{
    public partial class EmployeeInfo : Form
    {

        private int ID_TMP;
        private List<Employee> employees;

        HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("http://192.168.110.205:2626/api/")
        };



        public EmployeeInfo()
        {
            InitializeComponent();
        }

        private void EmployeeInfo_Load(object sender, EventArgs e)
        {
            employees = GetEmployees();
            renderData.DataSource = employees;
        }

        private List<Employee> GetEmployees()
        {
            var response = client.GetAsync("Employee").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<Employee>>().Result;
            }
            return null;
        }


        private bool Create(Employee employee)
        {
            var response = client.PostAsJsonAsync("Employee/Create", employee).Result;
            return response.IsSuccessStatusCode;
        }

        private bool Update(Employee employee)
        {
            var response = client.PutAsJsonAsync("Employee/Update", employee).Result;
            return response.IsSuccessStatusCode;
        }

        private bool Delete(int id)
        {
            var response = client.DeleteAsync($"Employee/Delete?id={id}").Result;
            return response.IsSuccessStatusCode;
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee()
            {
                Code = txtCode.Text,
                FullName = txtFullName.Text,
                BirthDate = Convert.ToDateTime(txtBirthDate.Value),
                Gender = Convert.ToBoolean(radMale.Checked)
            };

            if (Create(employee))
            {
                employees = GetEmployees();
                renderData.DataSource = employees;
                clearInput();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại!");
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Employee employee = employees.FirstOrDefault(x => x.ID == ID_TMP);
            if (employee != null)
            {
                employee.Code = txtCode.Text;
                employee.FullName = txtFullName.Text;
                employee.BirthDate = Convert.ToDateTime(txtBirthDate.Value);
                employee.Gender = Convert.ToBoolean(radMale.Checked);

                if (Update(employee))
                {
                    employees = GetEmployees();
                    renderData.DataSource = employees;
                    clearInput();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại!", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên!", "Thông báo");
            }
        }

        private void renderData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = renderData.CurrentRow;
            ID_TMP = Convert.ToInt32(row.Cells["ID"].Value);
            txtCode.Text = row.Cells["Code"].Value.ToString().Trim();
            txtFullName.Text = row.Cells["FullName"].Value.ToString().Trim();
            txtBirthDate.Text = row.Cells["BirthDate"].Value.ToString();
            if (Convert.ToBoolean(row.Cells["Gender"].Value)) radMale.Checked = true;
            else radFemale.Checked = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (Delete(ID_TMP))
                {
                    employees = GetEmployees();
                    renderData.DataSource = employees;
                    clearInput();
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại!", "Thông báo");
                    employees = GetEmployees();
                    renderData.DataSource = employees;
                    clearInput();
                }
            }
        }

        private void clearInput()
        {
            txtCode.Clear();
            txtFullName.Clear();
            radMale.Checked = true;
            txtBirthDate.Value = DateTime.Now;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();
            Employee emp = employees.FirstOrDefault(x => x.Code.Trim() == code);

            if (emp != null)
            {
                List<Employee> li = new List<Employee>();
                li.Add(emp);
                renderData.DataSource = li;
                clearInput();
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên!", "Thông báo");
            }
        }
    }
}
