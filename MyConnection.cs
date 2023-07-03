using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace MilitaryMessage
{
    public class MyConnection
    {
        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataAdapter adp = null;

        public MyConnection()
        {
            con = new MySqlConnection("server=localhost;database=militarymessageaws;user id=root;password=root;port=3306;");
            con.Open();
        }
        public int LoginVerify(int UserId, string Password, string UserType)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = "";
            if (UserType == "MH")
            {
                sql = string.Format("Select count(*) from militaryhead where MHId={0} and Password='{1}'", UserId, Password);
            }
            else if (UserType == "MCH")
            {
                sql = string.Format("Select count(*) from mcheadmaster where MCHId={0} and Password='{1}'", UserId, Password);
            }
            else if (UserType == "MSCH")
            {
                sql = string.Format("Select count(*) from mscheadmaster where MSCHId={0} and Password='{1}'", UserId, Password);
            }
            cmd.CommandText = sql;
            int result = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return result;
        }
        public string ChangePassword(int UserId, string Password, string UserType)
        {

            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = "";
            if (UserType == "MH")
            {
                sql = string.Format("Update militaryhead set Password={0} where MHId={1}", Password, UserId);
            }
            else if (UserType == "MCH")
            {
                sql = string.Format("Update mcheadmaster set Password={0} where MCHId={1}", Password, UserId);
            }
            else if (UserType == "MSCH")
            {
                sql = string.Format("Update mscheadmaster set Password={0} where MSCHId={1}", Password, UserId);
            }
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public string CreateMC(string MCName,string Description)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string chksql = string.Format("Select count(*) from mcmaster where MCName='{0}'", MCName);
            cmd.CommandText = chksql;
            string res = cmd.ExecuteScalar().ToString();
            string result = "";
            if (res == "0")
            {
                string sql = string.Format("insert into mcmaster(MCName,Description)values('{0}','{1}')", MCName, Description);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }
        public DataTable GetMC()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select * from mcmaster");
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string CreateMSC(int MCId,string MSCName, string Description)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string chksql = string.Format("Select count(*) from mscmaster where MSCName='{0}' and MCId={1}", MSCName, MCId);
            cmd.CommandText = chksql;
            string res = cmd.ExecuteScalar().ToString();
            string result = "";
            if (res == "0")
            {
                string sql = string.Format("insert into mscmaster(MCId,MSCName,Description)values({0},'{1}','{2}')", MCId, MSCName, Description);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }
        public string CreateMCHead(int MCHId,int MCId, string Name, string Password, string MobileNo, string EmailId, string Address)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into mcheadmaster(MCHId,MCId,Name,Password,MobileNo,EmailId,Address)values({0},{1},'{2}','{3}','{4}','{5}','{6}')", MCHId, MCId, Name, Password, MobileNo, EmailId, Address);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }

        public DataTable GetMSC_MSCHId(int MCHId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select mscmaster.MSCId,mscmaster.MSCName from mscmaster inner join mcmaster on mscmaster.MCId=mcmaster.MCId inner join mcheadmaster on mcmaster.MCId=mcheadmaster.MCId where mcheadmaster.MCHId={0}",MCHId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string CreateMSCHead(int MSCHId, int MSCId, string Name, string Password, string MobileNo, string EmailId, string Address)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into mscheadmaster(MSCHId,MSCId,Name,Password,MobileNo,EmailId,Address)values({0},{1},'{2}','{3}','{4}','{5}','{6}')", MSCHId, MSCId, Name, Password, MobileNo, EmailId, Address);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public DataTable GetMSC_MSCHId_PM(int MSCHId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select * from mscheadmaster where MSCHId={0}", MSCHId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);

            string sqlmsc = string.Format("Select * from mscmaster where MSCId<>{0}", int.Parse(tab.Rows[0]["MSCId"].ToString()));
            cmd.CommandText = sqlmsc;
            adp = new MySqlDataAdapter(cmd);
            DataTable tabmsc = new DataTable();
            adp.Fill(tabmsc);

            con.Close();
            return tabmsc;
        }
        

        public string PostMSDMSCH(int MSCHId, int MSCId, string KeyData, string Filepath)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into mschmessage(MSCHId,MSCId,LogDate,KeyData,Filepath,Status)values({0},{1},'{2}','{3}','{4}','Pending')", MSCHId, MSCId,DateTime.Now.ToString("dd/MM/yyyy"), KeyData, Filepath);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }


        public DataTable GetPostMsg(int MSCHId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            DataTable tab = new DataTable();

            string sql = string.Format("Select * from mscheadmaster where MSCHId={0}", MSCHId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);    
            adp.Fill(tab);


            string sqlmsc = string.Format("Select mscmaster.MSCName,mschmessage.SlNo,mschmessage.LogDate,mschmessage.KeyData,mschmessage.FilePath from mscmaster inner join mscheadmaster on mscmaster.MSCId=mscheadmaster.MSCId inner join mschmessage on mschmessage.MSCHId=mscheadmaster.MSCHId where mschmessage.MSCId={0} and mschmessage.Status='Pending'", int.Parse(tab.Rows[0]["MSCId"].ToString()));
            cmd.CommandText = sqlmsc;
            adp = new MySqlDataAdapter(cmd);
            DataTable tabmsc = new DataTable();
            adp.Fill(tabmsc);

            con.Close();
            return tabmsc;
        }

        
        public string Request_MSD(int SlNo,int MSCHId,string AccessKey)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = "";
          
            sql = string.Format("insert into recordrequest(SlNo,MSCHId,ReqDate,AccessKey,Status)values({0},{1},'{2}','{3}','Accept')", SlNo, MSCHId, DateTime.Now.ToString("dd/MM/yyyy"), AccessKey);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        
        public string PostMessageHead(int MSCHId,string Description,string DataKey,string FilePath)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            
            DataTable tabmsc = new DataTable();
            string sqlmsc = string.Format("Select * from mscheadmaster where MSCHId={0}", MSCHId);
            cmd.CommandText = sqlmsc;
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tabmsc);

            int MSCId = int.Parse(tabmsc.Rows[0]["MSCId"].ToString());

            DataTable tabmc = new DataTable();
            string sqlmc = string.Format("Select mcheadmaster.MCHId from mcheadmaster inner join mscmaster on mcheadmaster.MCId=mscmaster.MCId where mscmaster.MSCId={0}", MSCId);
            cmd.CommandText = sqlmc;
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tabmc);

            int MCHId = int.Parse(tabmc.Rows[0]["MCHId"].ToString());

            string result = "";
            string sql = string.Format("insert into mchmessage(MCHId,MSCId,LogDate,KeyData,Filepath,Status)values({0},{1},'{2}','{3}','{4}','Pending')", MCHId, MSCId, DateTime.Now.ToString("dd/MM/yyyy"), DataKey, FilePath);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();

            return result;
        }
        
        public DataTable GetPostMsgHead(int MCHId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            DataTable tab = new DataTable();

            
            string sqlmsc = string.Format("Select mscmaster.MSCName,mchmessage.SlNo,mchmessage.LogDate,mchmessage.KeyData,mchmessage.FilePath from mchmessage inner join mscmaster on mchmessage.MSCId=mscmaster.MSCId where mchmessage.MCHId={0} and mchmessage.Status='Pending'", MCHId);
            cmd.CommandText = sqlmsc;
            adp = new MySqlDataAdapter(cmd);
            DataTable tabmsc = new DataTable();
            adp.Fill(tabmsc);

            con.Close();
            return tabmsc;
        }

        
    }
}