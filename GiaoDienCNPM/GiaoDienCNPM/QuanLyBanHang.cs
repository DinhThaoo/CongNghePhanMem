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
    public partial class Quản_Lý_Bán_Hàng : Form
    {
        public Quản_Lý_Bán_Hàng()
        {
            InitializeComponent();
        }  

        private void btndx_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        public void getData()
        {
            string query = " EXEC CapNhatTenNVVaoHoaDon; EXEC CapNhatTenSPVaoHoaDon1; EXEC CapnhatDONGIA; EXEC THANHTIEN; select * from HOADON";
            KetNoi kn = new KetNoi();
            DataSet ds = new DataSet();
            ds = kn.laydulieu(query, "HOADON");
            dgv.DataSource = ds.Tables["HOADON"];

        }

        private void Quản_Lý_Bán_Hàng_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtmahd.Text = dgv.Rows[row].Cells["MAHD"].Value.ToString();
                txtmasp.Text = dgv.Rows[row].Cells["MASP"].Value.ToString();
                txttensp.Text = dgv.Rows[row].Cells["TENSP"].Value.ToString();
                txtmanv.Text = dgv.Rows[row].Cells["MANV"].Value.ToString();             
                txtsl.Text = dgv.Rows[row].Cells["SOLUONG"].Value.ToString();
                txtdg.Text = dgv.Rows[row].Cells["DONGIA"].Value.ToString();
                txtthanhtien.Text = dgv.Rows[row].Cells["THANHTIEN"].Value.ToString();
            }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            txtmahd.Text = "";
            txtmasp.Text = "";
            txttensp.Text = "";
            txtmanv.Text = "";          
            txtsl.Text = "";
            txtdg.Text = "";
            txtthanhtien.Text = "";
            getData();
        }

        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            string mahd = txtmahd.Text;
            string masp = txtmasp.Text;
            string tensp = txttensp.Text;
            string manv = txtmanv.Text;      
            string sl = txtsl.Text;
            string dg = txtdg.Text;
            string thanhtien = txtthanhtien.Text;

            string query = "insert into HOADON(MAHD, MASP, TENSP, MANV, SOLUONG, DONGIA, THANHTIEN) " +
                "VALUES ('" + mahd + "','" + masp + "', N'" + tensp + "','"+ manv +"','" + sl +"','" + dg + "','" + thanhtien +"')";
            KetNoi kn = new KetNoi();
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show(" Bạn có muốn In Hóa Đơn không ?", "Thanh toán thành công!", MessageBoxButtons.YesNo);
                getData();
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại!, Vui lòng kiểm tra lại thông tin");
            }  
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            string mahd = txtmahd.Text;
            string masp = txtmasp.Text;
            string tensp = txttensp.Text;
            string manv = txtmanv.Text;           
            string sl = txtsl.Text;
            string dg = txtdg.Text;
            string thanhtien = txtthanhtien.Text;

            string query = "update HOADON set MASP='" + masp + "'," + "TENSP=N'"
                + tensp + "'," + "MANV='" + manv + "'," + "SOLUONG='" + sl + "'," + "DONGIA='" + dg + "'," +
                "" + "THANHTIEN='" + thanhtien + "' where MAHD ='" + mahd + "'";
            KetNoi kn = new KetNoi();
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Sửa thông tin hóa đơn thành công!");
                getData();
            }
            else
                MessageBox.Show("Sửa thông tin hóa đơn thất bại!");

        }  
       
        private void btnxoa_Click(object sender, EventArgs e)
        {
            string mahd = txtmahd.Text;
            string masp = txtmasp.Text;
            string tensp = txttensp.Text;
            string manv = txtmanv.Text;          
            string sl = txtsl.Text;
            string dg = txtdg.Text;
            string thanhtien = txtthanhtien.Text;

            string query = "delete HOADON where MAHD = '" + mahd + "'";
            KetNoi kn = new KetNoi();
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Xóa thông tin hóa đơn thành công!");
                getData();
            }
            else
            {
                MessageBox.Show("Xóa thông tin hóa đơn  thất bại!");
            }

        } 
        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tk = txtmahd.Text;
            string query = "select * from HOADON where MAHD like N'%" + tk + "%'";
            DataSet ds = new DataSet();
            KetNoi cn = new KetNoi();
            ds = cn.laydulieu(query, "HOADON");

            dgv.DataSource = ds.Tables["HOADON"];
        }

        
    }
}
    