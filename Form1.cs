using _BTL.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace _BTL
{
    public partial class Form1 : Form
    {
        Create_Connection connect = new Create_Connection();
        SqlConnection conn = Create_Connection.createConnect("Data Source=DESKTOP-P137F4R;Initial Catalog=quanlySinhVien;Integrated Security=True;");

        public Form1()
        {
            InitializeComponent();
            conn.Open();
            __Enabled();
            fill_to_gridview();
        }

        private Boolean checkIsntEmpty()
        {
            return !txtMSV.Text.Equals("") && !txtMSV.Text.Trim().Equals("") &&
                    !txtHT.Text.Equals("") && !txtHT.Text.Trim().Equals("") &&
                    !txtSDT.Text.Equals("") && !txtSDT.Text.Trim().Equals("") &&
                    !txtCCCD.Text.Equals("") && !txtCCCD.Text.Trim().Equals("") &&
                    !txtCN.Text.Equals("") && !txtCN.Text.Trim().Equals("") &&
                    !txtDC.Text.Equals("") && !txtDC.Text.Trim().Equals("") &&
                    !txtNS.Text.Equals("") && !txtNS.Text.Trim().Equals("") &&
                    !txtGT.Text.Equals("") && !txtGT.Text.Trim().Equals("") &&
                    !txtEmail.Text.Equals("") && !txtEmail.Text.Trim().Equals("") &&
                    !textBox10.Text.Equals("") && !textBox10.Text.Trim().Equals("")
                    ;
        }

        public void fill_to_gridview()
        {
            dataGridView1.Rows.Clear();
            try
            {
                SqlDataReader da = connect.getQuery("SELECT * from tblSinhVien", conn);
                if (da.HasRows)
                {
                    int index = 1;
                    while (da.Read())
                    {
                        Object[] record = new object[10];
                        record[0] = da.GetValue(0);
                        record[1] = da.GetValue(1);
                        record[2] = da.GetValue(2);
                        record[3] = da.GetValue(3);
                        record[4] = da.GetValue(4);
                        record[5] = da.GetValue(5);
                        record[6] = da.GetValue(6);
                        record[7] = da.GetValue(7);
                        record[8] = da.GetValue(8);
                        record[9] = da.GetValue(9);
                        dataGridView1.Rows.Add(record);
                    }
                    da.Close();
                }
                else
                {
                    da.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        public void clearContent()
        {
            txtMSV.Text = "";
            txtHT.Text = "";
            txtSDT.Text = "";
            txtCCCD.Text = "";
            txtCN.Text = "";
            txtNS.Text = "";
            txtGT.Text = "";
            txtEmail.Text = "";
            textBox10.Text = "";
            txtDC.Text = "";
        }


        Boolean flag = false;


        private void _Enabled()
        {
            txtMSV.Enabled = true;
            txtHT.Enabled = true;
            txtSDT.Enabled = true;
            txtCCCD.Enabled = true;
            txtCN.Enabled = true;
            txtNS.Enabled = true;
            txtGT.Enabled = true;
            txtEmail.Enabled = true;
            textBox10.Enabled = true;
            txtDC.Enabled = true;

        }

        public void enable_all()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        public void unenable()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void __Enabled()
        {
            txtMSV.Enabled = false;
            txtHT.Enabled = false;
            txtSDT.Enabled = false;
            txtCCCD.Enabled = false;
            txtCN.Enabled = false;
            txtNS.Enabled = false;
            txtGT.Enabled = false;
            txtEmail.Enabled = false;
            textBox10.Enabled = false;
            txtDC
                .Enabled = false;
        }

        private static DateTime? ConvertStringToDate(string dateString)
        {
           
            string format = "yyyy-MM-dd"; 
            DateTime parsedDate;

            
            if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                return parsedDate;
            }

            
            return null;
        }

        // Method to convert the string date to a formatted string
        public string ConvertToDate(string date)
        {
            DateTime? result = ConvertStringToDate(date);

            if (result.HasValue)
            {
                // Return the formatted date as a string
                return result.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                MessageBox.Show("Ngày nhập không đúng định dạng !!");
                return "";
            }
        }

        public void fill_to_gridview(SqlDataReader da)
        {
            dataGridView1.Rows.Clear();
            try
            {
                if (da.HasRows)
                {
                    int index = 1;
                    while (da.Read())
                    {
                        Object[] record = new object[10];
                        record[0] = da.GetValue(0);
                        record[1] = da.GetValue(1);
                        record[2] = da.GetValue(2);
                        record[3] = da.GetValue(3);
                        record[4] = da.GetValue(4);
                        record[5] = da.GetValue(5);
                        record[6] = da.GetValue(6);
                        record[7] = da.GetValue(7);
                        record[8] = da.GetValue(8);
                        record[9] = da.GetValue(9);
                        dataGridView1.Rows.Add(record);
                    }
                    da.Close();
                }
                else
                {
                    da.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtMSV.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtHT.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtEmail.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtSDT.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txtCN.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txtGT.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txtNS.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                txtDC.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                textBox10.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                txtCCCD.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!txtHT.Enabled)
            {
                clearContent();
                _Enabled();
                button1.Text = "Xác nhận ";
                txtMSV.Enabled = false;
                unenable();
                button1.Enabled = true;

            }
            else
            {

                //-----------------//
                if (
                    !txtHT.Text.Equals("") && !txtHT.Text.Trim().Equals("") &&
                    !txtSDT.Text.Equals("") && !txtSDT.Text.Trim().Equals("") &&
                    !txtCCCD.Text.Equals("") && !txtCCCD.Text.Trim().Equals("") &&
                    !txtCN.Text.Equals("") && !txtCN.Text.Trim().Equals("") &&
                    !txtDC.Text.Equals("") && !txtDC.Text.Trim().Equals("") &&
                    !txtNS.Text.Equals("") && !txtNS.Text.Trim().Equals("") &&
                    !txtGT.Text.Equals("") && !txtGT.Text.Trim().Equals("") &&
                    !txtEmail.Text.Equals("") && !txtEmail.Text.Trim().Equals("") &&
                    !lbl.Text.Equals("") && !lbl.Text.Trim().Equals("")
                )
                {
                    String _date = ConvertToDate(txtNS.Text);
                    if (_date.Equals("")) return;
                    String query = "INSERT INTO tblSinhVien VALUES (N'"+txtHT.Text+"', '"+txtEmail.Text+"', '"+txtSDT.Text+"', N'"+txtCN.Text+"', N'"+txtGT.Text+"', '"+_date+"', N'" + txtDC.Text+"', '"+textBox10.Text+"', '"+txtCCCD.Text+"')";
                    connect.setDb(query, conn);
                    fill_to_gridview();
                    __Enabled();
                    MessageBox.Show("Thành công");
                    button1.Text = "Thêm";
                    enable_all();
                }
                else
                {
                    MessageBox.Show("Chưa đủ thông tin ");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!checkIsntEmpty())
            {
                MessageBox.Show("Chọn bản ghi cần sửa ");
            }
            else
            {
                if (!flag)
                {
                    _Enabled();
                    txtMSV.Enabled = false;
                    button2.Text = "Xác nhận";
                    flag = true;
                    unenable();
                    button2.Enabled = true;
                }
                else
                {
                    if (checkIsntEmpty())
                    {
                        String _date = ConvertToDate(txtNS.Text);
                        if (_date.Equals("")) return;
                        String query = "UPDATE tblSinhVien SET HoTen = N'"+txtHT.Text+"', Email = '"+txtEmail.Text+"', SDT = '"+txtSDT
                            .Text+"', ChuyenNganh = N'"+txtCN.Text+"', GioiTinh = N'"+txtGT.Text+"', NgaySinh = '"+_date+"', DiaChi = '"+txtDC.Text+"', KhoaHoc = '"+textBox10.Text+"', CCCD = '"+txtCCCD.Text+"' WHERE MaSV = "+txtMSV.Text+";";
                        connect.setDb(query, conn);
                        fill_to_gridview();
                        __Enabled();
                        MessageBox.Show("Thành công");
                        button2.Text = "Sửa";
                        fill_to_gridview();
                        flag = false;
                        enable_all();
                        clearContent();
                    }
                    else
                    {
                        MessageBox.Show("Chưa nhập đủ thông tin ");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtMSV.Text.Equals(""))
            {
                MessageBox.Show("Chọn bản ghi cần xóa ");
            }
            else
            {


                string query = "delete from tblSinhVien where MaSV = '" + txtMSV.Text + "'";
                connect.setDb(query, conn);
                MessageBox.Show("Thành công");
                clearContent();
                fill_to_gridview();
                
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
