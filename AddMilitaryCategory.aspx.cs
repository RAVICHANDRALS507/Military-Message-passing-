using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MilitaryMessage
{
    public partial class AddMilitaryCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();


            string result = obj.CreateMC(txtMCName.Text, txtDescription.Text);
            if (result == "1")
            {
                txtMCName.Text = txtDescription.Text = "";
                lblMsg.Text = "Military Category Added Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (result == "2")
            {
                txtMCName.Text = txtDescription.Text = "";
                lblMsg.Text = "Military Category Added Already";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else if (result == "0")
            {
                txtMCName.Text = txtDescription.Text = "";
                lblMsg.Text = "Military Category Creation Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}