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
            
            CrudOperations operations = new CrudOperations();
            // operations.CreateUser();
            //operations.RetriveUser();
            operations.UpdateUser();
            //operations.DeleteUser();
        }
    } 
}
