using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using ZXing;
using System.Drawing;
using System.Drawing.Imaging;
using Amazon.S3;
using Amazon.S3.Model;

namespace MilitaryMessage
{
    public partial class ViewPostMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Panel1.Visible = false;
            }
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetPostMsg(int.Parse(Session["UserId"].ToString()));
                Table1.Controls.Clear();
                if (tab.Rows.Count > 0)
                {
                    TableRow hr = new TableRow();
                    TableHeaderCell hc1 = new TableHeaderCell();
                    TableHeaderCell hc2 = new TableHeaderCell();
                    TableHeaderCell hc3 = new TableHeaderCell();
                    TableHeaderCell hc4 = new TableHeaderCell();
                    TableHeaderCell hc5 = new TableHeaderCell();

                    hc1.Text = "Sl No";
                    hr.Cells.Add(hc1);
                    hc2.Text = "Military Sub Category";
                    hr.Cells.Add(hc2);
                    hc3.Text = "Log Date";
                    hr.Cells.Add(hc3);
                    hc4.Text = "";
                    hr.Cells.Add(hc4);

                    Table1.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        Label lblSlNo = new Label();
                        lblSlNo.Text = (i + 1).ToString();
                        TableCell SlNo = new TableCell();
                        SlNo.Controls.Add(lblSlNo);

                        Label lblMSCName = new Label();
                        lblMSCName.Text = tab.Rows[i]["MSCName"].ToString();
                        TableCell MSCName = new TableCell();
                        MSCName.Controls.Add(lblMSCName);

                        Label lbllogDate = new Label();
                        lbllogDate.Text = tab.Rows[i]["LogDate"].ToString();
                        TableCell logDate = new TableCell();
                        logDate.Controls.Add(lbllogDate);

                        LinkButton View = new LinkButton();
                        View.Text = "View Report";
                        View.ID = "lnkView" + i.ToString();
                        View.CommandArgument = tab.Rows[i]["SlNo"].ToString();
                        View.Click += View_Click;

                        TableCell ViewCell = new TableCell();
                        ViewCell.Controls.Add(View);

                        row.Controls.Add(SlNo);
                        row.Controls.Add(MSCName);
                        row.Controls.Add(logDate);
                        row.Controls.Add(ViewCell);
                        Table1.Controls.Add(row);
                    }
                }
                else
                {
                    //lblMsg.Text = "No Record Found";
                }
            }
            catch
            {

            }
        }

        
        void View_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            Random rnd = new Random();
            MyConnection obj = new MyConnection();
            Session["SlNo"] = int.Parse(lnk.CommandArgument);
            Session["AccessKey"] = rnd.Next(1000, 9999).ToString();
            string result = obj.Request_MSD(int.Parse(lnk.CommandArgument), int.Parse(Session["UserId"].ToString()), Session["AccessKey"].ToString());
            if (result == "1")
            {
                LoadData();
                Panel1.Visible = true;
                txtAccesskey.Text = Session["AccessKey"].ToString();
            }
        }
        AmazonS3Client _s3ClientObj = null;
        protected void btnSave_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            if (txtAccesskey.Text == Session["AccessKey"].ToString())
            {
                Panel1.Visible = true;
                lblMsg.Text = "";
                DataTable tab = new DataTable();
                tab = obj.GetPostMsg(int.Parse(Session["UserId"].ToString()));

                ////Amazon AWS 
                _s3ClientObj = new AmazonS3Client("AKIA2PAQROQSWPFRCBEY", "tjrNzQwPc55MOxbAsyCfmqKeNjKqS+VJs4I7F+Ni", Amazon.RegionEndpoint.USEast1);
                string fname = "~/DownloadFile/" + tab.Rows[0]["FilePath"].ToString().Split('/')[1];
                if (File.Exists(Server.MapPath(fname)))
                {
                    File.Delete(Server.MapPath(fname));
                }
                GetObjectResponse _responseObj = _s3ClientObj.GetObject(new GetObjectRequest() { BucketName = tab.Rows[0]["FilePath"].ToString().Split('/')[0], Key = tab.Rows[0]["FilePath"].ToString().Split('/')[1] });
                _responseObj.WriteResponseStreamToFile(Server.MapPath(fname));

                //GetDecryptData objdk = new GetDecryptData();
                string result = tab.Rows[0]["KeyData"].ToString();
                var QCreader = new BarcodeReader();
                string QCfilename = Path.Combine(Server.MapPath(fname));
                var QCresult = QCreader.Decode(new Bitmap(QCfilename));
                txtDescription.Text = AESCryptoClass.Decrypt(QCresult.Text, result);
                txtDescription.ReadOnly = true;
            }
            else
            {
                lblMsg.Text = "Invalid Access Key";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }
    }
}