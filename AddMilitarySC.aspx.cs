using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MilitaryMessage
{
    public partial class AddMilitarySC : System.Web.UI.Page
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
            string result = obj.CreateMSC(int.Parse(ddlMC.SelectedItem.Value),txtMSCName.Text, txtDescription.Text);
            if (result == "1")
            {
                ddlMC.SelectedIndex = 0;
                txtMSCName.Text = txtDescription.Text = "";
                lblMsg.Text = "Military Sub Category Added Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (result == "2")
            {
                ddlMC.SelectedIndex = 0;
                txtMSCName.Text = txtDescription.Text = "";
                lblMsg.Text = "Military Sub Category Added Already";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else if (result == "0")
            {
                ddlMC.SelectedIndex = 0;
                txtMSCName.Text = txtDescription.Text = "";
                lblMsg.Text = "Military Sub Category Creation Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}