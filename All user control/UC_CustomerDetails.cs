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

namespace Cake_Shop_Management_System.All_user_control
{
    public partial class UC_CustomerDetails : UserControl
    {
        public UC_CustomerDetails()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String fname = txtFirstName.Text;
            String lname = txtLastName.Text;

            String gender = "";

            bool ischacked = guna2RadioButton1.Checked;

            if(ischacked)
            {
                gender = guna2RadioButton1.Text;
            }
            else
            {
                gender = guna2RadioButton2.Text;
            }

            String dob = guna2DateTimePickerDOB.Text;
            Int64 mobile = Int64.Parse(txtMobile.Text);
            String email = txtEmail.Text;
            String address = txtAddress.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-NANBOTV\\SQLEXPRESS;Initial Catalog=cake;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into Customer (fname,Lname,Gender,DOB,Mobile,Email,MAddress) values ('" + fname + "','" + lname + "','" + gender + "','" + dob + "'," + mobile + ",'" + email + "','" + address + "')";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            MessageBox.Show("Data Saved.");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMobile.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            guna2RadioButton1.Checked = false;
            guna2RadioButton2.Checked = false;
            guna2DateTimePickerDOB.Value = DateTime.Now;
        }
    }
}
