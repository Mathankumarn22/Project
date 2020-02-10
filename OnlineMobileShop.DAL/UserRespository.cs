using OnlineMobileShop.Entity;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.DynamicData;
using System.Web.UI.WebControls;

namespace OnlineMobileShop.DAL
{
    public class UserRespository
    {
        static SqlConnection sqlConnection = UserRespository.GetDBConnection();
        private static readonly object password;
        public static object mailID { get; private set; }
        public bool SignUp(UserManager userManager)
        {
            string insertQuery = "SP_SignUp";
            using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@name";
                param.Value = userManager.name;
                param.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@number";
                param.Value = userManager.number;
                param.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(param);
                
                param = new SqlParameter();
                param.ParameterName = "@mailID";
                param.Value = userManager.mailID;
                param.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@password";
                param.Value = userManager.password;
                param.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(param);

                sqlConnection.Open();
                int row = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (row >= 1)
                {
                    return true;
                }
                return false;

            }
        }
        public bool LogIn(int userID, string password)
        {
            string insertQuery = "SP_LogIn";
            using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@userId";
                param.Value = userID;
                param.SqlDbType = SqlDbType.Int;
                sqlCommand.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@password";
                param.Value = password;
                param.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(param);

                sqlConnection.Open();
                string flag = sqlCommand.ExecuteScalar().ToString();

                if (flag == "true")
                {
                    sqlConnection.Close();
                    return true;
                }
                sqlConnection.Close();
                return false;

            }
        }
        public static SqlConnection GetDBConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineMobileShop"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }
        public static void RefreshData(GridView Gv_OnlineMobileShop)
        {
            SqlCommand cmd = new SqlCommand("select * From UserDetails", sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Gv_OnlineMobileShop.DataSource = dt;
            Gv_OnlineMobileShop.DataBind();

        }
        public static void Gv_OnlineMobileShop_RowDeleting(GridViewDeleteEventArgs e, int userId)
        {
            GridView gridView = new GridView();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("delete from UserDetails where userId =@userId", sqlConnection);
            cmd.Parameters.AddWithValue("userId", userId);
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public static void Gv_OnlineMobileShop_RowUpdating(GridView Gv_OnlineMobileShop, GridViewUpdateEventArgs e)
        {

            TextBox txtUserId = Gv_OnlineMobileShop.Rows[e.RowIndex].FindControl("txtUserId") as TextBox;
            TextBox txtname = Gv_OnlineMobileShop.Rows[e.RowIndex].FindControl("txtName") as TextBox;
            TextBox txtnumber = Gv_OnlineMobileShop.Rows[e.RowIndex].FindControl("txtNumber") as TextBox;
            TextBox txtmailID = Gv_OnlineMobileShop.Rows[e.RowIndex].FindControl("txtMailId") as TextBox;
            TextBox txtpassword = Gv_OnlineMobileShop.Rows[e.RowIndex].FindControl("txtPassword") as TextBox;
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SP_Updatedata", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("userId", txtUserId.Text);
            cmd.Parameters.AddWithValue("name", txtname.Text);
            cmd.Parameters.AddWithValue("number", txtnumber.Text);
            cmd.Parameters.AddWithValue("mailID", txtmailID.Text);
            cmd.Parameters.AddWithValue("password", txtpassword.Text);
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public static void InsertData(GridView Gv_OnlineMobileShop)
        {
           string name = (Gv_OnlineMobileShop.FooterRow.FindControl("txtNameFooter") as TextBox).Text;
            string number = (Gv_OnlineMobileShop.FooterRow.FindControl("txtNumberFooter") as TextBox).Text;
            string mailId = (Gv_OnlineMobileShop.FooterRow.FindControl("txtMailIdFooter") as TextBox).Text;
            string password = (Gv_OnlineMobileShop.FooterRow.FindControl("txtPasswordFooter") as TextBox).Text;
            string insertQuery = "SP_SignUp";
            using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
                
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@name";
                param.Value = name;
                param.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@number";
                param.Value = number;
                param.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@mailID";
                param.Value = mailId;
                param.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@password";
                param.Value = password;
                param.SqlDbType = SqlDbType.VarChar;
                sqlCommand.Parameters.Add(param);

                sqlConnection.Open();
                int rows = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

            }
        }
    }
}




























































        /*  class UserRespository
          {
              internal static Dictionary<string, Details> user = new Dictionary<string, Details>();
              public void Login()
              {
                  string Roll = "User";
                  Console.WriteLine("Enter the mail ID");
                  string mail = Console.ReadLine();
                  Console.WriteLine("Enter the password");
                  byte flag = 0;
                  string password = Console.ReadLine();
                  if (user.ContainsKey(mail))
                  {
                      foreach (Details value in user.Values)
                      {

                          if (password.Equals(value.password))
                          {

                              Console.WriteLine("Successfully login");
                              ProductDetails.Print();
                              flag = 1;
                              break;
                          }
                      }
                      if (flag == 0)
                      {

                          Console.WriteLine("Login failed");
                          Console.WriteLine("Enter correct username and password");
                          Login();
                      }
                  }
                  if (mail.Equals("mathankumarn22@gmail.com") && password.Equals("Mathan98"))
                  {
                      Roll = "Admin";
                      Admin admin = new Admin();
                      admin.Operation();
                  }
              }
              internal void SignUp(string mail, Details details)
              {
                  string Roll = "User";
                  user.Add(mail, details);

              }
              public void CheckDetails(string mail, string password)
              {
                  byte flag = 0;
                  foreach (string ID in user.Keys)
                  {
                      if (ID == mail && user[ID].password == password)
                      {
                          Console.WriteLine("Successfully login");
                          flag = 1;
                          break;
                      }
                  }
                  if (flag == 0)
                  {
                      Console.WriteLine("Login Failed");
                      Login();
                  }
              }

          }
    }*/
