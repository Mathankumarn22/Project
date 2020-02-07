using System;
using OnlineMobileShop.Common;

namespace OnlineMobileShop.Entity
{
    public class UserManager
    {
        public int userId { get; set; }
        public string name { get; set; }
        public string number { get; set; }
        public string mailID { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public UserManager(int userId, string name, string number, string mailID, string password, string Role)
        {
            Validation validation = new Validation();

            while (true)
            {
                try
                {

                    this.name = name;
                    if (name == "")
                    {
                        throw new NullReferenceException("Name");
                    }
                    else
                    {
                        bool flag = Validation.IsValidName(name);
                        if (!flag)
                        {
                            Console.WriteLine("Enter valid name");
                            Console.WriteLine("Registration failed and fill the details correctly");
                            throw new NullReferenceException("Name");
                        }
                    }
                    Console.WriteLine("Enter your mail id");
                    this.mailID = mailID;
                    if (mailID == "")
                    {
                        throw new NullReferenceException("Email");
                    }
                    else
                    {
                        bool flag = Validation.IsValidMailId(mailID);
                        if (!flag)
                        {
                            Console.WriteLine("Enter valid mail");
                            Console.WriteLine("Registration failed and fill the details correctly");
                            throw new NullReferenceException("Email");
                        }
                    }
                    Console.WriteLine("Enter your phone number");
                    this.number = number;
                    if (number == "")
                    {
                        throw new NullReferenceException("PhoneNumber");
                    }
                    else
                    {
                        bool flag = Validation.IsValidMobileNumber(number);
                        if (!flag)
                        {
                            Console.WriteLine("Enter valid phone number");
                            Console.WriteLine("Registration failed and fill the details correctly");
                            throw new NullReferenceException("PhoneNumber");
                        }
                    }

                    Console.WriteLine("Enter your password");
                    this.password = password;
                    if (password == "")
                    {
                        throw new NullReferenceException("Password");
                    }
                    else
                    {
                        bool flag = Validation.IsValidPassword(password);
                        if (!flag)
                        {
                            Console.WriteLine("Enter valid password it should be 8 characters like upper case,lower case and number");
                            Console.WriteLine("Registration failed and fill the details correctly");
                            throw new NullReferenceException("Password");
                        }
                    }
                    Console.WriteLine("Enter your role\n1.Admin\n2.User");
                    role = Role;
                    if (role == "")
                    {
                        throw new NullReferenceException("role");
                    }
                    else
                    {
                        bool flag = validation.IsValidRole(role);
                        if (!flag)
                        {
                            Console.WriteLine("Enter valid role");
                            Console.WriteLine("Registration failed and fill the details correctly");
                            throw new NullReferenceException("role");
                        }
                    }
                    break;
                }
                catch (NullReferenceException exception) when (exception.Message == "Name")
                {
                    Console.WriteLine("Enter correct username ");

                }
                catch (NullReferenceException exception) when (exception.Message == "Email")
                {
                    Console.WriteLine("Enter correct mail id");

                }
                catch (NullReferenceException exception) when (exception.Message == "PhoneNumber")
                {
                    Console.WriteLine("Enter correct phone number");

                }
                catch (NullReferenceException exception) when (exception.Message == "Password")
                {
                    Console.WriteLine("Enter correct password");

                }
            }
        }
    }
}
