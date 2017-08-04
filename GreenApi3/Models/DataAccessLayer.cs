using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GreenApi3.Models
{
    public class DataAccessLayer
    {
        SqlConnection scon;
        SqlCommand scmd;

        public DataAccessLayer()
        {
            string conn = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();
            scon = new SqlConnection(conn);
        }

        public bool testConn()
        {
            try
            {
                scon.Open();
                return true;
            }
            catch (Exception)
            {
            }
            finally
            {
                scon.Close();
            }
            return false;
        }

        public void uploadData(SensorData sd)
        {
            string query = "INSERT INTO [dbo].[SensorData]([LocationId],[DateStamp],[Temperature],[Proximity],[SmokeLevel],[information],[isAlarming]) ";
            query += " VALUES(1,getutcdate(),{0},{1},{2},'{3}',{4})";
            query = string.Format(query, sd.Temperature.ToString(), sd.Proximity.ToString(), sd.SmokeLevel.ToString(), sd.BatteryStatus, sd.isAlarming);
            scmd = new SqlCommand(query, scon);
            try
            {
                scon.Open();
                scmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                scon.Close();
            }
        }
    }
}