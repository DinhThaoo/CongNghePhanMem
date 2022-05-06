using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienCNPM
{
    public partial class QuanLyCuaHang : Form
    {
        public QuanLyCuaHang()
        {
            InitializeComponent();
        }

        private void btnqlbanhang_Click(object sender, EventArgs e)
        {
            Quản_Lý_Bán_Hàng frm = new Quản_Lý_Bán_Hàng();
            frm.Show();
        }

        private void btnqlsanpham_Click(object sender, EventArgs e)
        {
            Quản_Lý_Sản_Phẩm frm = new Quản_Lý_Sản_Phẩm();
            frm.Show();
        }

        private void btnqlnhanvien_Click(object sender, EventArgs e)
        {
            Quản_Lý_Nhân_Viên frm = new Quản_Lý_Nhân_Viên();
            frm.Show();
        }

        private void btnbaocaotk_Click(object sender, EventArgs e)
        {
            Thống_Kê_Nhập_Xuất frm = new Thống_Kê_Nhập_Xuất();
            frm.Show();

        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn đăng xuất hệ thống không?", "Thông báo", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK )
                Application.Exit();
        }

        private void QuanLyCuaHang_Load(object sender, EventArgs e)
        {

        }
    }
}
