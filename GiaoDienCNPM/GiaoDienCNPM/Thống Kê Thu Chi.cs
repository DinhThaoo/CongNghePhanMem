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
    public partial class Thống_Kê_Thu_Chi : Form
    {
        public Thống_Kê_Thu_Chi()
        {
            InitializeComponent();
        }

        private void Quản_Lý_Kho__Phiếu_Xuất_Hàng_Load(object sender, EventArgs e)
        {
            getData();
        }
        public void getData()
        {
            string query = "EXEC CapNhatTenNVVaoTKTHUCHI; select * from TKTHUCHI";
            KetNoi kn = new KetNoi();
            DataSet ds = new DataSet();
            ds = kn.laydulieu(query, "TKTHUCHI");
            dgv.DataSource = ds.Tables["TKTHUCHI"];
        }
        private void dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtTimkiem.Text = dgv.Rows[row].Cells["MATHUCHI"].Value.ToString();
                txtmanv.Text = dgv.Rows[row].Cells["MANV"].Value.ToString();
                textBox1.Text = dgv.Rows[row].Cells["TENNV"].Value.ToString();
                textBox2.Text = dgv.Rows[row].Cells["THOIGIAN"].Value.ToString();
                textBox3.Text = dgv.Rows[row].Cells["SOTIENTHU"].Value.ToString();
                textBox4.Text = dgv.Rows[row].Cells["SOTIENCHI"].Value.ToString();                
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string mathuchi = txtTimkiem.Text;
            string manv = txtmanv.Text;
            string tennv = textBox1.Text;
            string thoigian = textBox2.Text;
            string sotienthu = textBox3.Text;
            string sotienchi = textBox4.Text;      
             
            string query = "insert into TKTHUCHI(MATHUCHI, MANV, TENNV, THOIGIAN, SOTIENTHU, SOTIENCHI)"
                + " VALUES " + "('" + mathuchi + "', '" + manv + "',N'" + tennv + "','" + thoigian + "',N'" + sotienthu + "'" +
                "," + "'" + sotienchi + "')";
            KetNoi kn = new KetNoi();
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Thêm mới báo cáo thu chi thành công!");
                getData();
            }
            else
            {
                MessageBox.Show("Thêm mới báo cáo thu chi thất bại!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e) 
        {
            string mathuchi = txtTimkiem.Text;
            string manv = txtmanv.Text;
            string tennv = textBox1.Text;
            string thoigian = textBox2.Text;
            string sotienthu = textBox3.Text;
            string sotienchi = textBox4.Text;
            string query = "update TKTHUCHI set MANV = '"+ manv+"', TENNV=N'" + tennv + "'," + "THOIGIAN='"
                + thoigian + "'," + "SOTIENTHU='" + sotienthu + "'," + "SOTIENCHI='" + sotienchi +
                "' where MATHUCHI =N'" + mathuchi + "'";
            KetNoi kn = new KetNoi();
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Sửa thông tin báo cáo thu chi thành công!");
                getData();     
            }
            else
                MessageBox.Show("Sửa thông tin báo cáo thu chi thất bại!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mathuchi = txtTimkiem.Text;
            string manv = txtmanv.Text;
            string tennv = textBox1.Text;
            string thoigian = textBox2.Text;
            string sotienthu = textBox3.Text;
            string sotienchi = textBox4.Text;
            string query = "delete TKTHUCHI where MATHUCHI = '" + mathuchi + "'";
            KetNoi kn = new KetNoi();
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Xóa thông tin báo cáo thu chi thành công!");
                getData();
            }
            else
            {
                MessageBox.Show("Xóa thông tin báo cáo thu chi thất bại!");
            }
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tk = txtTimkiem.Text;
            string query = "select * from TKTHUCHI where MATHUCHI like N'%" + tk + "%'";
            DataSet ds = new DataSet();
            KetNoi cn = new KetNoi();
            ds = cn.laydulieu(query, "TKTHUCHI");

            dgv.DataSource = ds.Tables["TKTHUCHI"];
        }

        private void btntknx_Click(object sender, EventArgs e)
        {
            Thống_Kê_Nhập_Xuất frm = new Thống_Kê_Nhập_Xuất();
            frm.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTaomoi_Click(object sender, EventArgs e)
        {
            txtTimkiem.Text = "";
            txtmanv.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void txtmanv_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
