using OnlineMobileShop.Entity;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace OnlineMobileShop.DAL
{
    public class UserRespository
    {
     //   internal Dictionary<int, Admin> user = new Dictionary<int, Admin>();
   //     DataSet products = new DataSet();
        SqlConnection sqlConnection = UserRespository.GetDBConnection();
        //ArrayList userData = new ArrayList();
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
                
                if (flag=="true")
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
