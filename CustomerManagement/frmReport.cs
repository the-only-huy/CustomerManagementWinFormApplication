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
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            try
            {
                string connectstring = System.Configuration.ConfigurationSettings.AppSettings["MyConnectString"].ToString();
                string strCommand = "SELECT * FROM v_Order_Full";
                SqlConnection myConnection = new SqlConnection(connectstring);
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(myCommand);

                DataSet dataSet = new DataSet();

                myDataAdapter.Fill(dataSet, "MyCustomer");
                dataSet.WriteXml("Orders.xml");

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message.ToString(), "Error occured");
            }
        }
    }
}
