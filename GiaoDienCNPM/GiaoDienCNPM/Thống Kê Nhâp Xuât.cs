using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienCNPM //chưa đc
{ 
    public partial class Thống_Kê_Nhập_Xuất : Form
    {
        public Thống_Kê_Nhập_Xuất()
        {
            InitializeComponent();
        }
        private void Thống_Kê_Nhập_Xuất_Load(object sender, EventArgs e)
        {
            getData();
        }
        public void getData()
        {
            string query = " EXEC CapNhatTenNVVaoTKNXUAT1;EXEC CapNhatTenSPVaoTKNXUAT;  EXEC CapNhatGIANNHAP; EXEC CapNhatGIABAN;  select * from TKNHAPXUAT";
            KetNoi kn = new KetNoi();
            DataSet ds = new DataSet();
            ds = kn.laydulieu(query, "TKNHAPXUAT");
            dgv.DataSource = ds.Tables["TKNHAPXUAT"];
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtTimkiem.Text = dgv.Rows[row].Cells["MANX"].Value.ToString();
                txtmanv.Text = dgv.Rows[row].Cells["MANV"].Value.ToString();
                txtTennv.Text = dgv.Rows[row].Cells["TENNV"].Value.ToString();
                txttg.Text = dgv.Rows[row].Cells["THOIGIAN"].Value.ToString();
                txtmasp.Text = dgv.Rows[row].Cells["MASP"].Value.ToString();
                txttensp.Text = dgv.Rows[row].Cells["TENSP"].Value.ToString();
                txtsln.Text = dgv.Rows[row].Cells["SOLUONGNHAP"].Value.ToString();
                txtslx.Text = dgv.Rows[row].Cells["SOLUONGXUAT"].Value.ToString();
               
            }
        }
       
        private void btnThem_Click(object sender, EventArgs e)
        {
            string manx = txtTimkiem.Text;
            string manv = txtmanv.Text;
            string tennv = txtTennv.Text;
            string thoigian = txttg.Text;
            string masp = txtmasp.Text;
            string tensp = txttensp.Text;
            string sln = txtsln.Text;
            string slx = txtslx.Text;

            string query = "insert into TKNHAPXUAT(MANX, MANV, TENNV, THOIGIAN, MASP, TENSP, SOLUONGNHAP, SOLUONGXUAT)"
                + " VALUES " + "('" + manx + "', '" + manv + "',N'" + tennv + "','" + thoigian + "','" + masp + "'" +
                ",N" + "'" + tensp + "'," + "'" + sln + "'," + "'" + slx + "')";
            KetNoi kn = new KetNoi();
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Thêm mới báo cáo nhập xuất thành công!");
                getData();
            }
            else
            {
                MessageBox.Show("Thêm mới báo cáo nhập xuất thất bại!");
            }
        }
        
        private void btnSua_Click(object sender, EventArgs e)
        {
            string manx = txtTimkiem.Text;
            string manv = txtmanv.Text;
            string tennv = txtTennv.Text;
            string thoigian = txttg.Text;
            string masp = txtmasp.Text;
            string tensp = txttensp.Text;
            string sln = txtsln.Text;
            string slx = txtslx.Text;
       

            string query = "update TKNHAPXUAT set MANV='" + manv + "', TENNV=N'" + tennv + "', THOIGIAN='" + thoigian + "', MASP='" + masp + "',TENSP=N'" + tensp + "'," +
                " " + "SOLUONGNHAP='" + sln + "'," + "SOLUONGXUAT='" + slx + "'where MANX ='" + manx + "'";
            KetNoi kn = new KetNoi();
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Sửa thông tin thống kê nhập xuất thành công!");
                getData();
            }
            else
                MessageBox.Show("Sửa thông tin thống kê nhập xuất thất bại!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string manx = txtTimkiem.Text;
            string manv = txtmanv.Text;
            string tennv = txtTennv.Text;
            string thoigian = txttg.Text;
            string masp = txtmasp.Text;
            string tensp = txttensp.Text;
            string sln = txtsln.Text;
            string slx = txtslx.Text;
          

            string query = "delete TKNHAPXUAT where MANX = '" + manx + "'";
            KetNoi kn = new KetNoi();
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Xóa thông tin thống kê nhập xuất thành công!");
                getData();
            }
            else
            {
                MessageBox.Show("Xóa thông tin thống kê nhập xuấ thất bại!");
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tk = txtTimkiem.Text;
            string query = "select * from TKNHAPXUAT where MANX like N'%" + tk + "%'";
            DataSet ds = new DataSet();
            KetNoi cn = new KetNoi();
            ds = cn.laydulieu(query, "TKNHAPXUAT");

            dgv.DataSource = ds.Tables["TKNHAPXUAT"];
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btntktc_Click(object sender, EventArgs e)
        {
            Thống_Kê_Thu_Chi frm = new Thống_Kê_Thu_Chi();
            frm.Show();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntaomoi_Click(object sender, EventArgs e)
        {
            txtTimkiem.Text = "";
            txtmanv.Text = "";
            txtTennv.Text = "";
            txttg.Text = "";
            txtmasp.Text = "";
            txttensp.Text = "";
            txtsln.Text = "";
            txtslx.Text = "";
        }
    }
}
