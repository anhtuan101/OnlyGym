using GymManagerment_MVP.MainFeature.HocVienRelated;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagerment_MVP
{
    public partial class ThongTinHocVien : UserControl
    {
        public ThongTinHocVien()
        {
            InitializeComponent();
        }

        private void lblPFCongNo_Click(object sender, EventArgs e)
        {

        }

        private void gbThongTinHD_Enter(object sender, EventArgs e)
        {

        }

        private void gbThongTinGoiTap_Enter(object sender, EventArgs e)
        {

        }

        private void lvThongTinHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblGoi_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void lvLichSuTap_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvThongTinPT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string query = "server = TUNN\\ANHTUAN; database = gymManagement;Integrated Security=True";
        public void DisplayThoTinHocVien(string code)
        {
            using (SqlConnection con = new SqlConnection(query))
            using (SqlCommand cmd = new SqlCommand("sp_GetThongTinHocVien", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", code);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    tbPFTen.Text = row["TenHV"].ToString();
                    tbPFSDT.Text = row["sdt"].ToString();
                    cbPFTrangThai.Text = row["TrangThai"].ToString();
                    cbPFGHT.Text = row["TenGoiTap"].ToString();

                    if (row["ngaySinh"] != DBNull.Value)
                        dtpNgaysinh.Value = Convert.ToDateTime(row["ngaySinh"]);

                    rdNam.Checked = row["GioiTinh"].ToString() == "Nam";
                    rdNu.Checked = row["GioiTinh"].ToString() == "Nữ";
                    txtGhiChu.Text = row["ghiChu"].ToString();

                    if (row["thoiGianTao"] != DBNull.Value)
                        dtpTao.Value = Convert.ToDateTime(row["thoiGianTao"]);
                    if (row["thoiGianSua"] != DBNull.Value)
                        dtpNgaySua.Value = Convert.ToDateTime(row["thoiGianSua"]);
                    if (row["ngayXoa"] != DBNull.Value)
                        dtpXoa.Value = Convert.ToDateTime(row["ngayXoa"]);
                }
            }
        }

        private void ThongTinHocVien_Load(object sender, EventArgs e)
        {
            ThongTinGoiTapUC goitap = new ThongTinGoiTapUC();
            goitap.Dock= DockStyle.Fill;
            tabGoi.Controls.Add(goitap);
            goitap.BringToFront();


            ThongTinCheckInUC thongTinCheckInUC = new ThongTinCheckInUC();
            thongTinCheckInUC.Dock = DockStyle.Fill;
            tabCheckIn.Controls.Add(thongTinCheckInUC);
            thongTinCheckInUC.BringToFront();


            ThongTinGoiTapPTUC thongTinGoiTapPTUC=new ThongTinGoiTapPTUC();
            thongTinGoiTapPTUC.Dock = DockStyle.Fill;
            tabLichSuPT.Controls.Add(thongTinGoiTapPTUC);
            thongTinGoiTapPTUC.BringToFront();

            ThongTinHoaDonUC thongTinHoaDonUC = new ThongTinHoaDonUC();
            thongTinHoaDonUC.Dock = DockStyle.Fill;
            tabHóaĐơn.Controls.Add(thongTinHoaDonUC);
            thongTinHoaDonUC.BringToFront();
        }
    }
}
