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

namespace _2021600381_DoTheNhuan_Call
{
    public partial class Form1 : Form
    {

        List<SanPham> sanphams;
        int ID_TMP;

        HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("http://192.168.0.100:5051/api/")
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sanphams = GetSanPhams();
            renderData.DataSource = sanphams;
        }

        private List<SanPham> GetSanPhams()
        {
            var response = client.GetAsync("SanPham").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<SanPham>>().Result;
            }
            return null;
        }

        private bool Create(SanPham sanpham)
        {
            var response = client.PostAsJsonAsync("SanPham", sanpham).Result;
            return response.IsSuccessStatusCode;
        }

        private bool Update(SanPham sanpham)
        {
            var response = client.PutAsJsonAsync("SanPham", sanpham).Result;
            return response.IsSuccessStatusCode;
        }

        private bool Delete(int id)
        {
            var response = client.DeleteAsync($"SanPham/Delete?id={id}").Result;
            return response.IsSuccessStatusCode;
        }

        private void renderData_SelectionChanged(object sender, EventArgs e)
        {
            var row = renderData.CurrentRow;
            txtTenSanPham.Text = row.Cells["TenSanPham"].Value.ToString();
            txtSoLuongBan.Text = row.Cells["SoLuongBan"].Value.ToString();
            txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
            txtTienBan.Text = row.Cells["TienBan"].Value.ToString();
            ID_TMP = Convert.ToInt32(row.Cells["MaSP"].Value.ToString());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SanPham sp = new SanPham()
            {
                DonGia = Convert.ToDouble(txtDonGia.Text),
                SoLuongBan = Convert.ToDouble(txtSoLuongBan.Text),
                TienBan = Convert.ToDouble(txtTienBan.Text),
                TenSanPham = txtTenSanPham.Text
            };
            if (Create(sp))
            {
                sanphams = GetSanPhams();
                renderData.DataSource = sanphams;
                clearInput();
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại!", "Thông báo!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SanPham sp = sanphams.FirstOrDefault(x => x.MaSP == ID_TMP);

            if (sp != null)
            {
                sp.TenSanPham = txtTenSanPham.Text;
                sp.DonGia = Convert.ToDouble(txtDonGia.Text);
                sp.SoLuongBan = Convert.ToDouble(txtSoLuongBan.Text);
                sp.TienBan = Convert.ToDouble(txtTienBan.Text);

                if (Update(sp))
                {
                    sanphams = GetSanPhams();
                    renderData.DataSource = sanphams;
                    clearInput();
                }
                else
                {
                    MessageBox.Show("Sửa sản phẩm thất bại!", "Thông báo!");
                }
            }
            else
            {
                MessageBox.Show("Sản phẩm không tồn tại!", "Thông báo!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (Delete(ID_TMP))
                {
                    sanphams = GetSanPhams();
                    renderData.DataSource = sanphams;
                    clearInput();
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm thất bại!", "Thông báo!");
                }
            }
        }

        private void clearInput()
        {
            txtDonGia.Clear();
            txtSoLuongBan.Clear();
            txtTenSanPham.Clear();
            txtTienBan.Clear();
        }

    }
}
