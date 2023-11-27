using System.Data;
using System.Data.SqlClient;

namespace DemoSearchCustomer
{
    public partial class frmCustomersList : Form
    {
        //Biến toàn cục lưu trữ thông tin của bản ghi customer đang được chọn
        public ClsCustomer currentCustomer;
        public frmCustomersList()
        {
            InitializeComponent();
        }

        public void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string strconnectstring = System.Configuration.
                    ConfigurationSettings.AppSettings["MyConnectString"].ToString();
                string strSearch = "'%" + this.txtSearch.Text + "%'";
                string strCommand = "SELECT * FROM Customers WHERE FullName like " + strSearch;
                SqlConnection myConnection = new SqlConnection(strconnectstring);
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
                SqlDataAdapter da = new SqlDataAdapter(myCommand);

                //Nhận dữ liệu về Data Set
                DataSet ds = new DataSet();
                da.Fill(ds, "MyCustomer");
                ds.WriteXml("Customer.xml");
                //Đưa dữ liệu lên GridView
                this.dgvCustomers.DataSource = ds;
                this.dgvCustomers.DataMember = "MyCustomer";
                myConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred" + ex.Message.ToString(), "An Error has occurred");
            }
        }


        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvCustomers.Rows[e.RowIndex];
            GetCurrentRow(dr);
        }
        private void dgvCustomers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvCustomers.Rows[e.RowIndex];
            GetCurrentRow(dr);
        }

        private void GetCurrentRow(DataGridViewRow dr)
        {
            //Khởi tạo objCustomer
            this.currentCustomer = new ClsCustomer();
            this.currentCustomer.CustomerID = int.Parse(dr.Cells["CustomerID"].Value.ToString());
            this.currentCustomer.FullName = dr.Cells["FullName"].Value.ToString();
            this.currentCustomer.EmailAddress = dr.Cells["EmailAddress"].Value.ToString();
            this.currentCustomer.Password = dr.Cells["Password"].Value.ToString();
            //MessageBox.Show(this.currentCustomer.CustomerID.ToString());
        }


        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmCustomer fcustomer = new frmCustomer(true);
            fcustomer.ShowDialog();
            btnSearch_Click(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmCustomer fcustomer = new frmCustomer(false);
            fcustomer.currentCustomer = new ClsCustomer();
            //Truyền bản ghi hiện thời sang form Customer 
            fcustomer.currentCustomer = this.currentCustomer;
            fcustomer.ShowDialog();
            btnSearch_Click(sender, e);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentCustomer != null)
                {
                    DeleteCustomer_v3();
                    btnSearch_Click(sender, e);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Khách hàng muốn xóa đang có đơn đặt, không thể xóa!" + ex.Message.ToString(), "Error!");
            }
        }

        private void DeleteCustomer_v1()
        {
            string strconnectstring = System.Configuration.
                            ConfigurationSettings.AppSettings["MyConnectString"].ToString();

            string strCommand = "DELETE FROM Customers WHERE CustomerID = " + this.currentCustomer.CustomerID;
            SqlConnection myConnection = new SqlConnection(strconnectstring);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
            //Thực thi lệnh xóa
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            //Load lại dữ liệu

        }
        private void DeleteCustomer_v2()
        {
            string strconnectstring = System.Configuration.
                            ConfigurationSettings.AppSettings["MyConnectString"].ToString();

            string strCommand = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
            SqlConnection myConnection = new SqlConnection(strconnectstring);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
            myCommand.Parameters.AddWithValue("CustomerID", this.currentCustomer.CustomerID);
            //Thực thi lệnh xóa
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            //Load lại dữ liệu
        }

        private void DeleteCustomer_v3()
        {
            string strconnectstring = System.Configuration.
                            ConfigurationSettings.AppSettings["MyConnectString"].ToString();

            string strCommand = "CustomerDelete";
            SqlConnection myConnection = new SqlConnection(strconnectstring);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(strCommand, myConnection);

            //Đặt kiểu là StoredProcedure
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.AddWithValue("CustomerID", this.currentCustomer.CustomerID);
            //Thực thi lệnh xóa
            int rowAffected = myCommand.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                MessageBox.Show(rowAffected.ToString() + "bản ghi đã được xóa");
            }
            
            //Nhận dự liệu về Data Set
            myConnection.Close();
        }

      
    }
}