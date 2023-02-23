using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PoplulateDataInDropDown
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindDropDownList();
            }

        }
        void BindDropDownList()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from employee";
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField= "NAME";
            DropDownList1.DataValueField= "id";
            DropDownList1.DataBind();
            ListItem item = new ListItem("Select ME","-1");
            item.Selected = true;   
            DropDownList1.Items.Insert(0,item);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedValue == "-1")
            {
            Response.Write("Please Select an empolyee");
            }
            else
            {
                Response.Write("Selected item is :" + DropDownList1.SelectedItem.Text + "<br/>");
                Response.Write("Selected item value is :" + DropDownList1.SelectedItem.Value + "<br/>");
                Response.Write("Selected item value is :" + DropDownList1.SelectedIndex);
            }
        }
    }
}