using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CrudApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionstring = "Data Source=MOBACK;Initial Catalog=Student;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            try
            {
               
                Console.WriteLine("Connection Estatablished successfully :");
                string answer;
                do
                {

                    Console.WriteLine("Select from the option below :\n1.Create \n2.Retrive \n3.Update \n4.Delete");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            //Create =>C
                            Console.Write("Enter Your Name : ");
                            string userName = Console.ReadLine();
                            Console.Write("Enter Your Age : ");
                            int userAge = int.Parse(Console.ReadLine());
                            string insertQuery = "insert into UserDetails(User_Name,User_age) values('" + userName + "'," + userAge + ")";
                            SqlCommand insertCmd = new SqlCommand(insertQuery, sqlConnection);
                            insertCmd.ExecuteNonQuery();
                            Console.WriteLine("Data Will be successfully inserted into the table");
                            break;
                        case 2:
                            //Retrive=>R
                            string displayQuery = "Select * From UserDetails";
                            SqlCommand displaCmd = new SqlCommand(displayQuery, sqlConnection);
                            SqlDataReader dr = displaCmd.ExecuteReader();
                            while (dr.Read())
                            {
                                Console.WriteLine("\nId :" + dr.GetValue(0).ToString());
                                Console.WriteLine("Name :" + dr.GetValue(1).ToString());
                                Console.WriteLine("Age :" + dr.GetValue(2).ToString());
                            }
                            dr.Close();
                            break;
                        case 3:
                            //Update=>U
                            int u_Id;
                            int u_Age;
                            string u_Name;
                            Console.Write("Enter Your id that you would like to update : ");
                            u_Id = int.Parse(Console.ReadLine());
                            Console.Write("Enter Your Age that you would like to update : ");
                            u_Age = int.Parse(Console.ReadLine());
                            Console.Write("Enter Your Name that you would like to update : ");
                            u_Name = Console.ReadLine();
                            string updateQuery = "update UserDetails set User_age =  " + u_Age + " ,User_Name = '" + u_Name + "' where User_Id = " + u_Id + "";
                            SqlCommand updateCmd = new SqlCommand(updateQuery, sqlConnection);
                            updateCmd.ExecuteNonQuery();
                            Console.WriteLine("record updated succesfully :");
                            break;
                        case 4:
                            //Delete=>D
                            int d_Id;
                            Console.Write("Enter Your id that you would like to delete : ");
                            d_Id = int.Parse(Console.ReadLine());
                            string deleteQuery = "Delete from UserDetails where User_Id = " + d_Id;
                            SqlCommand deleteCmd = new SqlCommand(deleteQuery, sqlConnection);
                            deleteCmd.ExecuteNonQuery();
                            Console.WriteLine("record Deleted succesfully :");
                            break;
                        default:
                            Console.WriteLine("Invalid Number :");
                            break;
                    }
                    Console.WriteLine("Do you want to continue :\nPlease enter Yes/No");
                    answer = Console.ReadLine();
                   // answer = answer.ToLower();
                }
                while ( answer != "no");
               
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    } 
}
