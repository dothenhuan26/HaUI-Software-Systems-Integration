using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataUtil data = new DataUtil();

        private void renderData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            render();
        }

        public void render()
        {
            renderData.DataSource = data.GetAllXes();
            renderData.Columns[0].HeaderText = "Hãng xe";
            renderData.Columns[1].HeaderText = "Dòng xe";
            renderData.Columns[2].HeaderText = "Phiên bản";
            renderData.Columns[3].HeaderText = "Động cơ";
            renderData.Columns[4].HeaderText = "Gía";
            renderData.Columns[0].Width = 100;
            renderData.Columns[1].Width = 100;
            renderData.Columns[2].Width = 100;
            renderData.Columns[3].Width = 100;
            renderData.Columns[4].Width = 100;
        }

        public void clear()
        {
            txtDongCo.Clear();
            txtDongXe.Clear();
            txtGia.Clear();
            txtHangXe.Clear();
            txtPhienBan.Clear();
            ActiveControl = txtHangXe;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Xe xe = new Xe();
            xe.hangxe = txtHangXe.Text;
            xe.dongxe = txtDongXe.Text;
            xe.dongco = txtDongCo.Text;
            xe.phienban = txtPhienBan.Text;
            xe.gia = txtGia.Text;

            bool kt = data.AddXe(xe);
            if (!kt)
            {
                MessageBox.Show("Thông tin đã tồn tại!", "Thông báo");
                clear();
                return;
            }
            MessageBox.Show("Thêm xe thành công!", "Thông báo");
            render();
            clear();
        }

        private void renderData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Xe xe = (Xe)renderData.CurrentRow.DataBoundItem;
            txtDongCo.Text = xe.dongco;
            txtHangXe.Text = xe.hangxe;
            txtPhienBan.Text = xe.phienban;
            txtGia.Text = xe.gia;
            txtDongXe.Text = xe.dongxe;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Xe xe = (Xe)renderData.CurrentRow.DataBoundItem;
            DialogResult d = MessageBox.Show("Chắc chắn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (d == DialogResult.Yes)
            {
                bool kt = data.DeleteXe(xe);
                if (kt)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    clear();
                    render();
                    return;
                }
                MessageBox.Show("Xóa thất bại!", "Thông báo");

            }
            else
            {
                return;
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string hangxe = txtHangXe.Text;
            List<Xe> li = data.FindByHangXe(hangxe);
            if (li.Count > 0)
            {
                renderData.DataSource = li;
            }
            else
            {
                MessageBox.Show("Không tìm thấy xe của hãng");
                render();
            }
        }
    }
}
