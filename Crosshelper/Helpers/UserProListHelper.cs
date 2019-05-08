﻿using Crosshelper.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Crosshelper.Helpers
{
    class UserProListHelper
    {
        readonly string connStr = "server=chdb.cakl0xweapqd.us-west-1.rds.amazonaws.com;port=3306;database=chdb;user=chroot;password=ch123456;charset=utf8";

        private List<UserPro> helperlist = new List<UserPro>();
        //internal List<UserPro> Helperlist { get => helperlist; set => helperlist = value; }
        private List<int> helperuidlist = new List<int>();

        public List<UserPro> GetHelperList()
        {
            return helperlist;
        }

        public void SearchingInit()
        {
            foreach (int uid in helperuidlist)
            {
                GetHelperList(uid);
            }
        }

        public void GetProHelperByTag(int tagid)
        {
            //建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr = "SELECT Uid FROM HelperTag WHERE TagID = @para1";
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", tagid);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    helperuidlist.Add(reader.GetInt32(0));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();   //关闭连接              
            }
        }

        public void GetHelperInfoByID(string chatid)
        {
            UserPro helper = new UserPro();
            //建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr = "SELECT Uid FROM HelperInfo,UserInfo WHERE UserInfo.ChatID = @para1";

                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", chatid);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    helperuidlist.Add(reader.GetInt32(0));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();   //关闭连接              
            }
        }


        private void GetHelperList(int userid)
        {
            UserPro helper = new UserPro();
            //并没有建立数据库连接
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr =
                "SELECT FirstName,LastName,Icon,ChatID,FLanguage,SLanguage,PaymentID,Location,Rating,`Status`,PriceSign FROM HelperInfo,UserInfo WHERE HelperInfo.Uid = @para1 AND UserInfo.Uid = @para1";

                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                //通过设置参数的形式给SQL 语句串值
                cmd.Parameters.AddWithValue("para1", userid);
                //cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    helper.FirstName = reader.GetString(0);
                    helper.LastName = reader.GetString(1);
                    helper.Icon = reader.GetString(2);
                    helper.ChatID = reader.GetString(3);
                    helper.FLanguage = reader.GetString(4);
                    helper.SLanguage = reader.GetString(5);
                    helper.PaymentID = reader.GetString(6);
                    helper.Location = reader.GetString(7);
                    helper.Rating = reader.GetInt32(8);
                    helper.Status = reader.GetInt32(9);
                    helper.PriceSign = reader.GetString(10);
                    helper.UserID = userid.ToString();
                    helperlist.Add(helper);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();   //关闭连接              
            }
        }

    }
}
