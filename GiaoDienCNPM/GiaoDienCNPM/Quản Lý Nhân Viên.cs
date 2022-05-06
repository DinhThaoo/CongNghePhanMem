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
    public partial class Quản_Lý_Nhân_Viên : Form
    {
        public Quản_Lý_Nhân_Viên()
        {
            InitializeComponent();
        }
        public void getData()
        {
            string query = " EXEC THUCLINH ;select * from NHANVIEN";
            KetNoi kn = new KetNoi();
            DataSet ds = new DataSet();
            ds = kn.laydulieu(query, "NHANVIEN");
            dgvQLNV.DataSource = ds.Tables["NHANVIEN"];
        }
        private void Quản_Lý_Nhân_Viên_Load(object sender, EventArgs e)
        {
            getData();
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtTimkiem.Text = dgvQLNV.Rows[row].Cells["MANV"].Value.ToString();
                textBox2.Text = dgvQLNV.Rows[row].Cells["TENNV"].Value.ToString();
                textBox3.Text = dgvQLNV.Rows[row].Cells["SDT"].Value.ToString();
                textBox4.Text = dgvQLNV.Rows[row].Cells["DIACHI"].Value.ToString();
                textBox5.Text = dgvQLNV.Rows[row].Cells["NAMSINH"].Value.ToString();
                textBox6.Text = dgvQLNV.Rows[row].Cells["GIOITINH"].Value.ToString();
                textBox7.Text = dgvQLNV.Rows[row].Cells["VITRI"].Value.ToString();
                textBox1.Text = dgvQLNV.Rows[row].Cells["SONGAYCONG"].Value.ToString();
                textBox8.Text = dgvQLNV.Rows[row].Cells["LUONG1NGAY"].Value.ToString();
                txtthuclinh.Text = dgvQLNV.Rows[row].Cells["THUCLINH"].Value.ToString();
            }
        }
        private void btnTaomoi_Click(object sender, EventArgs e)
        {
            txtTimkiem.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox1.Text = "";
            textBox8.Text = "";
            txtthuclinh.Text = ""; 
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string manv = txtTimkiem.Text;
            string tennv = textBox2.Text;
            string sdt = textBox3.Text;
            string diachi = textBox4.Text;
            string namsinh = textBox5.Text;
            string gt = textBox6.Text;
            string vitri = textBox7.Text;
            string songaycong = textBox1.Text;
            string luong1ngay = textBox8.Text;
            string thuclinh = txtthuclinh.Text;

            string query = "insert into NHANVIEN(MANV, TENNV, SDT, DIACHI, NAMSINH, GIOITINH, VITRI, SONGAYCONG, LUONG1NGAY, THUCLINH)"
                +" VALUES " +"('" + manv + "',N'" + tennv + "','" + sdt + "',N'" + diachi + "'" +
                "," + "'" + namsinh + "',N'" + gt + "',N'" + vitri + "','" + songaycong + "','" + luong1ngay + "','" + thuclinh + "')";
            KetNoi kn = new KetNoi();
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Thêm mới nhân viên thành công!");
                getData();
            }
            else
            {
                MessageBox.Show("Thêm mới nhân viên thất bại!");
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string manv = txtTimkiem.Text;
            string tennv = textBox2.Text;
            string sdt = textBox3.Text;
            string diachi = textBox4.Text;
            string namsinh = textBox5.Text;
            string gt = textBox6.Text;
            string vitri = textBox7.Text;
            string songaycong = textBox1.Text;
            string luong1ngay = textBox8.Text;
            string thuclinh = txtthuclinh.Text;

            string query = "update NHANVIEN set TENNV =N'" +tennv + "',SDT='" + sdt + "'," +"DIACHI=N'"
                + diachi + "'," +"NAMSINH='" + namsinh + "'," + "GIOITINH=N'" + gt + "'," +
                "" +"VITRI=N'" + vitri + "'," + "SONGAYCONG=N'" + songaycong + "'," + "LUONG1NGAY=N'" + luong1ngay + "'," + "THUCLINH='" + thuclinh + "'where MANV = '" + manv + "'";
            KetNoi kn = new KetNoi();
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Sửa thông tin nhân viên thành công!");
                getData();             
            }
            else
                MessageBox.Show("Sửa thông tin nhân viên thất bại!");
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string manv = txtTimkiem.Text;
            string tennv = textBox2.Text;
            string sdt = textBox3.Text;
            string diachi = textBox4.Text;
            string namsinh = textBox5.Text;
            string gt = textBox6.Text;
            string vitri = textBox7.Text;
            string songaycong = textBox1.Text;
            string luong1ngay = textBox8.Text;
            string thuclinh = txtthuclinh.Text;

            string query = "delete NHANVIEN where MANV = '" + manv + "'";
            KetNoi kn = new KetNoi();
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Xóa thông tin nhân viên thành công!");
                getData();
            }
            else
            {
                MessageBox.Show("Xóa thông tin nhân viên thất bại!");
            }
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tk = txtTimkiem.Text;
            string query = "select * from NHANVIEN where MANV like N'%" + tk + "%'";
            DataSet ds = new DataSet();
            KetNoi cn = new KetNoi();
            ds = cn.laydulieu(query, "NHANVIEN");

            dgvQLNV.DataSource = ds.Tables["NHANVIEN"];
        } 
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnbctk_Click(object sender, EventArgs e)
        {

        }
    }
}
   
