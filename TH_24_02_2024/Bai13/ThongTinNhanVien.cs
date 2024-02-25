using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace Bai13
{
    public partial class ThongTinNhanVien : Form
    {
        private List<NhanVien> employees;

        public ThongTinNhanVien()
        {
            InitializeComponent();
        }

        private List<NhanVien> ShowEmployee()
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:50334/api/")
            };
            var response = client.GetAsync("nhanvien").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<NhanVien>>().Result;
            }
            else
                return null;
        }

        private bool Insert(NhanVien employee)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:50334/api/")
            };
            var response = client.PostAsJsonAsync("nhanvien", employee).Result;
            return response.IsSuccessStatusCode;
        }

        private bool Update(NhanVien employee)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:50334/api/")
            };
            var response = client.PutAsJsonAsync("nhanvien", employee).Result;
            return response.IsSuccessStatusCode;
        }
        private bool Delete(string ma)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:50334/api/")
            };
            var response = client.DeleteAsync($"nhanvien?Ma={ma}").Result;
            return response.IsSuccessStatusCode;
        }
        private void ThongTinNhanVien_Load(object sender, EventArgs e)
        {
            employees = ShowEmployee();
            dgvEmployee.DataSource = employees;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Insert(new NhanVien() { Ma = txtMa.Text, HoTen = txtHoTen.Text, NgaySinh = dtpNgaySinh.Value, GioiTinh = rbtNam.Checked ? "Nam" : "Nữ", HsLuong = Convert.ToDecimal(txtHsLuong.Text), MaDonVi = txtMaDonVi.Text }))
                dgvEmployee.DataSource = ShowEmployee();
            else
                MessageBox.Show("Không thêm được thông tin nhân viên");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            NhanVien employee = employees.FirstOrDefault(emp => emp.Ma == txtMa.Text);

            employee.HoTen = txtHoTen.Text;
            employee.NgaySinh = dtpNgaySinh.Value;
            employee.GioiTinh = rbtNam.Checked ? "Nam" : "Nữ";
            employee.HsLuong = Convert.ToDecimal(txtHsLuong.Text);
            employee.MaDonVi = txtMaDonVi.Text;
            if (Update(employee))
                dgvEmployee.DataSource = ShowEmployee();
            else
                MessageBox.Show("Không sửa được thông tin nhân viên");
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa thông tin của nhân viên này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (Delete(txtMa.Text))
                    dgvEmployee.DataSource = ShowEmployee();
                else
                    MessageBox.Show("Không sửa được thông tin nhân viên");
            }
        }
        private void dgvEmployee_SelectionChanged(object sender, EventArgs e)
        {
            var row = dgvEmployee.CurrentRow;
            txtMa.Text = row.Cells["Ma"].Value.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
            dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
            rbtNam.Checked = row.Cells["GioiTinh"].Value.ToString() == "Nam";
            rbtNu.Checked = !(row.Cells["GioiTinh"].Value.ToString() == "Nam");
            txtHsLuong.Text = row.Cells["HsLuong"].Value.ToString();
            txtMaDonVi.Text = row.Cells["MaDonVi"].Value.ToString();
        }
    }
}
