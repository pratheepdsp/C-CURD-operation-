using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;
using System.Data;


namespace CURD
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadRecord();
            }
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server = MYSQL5038.site4now.net; Database = db_a726c9_prathee; Uid = a726c9_prathee; Pwd = 6382756166@Dsp";
            conn.Open();
            MySqlCommand con = new MySqlCommand("Insert into emp (id,name,address,age,contact)values('" + int.Parse(TextBox1.Text)+"','"+TextBox2.Text+"','"+DropDownList1.SelectedValue+"','"+double.Parse(TextBox3.Text)+"','"+TextBox4.Text+"')", conn);
            con.ExecuteNonQuery();
            conn.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('successfully Inserted');", true);
            LoadRecord();

        }
        void LoadRecord()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server = MYSQL5038.site4now.net; Database = db_a726c9_prathee; Uid = a726c9_prathee; Pwd = 6382756166@Dsp"; 
            MySqlCommand con = new MySqlCommand("Select * from emp", conn);
            MySqlDataAdapter d = new MySqlDataAdapter(con);
            DataTable dt = new DataTable();
            d.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server = MYSQL5038.site4now.net; Database = db_a726c9_prathee; Uid = a726c9_prathee; Pwd = 6382756166@Dsp"; 
            conn.Open();
            MySqlCommand con = new MySqlCommand("Update  emp set name='" + TextBox2.Text + "',address='" + DropDownList1.SelectedValue + "',age='" + double.Parse(TextBox3.Text) + "',contact='" + TextBox4.Text + "' where id='" + int.Parse(TextBox1.Text) + "'",conn);
            con.ExecuteNonQuery();
            conn.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('successfully Updated');", true);
            LoadRecord();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server = MYSQL5038.site4now.net; Database = db_a726c9_prathee; Uid = a726c9_prathee; Pwd = 6382756166@Dsp";
            conn.Open();
            MySqlCommand con = new MySqlCommand("DELETE From emp where id= '" + int.Parse(TextBox1.Text) + "'", conn);
            con.ExecuteNonQuery();
            conn.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('successfully Deleted');", true);
            LoadRecord();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server = MYSQL5038.site4now.net; Database = db_a726c9_prathee; Uid = a726c9_prathee; Pwd = 6382756166@Dsp";
            MySqlCommand con = new MySqlCommand("Select * from emp where id= '" + int.Parse(TextBox1.Text) + "'", conn);
            MySqlDataAdapter d = new MySqlDataAdapter(con);
            DataTable dt = new DataTable();
            d.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server = MYSQL5038.site4now.net; Database = db_a726c9_prathee; Uid = a726c9_prathee; Pwd = 6382756166@Dsp";
            conn.Open();
            MySqlCommand con = new MySqlCommand("Select * from  emp where id= '" + int.Parse(TextBox1.Text) + "'", conn);
            MySqlDataReader r = con.ExecuteReader();
            while(r.Read())
            {
                TextBox2.Text = r.GetValue(1).ToString();
                DropDownList1.SelectedValue = r.GetValue(2).ToString();
                TextBox3.Text = r.GetValue(3).ToString();
                TextBox4.Text = r.GetValue(4).ToString();

            }
        }
    }
}