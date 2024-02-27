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

namespace CuoiKyAPI
{
    public partial class Form1 : Form
    {

        List<NhanVien> nhanviens;
        int ID_TMP;

        HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("http://192.168.0.100:2508/api/")
        };

        public Form1()
        {
            InitializeComponent();
        }

        private List<NhanVien> GetNhanViens()
        {
            var response = client.GetAsync("NhanVien").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<NhanVien>>().Result;
            }
            return null;
        }

        private bool Create(NhanVien nhanvien)
        {
            var response = client.PostAsJsonAsync("NhanVien/Create", nhanvien).Result;
            return response.IsSuccessStatusCode;
        }

        private bool Update(NhanVien nhanvien)
        {
            var response = client.PutAsJsonAsync("NhanVien/Update", nhanvien).Result;
            return response.IsSuccessStatusCode;
        }

        private bool Delete(int id)
        {
            var response = client.DeleteAsync($"NhanVien?id={id}").Result;
            return response.IsSuccessStatusCode;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nhanviens = GetNhanViens();
            renderData.DataSource = nhanviens;
        }

        private void renderData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = renderData.CurrentRow;

            txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
            txtTrinhDo.Text = row.Cells["TrinhDo"].Value.ToString();
            txtLuong.Text = row.Cells["Luong"].Value.ToString();
            ID_TMP = Convert.ToInt32(row.Cells["MaNV"].Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NhanVien nhanvien = new NhanVien()
            {
                HoTen = txtHoTen.Text,
                Luong = Convert.ToInt32(txtLuong.Text),
                TrinhDo = txtTrinhDo.Text,
            };

            if (Create(nhanvien))
            {
                nhanviens = GetNhanViens();
                renderData.DataSource = nhanviens;
            }
            else
            {
                MessageBox.Show("Khong them duoc nhan vien!", "Thong bao");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            NhanVien nhanvien = nhanviens.FirstOrDefault(x => x.MaNV == ID_TMP);
            if (nhanvien != null)
            {
                nhanvien.HoTen = txtHoTen.Text;
                nhanvien.Luong = Convert.ToInt32(txtLuong.Text);
                nhanvien.TrinhDo = txtTrinhDo.Text;
                if (Update(nhanvien))
                {
                    nhanviens = GetNhanViens();
                    renderData.DataSource = nhanviens;
                }
            }
            else
            {
                MessageBox.Show("Nhan vien khong ton tai!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co chac chan xoa?", "Thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (Delete(ID_TMP))
                {
                    nhanviens = GetNhanViens();
                    renderData.DataSource = nhanviens;
                }
                else
                {
                    MessageBox.Show("Khong xoa duoc nhan vien!");
                }
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string FullName = txtHoTen.Text.Trim();
            List<NhanVien> found = GetNhanViens().Where(x => x.HoTen.Contains(FullName)).ToList();

            if (found.Count == 0)
            {
                MessageBox.Show("Khong tim thay nhan vien!");
                return;
            }
            renderData.DataSource = found;
        }
    }
}
