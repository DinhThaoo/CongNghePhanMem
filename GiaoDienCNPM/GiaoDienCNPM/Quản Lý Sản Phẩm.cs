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
    public partial class Quản_Lý_Sản_Phẩm : Form
    {
        public Quản_Lý_Sản_Phẩm()
        {
            InitializeComponent();
        }

        private void Quản_Lý_Sản_Phẩm_Load(object sender, EventArgs e)
        {
            getData(); 
        }
        public void getData()
        {
            string query = "EXEC CapNhatGIANBAN ; select * from SANPHAM";
            KetNoi kn = new KetNoi();
            DataSet ds = new DataSet();
            ds = kn.laydulieu(query, "SANPHAM");
            dgv.DataSource = ds.Tables["SANPHAM"];
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtTimkiem.Text = dgv.Rows[row].Cells["MASP"].Value.ToString();
                textBox1.Text = dgv.Rows[row].Cells["TENSP"].Value.ToString();
                textBox2.Text = dgv.Rows[row].Cells["SOTONKHO"].Value.ToString();
                textBox3.Text = dgv.Rows[row].Cells["GIANHAP"].Value.ToString();
                textBox4.Text = dgv.Rows[row].Cells["GIABAN"].Value.ToString();

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTimkiem.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string masp = txtTimkiem.Text;
            string tensp = textBox1.Text;
            string soluong = textBox2.Text;
            string giaban = textBox3.Text;
            string gianhap = textBox4.Text;            
            string query = "insert into SANPHAM(MASP, TENSP, SOTONKHO, GIABAN, GIANHAP)"
                + " VALUES " + "('" + masp + "',N'" + tensp + "','" + soluong + "',N'" + giaban + "'" +
                "," + "'" + gianhap + "')";
            KetNoi kn = new KetNoi();
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Thêm mới sản phẩm thành công!");
                getData();
            }
            else
            {
                MessageBox.Show("Thêm mới sản phẩm thất bại!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string masp = txtTimkiem.Text;
            string tensp = textBox1.Text;
            string soluong = textBox2.Text;
            string giaban = textBox3.Text;
            string gianhap = textBox4.Text;
            string query = "update SANPHAM set TENSP=N'" + tensp + "'," + "SOTONKHO='"
                + soluong + "'," + "GIABAN='" + giaban + "'," + "GIANHAP=N'" + gianhap + "' where MASP =N'" + masp + "'";
            KetNoi kn = new KetNoi();
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Sửa thông tin sản phẩm thành công!");
                getData();
            }
            else
                MessageBox.Show("Sửa thông tin sản phẩm thất bại!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string masp = txtTimkiem.Text;
            string tensp = textBox1.Text;
            string soluong = textBox2.Text;
            string giaban = textBox3.Text;
            string gianhap = textBox4.Text;
            string query = "delete SANPHAM where MASP = '" + masp + "'";
            KetNoi kn = new KetNoi();
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Xóa thông tin sản phẩm  thành công!");
                getData();
            }
            else
            {
                MessageBox.Show("Xóa thông tin sản phẩm  thất bại!");
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tk = txtTimkiem.Text;
            string query = "select * from SANPHAM where MASP like N'%" + tk + "%'";
            DataSet ds = new DataSet();
            KetNoi cn = new KetNoi();
            ds = cn.laydulieu(query, "SANPHAM");

            dgv.DataSource = ds.Tables["SANPHAM"];
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
