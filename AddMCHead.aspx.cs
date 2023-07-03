using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MilitaryMessage
{
    public partial class AddMCHead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetMC();
                ddlMC.DataSource = tab;
                ddlMC.DataTextField = "MCName";
                ddlMC.DataValueField = "MCId";
                ddlMC.DataBind();
                ddlMC.Items.Insert(0, "--Select--");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            Random rnd = new Random();
            int MCHId = (rnd.Next(100000, 999999) + DateTime.Now.Second);
            string Password = (rnd.Next(1000, 9999) + DateTime.Now.Second).ToString();

            string result = obj.CreateMCHead(MCHId, int.Parse(ddlMC.SelectedItem.Value), txtName.Text, Password, txtMobileNo.Text, txtEmailId.Text, txtAddress.Text);
            if (result == "1")
            {

                string Message = "Login Credentials MCHId:" + MCHId + " & Password:" + Password;
                SendEmail.Send(txtEmailId.Text, Message);
                txtName.Text = txtEmailId.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "MCH Account Created Successfully & " + Message;
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            
            else if (result == "0")
            {

                txtName.Text = txtEmailId.Text = txtMobileNo.Text = txtAddress.Text = "";
                lblMsg.Text = "MCH Account Creation Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}