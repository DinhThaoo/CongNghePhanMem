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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string tk = txttk.Text;
            string mk = txtmk.Text;
            string query = "select count (*) as soluong from DANGNHAP " +
                "where TAIKHOAN ='" + tk + "'and MATKHAU='" + mk + "' ";
            KetNoi kn = new KetNoi();
            DataSet ds = kn.laydulieu(query, "DANGNHAP");

            if ((int)ds.Tables["DANGNHAP"].Rows[0].ItemArray[0] == 1)
            {
                MessageBox.Show("Đăng nhập thành công!");
                QuanLyCuaHang frm = new QuanLyCuaHang();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!");

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
