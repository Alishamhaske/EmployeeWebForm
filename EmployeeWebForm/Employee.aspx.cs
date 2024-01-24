using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Services.Description;
using System.Xml.Linq;


namespace EmployeeWebForm
{
    public partial class Employee : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;


        public Employee()
        { 
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
        }

        public void GetAll()
        {
            string qry = "select * from Employee";
            cmd = new SqlCommand(qry, con);
            con.Open();
            reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            gridview.DataSource = table;
            gridview.DataBind();
            con.Close();
        }

        public void ClearAll()
        {
             txtID.Text = "";
            Nametxt.Text = "";
            txtdep.Text = "";
            salarytxt.Text = "";

        }

        

        /*private void BindGridView()
        {
               SqlCommand cmd = new SqlCommand("SELECT * FROM Employee", con);
                con.Open();
            reader = cmd.ExecuteReader();
            DataTable  table = new DataTable();
            table.Load(reader);
            gridview.DataSource = table;    
                gridview.DataBind();
            con.Close();

        }
           */


       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                GetAll();
            }
        }

        protected void Nametxt_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select *from Employee where id= @id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid1.Text));
                con.Open();
                reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    if(reader.Read())
                    {
                        Nametxt.Text = reader["name"].ToString();
                        txtdep.Text = reader["department"].ToString();
                        salarytxt.Text = reader["salary"].ToString();
                    }

                }
                else
                {
                    Response.Write("Record Not Found");
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            { 
                con.Close(); 
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //using(con = new SqlConnection(cs))
            try
            {
                string qry = "INSERT INTO Employee (name, salary, department) VALUES (@name, @salary, @department)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@name", Nametxt.Text);
                cmd.Parameters.AddWithValue("@salary", salarytxt.Text);
                cmd.Parameters.AddWithValue("@department", txtdep.Text);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1)
                {
                    Response.Write("Data Inserted");
                    ClearAll();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
            GetAll();



            
        }

        protected void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Nametxt.Text = gridview.SelectedRow.Cells[2].Text;
        }

        protected void Updatetxt_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "Update Employee set name = @name, salary = @salary, department=@department";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@name", Nametxt.Text);
                cmd.Parameters.AddWithValue("@salary", salarytxt.Text);
                cmd.Parameters.AddWithValue("@department", txtdep.Text);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if(result>=1)
                {
                    Response.Write("Record Updated");
                    ClearAll();
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
            GetAll();
        }

        protected void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "delete from Employee where id = @id ";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid1.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if(result>=1)
                {
                    Response.Write("Record Deleted");
                    ClearAll();
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
            GetAll();
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}

/*
 

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO YourTable (Name, Age) VALUES (@Name, @Age)", con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            BindGridView();
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtName.Text = string.Empty;
            txtAge.Text = string.Empty;
        }
*/