using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace EmployeeWebForm
{
    public class EmployeeDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        public EmployeeDAL()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
        }

        /* public int Add(Employee employee)
         {

             string qry = "INSERT INTO Employee (name, salary, department) VALUES (@name, @salary, @department";
              cmd = new SqlCommand(qry, con);
              cmd.Parameters.AddWithValue("@Name", employee.name);
              cmd.Parameters.AddWithValue("@salary", employee.salary);
              cmd.Parameters.AddWithValue("@department", employee.department);

              con.Open();
              int result = cmd.ExecuteNonQuery();
              con.Close();
              return result;

         }*/
        /* public int Update(Employee employee)
         {
             int result = 0;
             string qry = "Update Employee set name = @name, salary = @salary, department=@department";
             cmd = new SqlCommand(qry, con);
             cmd.Parameters.AddWithValue("@name", employee.name);
             cmd.Parameters.AddWithValue("@salary", employee.salary);
             cmd.Parameters.AddWithValue("@department", employee.department);
             con.Open();
              result = cmd.ExecuteNonQuery();
             con.Close();
             return result;

         }
        */

    }
}