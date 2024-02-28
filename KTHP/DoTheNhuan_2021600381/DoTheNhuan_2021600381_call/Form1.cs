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

namespace DoTheNhuan_2021600381_call
{
    public partial class Form1 : Form
    {

        private List<Employee> employees;
        private int ID_TMP;

        HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("http://204.0.95.12:2802/api/")
        };


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
            var response = client.PutAsJsonAsync("Employee/Create", employee).Result;
            return response.IsSuccessStatusCode;
        }

        private bool Delete(int id)
        {
            var response = client.DeleteAsync($"Employee/Delete?id={id}").Result;
            return response.IsSuccessStatusCode;
        }

        private Employee Find(string code)
        {
            var response = client.GetAsync($"Employee/Find?code={code}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Employee>().Result;
            }
            return null;
        }

        private void clearInput()
        {
            txtCode.Clear();
            txtFullName.Clear();
            txtBirthDate.Value = DateTime.Now;
            radMale.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee()
            {
                Code = txtCode.Text,
                FullName = txtFullName.Text,
                BirthDate = Convert.ToDateTime(txtBirthDate.Value),
                Gender = Convert.ToBoolean(radMale.Checked),
            };
            if (validate())
            {
                if (Create(employee))
                {
                    employees = GetEmployees();
                    renderData.DataSource = employees;
                    clearInput();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại!", "Thông báo!");
                    clearInput();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var employee = employees.FirstOrDefault(x => x.ID == ID_TMP);
            if (employee != null)
            {
                employee.Code = txtCode.Text;
                employee.FullName = txtFullName.Text;
                employee.BirthDate = Convert.ToDateTime(txtBirthDate.Value);
                employee.Gender = Convert.ToBoolean(radMale.Checked);
                if (validate())
                {
                    if (Update(employee))
                    {
                        employees = GetEmployees();
                        renderData.DataSource = employees;
                        clearInput();
                    }
                    else
                    {
                        MessageBox.Show("Sửa nhân viên thất bại!", "Thông báo!");
                        clearInput();
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên!", "Thông báo!");
                clearInput();
            }

        }

        private void renderData_SelectionChanged(object sender, EventArgs e)
        {
            var row = renderData.CurrentRow;
            ID_TMP = Convert.ToInt32(row.Cells["ID"].Value);
            txtCode.Text = row.Cells["Code"].Value.ToString();
            txtFullName.Text = row.Cells["FullName"].Value.ToString();
            txtBirthDate.Value = Convert.ToDateTime(row.Cells["BirthDate"].Value);
            if (Convert.ToBoolean(row.Cells["Gender"].Value))
            {
                radMale.Checked = true;
            }
            else
            {
                radFemale.Checked = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (Delete(ID_TMP))
                {
                    employees = GetEmployees();
                    renderData.DataSource = employees;
                    clearInput();
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại!", "Thông báo!");
                    clearInput();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();
            var employee = Find(code);
            if (employee != null)
            {
                List<Employee> li = new List<Employee>();
                li.Add(employee);
                renderData.DataSource = li;
                clearInput();
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên!", "Thông báo");
                renderData.DataSource = employees;
                clearInput();
            }
        }

        private bool validate()
        {
            if (txtCode.Text.Trim().Length == 0)
            {
                MessageBox.Show("Code không được để trống!", "Thông báo!");
                return false;
            }
            if (txtFullName.Text.Trim().Length == 0)
            {
                MessageBox.Show("FullName không được để trống!", "Thông báo!");
                return false;
            }


            return true;
        }
    }
}
