using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AlwaysEncrypted
{
    public partial class AlwaysEncryptedForm : Form
    {
        public AlwaysEncryptedForm()
        {
            InitializeComponent();
        }
        public string ConnectionString { get { return ConfigurationManager.ConnectionStrings["ConnectionStrings"].ToString(); } }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.AddEmployee", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    var lastNameSP = new SqlParameter("@LastName", SqlDbType.NVarChar);
                    lastNameSP.Value = txtLastName.Text;
                    cmd.Parameters.Add(lastNameSP);

                    var salarySP = new SqlParameter("@Salary", SqlDbType.Int);
                    salarySP.Value = Convert.ToInt32(txtSalary.Text);
                    cmd.Parameters.Add(salarySP);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee added.");

                    txtLastName.Clear();
                    txtSalary.Clear();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.GetEmployeeByLastName", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var lastNameSP = new SqlParameter("@LastName", SqlDbType.NVarChar);
                    lastNameSP.Value = txtLastName.Text;
                    cmd.Parameters.Add(lastNameSP);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        txtSalary.Text = rdr["Salary"].ToString();
                    }
                }
            }
        }
    }
}
