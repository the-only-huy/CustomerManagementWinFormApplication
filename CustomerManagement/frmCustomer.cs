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

namespace DemoSearchCustomer
{
    public partial class frmCustomer : Form
    {
        //Biến status có thể để public
        //isAddNew = true --> form thêm mới
        //isAddNew = false --> form edit
        public bool isAddNew = true;
        //Nhận thông tin từ form chính truyền sang
        public ClsCustomer currentCustomer;
        //Nạp chồng hàm tạo
        public frmCustomer(bool bStatus)
        {
            InitializeComponent();
            this.isAddNew = bStatus;
        }


        private void frmCustomers_Load(object sender, EventArgs e)
        {
            //Ẩn control này
            this.txtCustomerID.Enabled = false;
            if (isAddNew)
            {
                this.lblTitle.Text = "Add new Customer";
            }
            else
            {
                this.lblTitle.Text = "Edit Customer";
                //Hiện thông tin ghi đang chọn cần sửa
                if (this.currentCustomer != null)
                {
                    this.txtCustomerID.Text = this.currentCustomer.CustomerID.ToString();
                    this.txtFullName.Text = this.currentCustomer.FullName;
                    this.txtEmailAddress.Text = this.currentCustomer.EmailAddress;
                    this.txtPassword.Text = this.currentCustomer.Password;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isAddNew)
            {
                AddNewCustomer();
                DialogResult dr = MessageBox.Show("Bạn có muốn thêm khách hàng khác không?",
                    "Thêm khách hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    ResetText();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                UpdateCustomer();
                this.Close();
            }
        }

        private void ResetText()
        {
            this.txtCustomerID.Text = "";
            this.txtFullName.Text = "";
            this.txtEmailAddress.Text = "";
            this.txtPassword.Text = "";

        }

        private void AddNewCustomer()
        {
            string strconnectstring = System.Configuration.
                            ConfigurationSettings.AppSettings["MyConnectString"].ToString();

            string strCommand = "INSERT INTO Customers(FullName, EmailAddress, Password) VALUES (" +
                "N'" +
                this.txtFullName.Text.ToString()
                + "', N'" +
                this.txtEmailAddress.Text.ToString()
                + "', N'" +
                this.txtPassword.Text.ToString()
                + "')";
            SqlConnection myConnection = new SqlConnection(strconnectstring);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
            //Thực thi lệnh thêm
            myCommand.ExecuteNonQuery();
            //Nhận dữ liệu về dataset
            myConnection.Close();
        }

        private void AddNewCustomer_v2() 
        {
            string strconnectstring = System.Configuration.
                            ConfigurationSettings.AppSettings["MyConnectString"].ToString();

            string strCommand = "CustomerAdd";
            
            SqlConnection myConnection = new SqlConnection(strconnectstring);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.AddWithValue("@FullName", this.txtFullName.ToString());
            myCommand.Parameters.AddWithValue("@Email", this.txtEmailAddress.ToString());
            myCommand.Parameters.AddWithValue("@Password", this.txtPassword.ToString());
            
            myCommand.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
            myCommand.Parameters["@CustomerID"].Direction = ParameterDirection.Output;

            //lấy số lượng bản ghi
            int rowAffected = myCommand.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                MessageBox.Show(rowAffected.ToString() + "đã được thêm mới và ID là: " +
                    myCommand.Parameters["@CustomerID"].Value.ToString());
            }
            //Nhận dữ liệu về dataset
            myConnection.Close();
        }
        private void UpdateCustomer()
        {
            string strconnectstring = System.Configuration.
                            ConfigurationSettings.AppSettings["MyConnectString"].ToString();

                string strCommand = "UPDATE Customers SET " +
                "FullName = N'" + this.txtFullName.Text.ToString() + "', " +
                "EmailAddress = N'" + this.txtEmailAddress.Text.ToString() + "'," +
                "Password = N'" + this.txtPassword.Text.ToString() + "'" +
                "WHERE CustomerID = " + this.txtCustomerID.Text.ToString() + "";
            SqlConnection myConnection = new SqlConnection(strconnectstring);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
            //Thực thi lệnh sửa
            myCommand.ExecuteNonQuery();
            myConnection.Close(); 
        }

        private void UpdateCustomer_v2()
        {
            string strconnectstring = System.Configuration.
                            ConfigurationSettings.AppSettings["MyConnectString"].ToString();

            string strCommand = "CustomerUpdate";

            SqlConnection myConnection = new SqlConnection(strconnectstring);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.AddWithValue("@FullName", this.txtFullName.ToString());
            myCommand.Parameters.AddWithValue("@Email", this.txtEmailAddress.ToString());
            myCommand.Parameters.AddWithValue("@Password", this.txtPassword.ToString());
            //Riêng CustomerID  là output
            myCommand.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
            myCommand.Parameters["@CustomerID"].Direction = ParameterDirection.Output;
            //Thực thi lệnh thêm
            int rowAffected = myCommand.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                MessageBox.Show(rowAffected.ToString() + "đã được thêm mới và ID là: " +
                    myCommand.Parameters["@CustomerID"].Value.ToString());
            }
            //Nhận dữ liệu về dataset
            myConnection.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn đóng form không?",
                    "Thêm khách hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
