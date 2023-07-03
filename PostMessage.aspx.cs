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
    public partial class PostMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetMSC_MSCHId_PM(int.Parse(Session["UserId"].ToString()));
                ddlMSC.DataSource = tab;
                ddlMSC.DataTextField = "MSCName";
                ddlMSC.DataValueField = "MSCId";
                ddlMSC.DataBind();
                ddlMSC.Items.Insert(0, "--Select--");
            }
        }
        static string filename;
        AmazonS3Client _s3ClientObj = null;
        protected void btnSave_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();

            Random rnd = new Random();
            
            int key = rnd.Next(1000, 9999);
            
            string Encryptdata = AESCryptoClass.EncryptData(txtDescription.Text, key.ToString());
            string Treatment = txtDescription.Text;
            var QCwriter = new BarcodeWriter();
            QCwriter.Format = BarcodeFormat.QR_CODE;
            var result = QCwriter.Write(Encryptdata);
            string v = rnd.Next(1000, 9999).ToString();
            filename = Session["UserId"].ToString() + "_" + v + ".jpg";

            string filepath = "~/MSD/" + filename;
            var barcodeBitmap = new Bitmap(result);

            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(Server.MapPath(filepath),
                   FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }



            ////Amazon AWS 
            _s3ClientObj = new AmazonS3Client("AKIA2PAQROQSWPFRCBEY", "tjrNzQwPc55MOxbAsyCfmqKeNjKqS+VJs4I7F+Ni", Amazon.RegionEndpoint.USEast1);
            PutBucketRequest p1 = new PutBucketRequest();
            p1.BucketName = "msdmessage" + Session["UserId"].ToString() + v; // reason: bucket name shared by millions so to avoid naming conflict , u can give anything u want
            _s3ClientObj.PutBucket(p1);

            PutObjectRequest _requestObj = new PutObjectRequest();
            _requestObj.BucketName = "msdmessage" + Session["UserId"].ToString() + v;
            _requestObj.FilePath = Server.MapPath(filepath);
            PutObjectResponse _responseObj = _s3ClientObj.PutObject(_requestObj);

            if (_responseObj.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                obj = new MyConnection();
                string FilePath = "msdmessage" + Session["UserId"].ToString() + v + "/" + filename;
                string res = obj.PostMSDMSCH(int.Parse(Session["UserId"].ToString()), int.Parse(ddlMSC.SelectedItem.Value), key.ToString(), FilePath);
                if (res == "1")
                {
                    txtDescription.Text = "";
                    ddlMSC.SelectedIndex = 0;
                    lblMsg.Text = "MSCH MSD Posted Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    txtDescription.Text = "";
                    ddlMSC.SelectedIndex = 0;
                    lblMsg.Text = "MSCH MSD Post Error!!...";
                    lblMsg.ForeColor = System.Drawing.Color.Red;

                }
            }



        }

    }
}
