using System;
using System.Collections.Generic;
using System.Data.SqlClient; //to connect with SQL database
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp
{
    internal class CrudOperations
    {
        private SqlConnection con = new SqlConnection("Data Source=MOBACK;DataBase=Student;Integrated Security=True");
        public void CreateUser()
        {
			try
			{
                con.Open();
                Console.Write("Enter Your Name : ");
                string userName = Console.ReadLine();
                Console.Write("Enter Your Age : ");
                int userAge = int.Parse(Console.ReadLine());
                SqlCommand insertCmd = new SqlCommand("Sp_insert'" + userName + "'," + userAge + "", con);
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Data Will be successfully inserted into the table");
            }
			catch (Exception e)
			{

				Console.WriteLine(e.Message);
			}
            finally
            {
                con.Close();
            }
        }
        public void RetriveUser()
        {
            try
            {
                con.Open();
                SqlCommand displaCmd = new SqlCommand("SELECT * FROM Retrive_Userdetails", con);
                SqlDataReader dr = displaCmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("\nId :" + dr.GetValue(0).ToString());
                    Console.WriteLine("Name :" + dr.GetValue(1).ToString());
                    Console.WriteLine("Age :" + dr.GetValue(2).ToString());
                }
                dr.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateUser()
        {
            try
            {
                con.Open();
                string u_Name;
                Console.Write("Enter Your id that you would like to update : ");
                int u_Id = int.Parse(Console.ReadLine());
                Console.Write("Enter Your Age that you would like to update : ");
                int u_Age = int.Parse(Console.ReadLine());
                Console.Write("Enter Your Name that you would like to update : ");
                u_Name = Console.ReadLine();
                SqlCommand updateCmd = new SqlCommand("update UserDetails set User_age =  " + u_Age + " ,User_Name = '" + u_Name + "' where User_Id = " + u_Id + "", con);
                updateCmd.ExecuteNonQuery();
                Console.WriteLine("record updated succesfully :");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteUser()
        {
            try
            {
                con.Open();
                int d_Id;
                Console.Write("Enter Your id that you would like to delete : ");
                d_Id = int.Parse(Console.ReadLine());
                SqlCommand deleteCmd = new SqlCommand("sp_delete " + d_Id, con);
                deleteCmd.ExecuteNonQuery();
                Console.WriteLine("record Deleted succesfully :");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
