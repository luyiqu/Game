using Common;
using Backend.Game;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvSell(IChannel channel, Message message)
        {
            CSell request = message as CSell;
            string player_id = request.player_id;

            String connString = "Host=localhost;Port=5432;Username=postgres;Password=592761jy.;Database=game";

            //读treasure_id从treasure表
            NpgsqlConnection conn1 = new NpgsqlConnection(connString);
            conn1.Open();

            Console.WriteLine("数据库连接成功");
            var cmd1 = new NpgsqlCommand(string.Format("SELECT treasure_id FROM treasure WHERE name =  '{0}'", request.name), conn1);

            //var cmd = new NpgsqlCommand("SELECT username,password  FROM player where username = '" + username + "'AND'" + password + "';", conn);

            Console.WriteLine(cmd1.CommandText);

            var reader1 = cmd1.ExecuteReader();

            reader1.Read();

            int treasure_id = reader1.GetInt32(0);

            conn1.Close();

            //读player_name 从player表

            NpgsqlConnection conn5 = new NpgsqlConnection(connString);
            conn5.Open();

            Console.WriteLine("数据库连接成功");
            var cmd5 = new NpgsqlCommand(string.Format("SELECT username FROM player WHERE player_id =  '{0}'", player_id), conn5);

            //var cmd = new NpgsqlCommand("SELECT username,password  FROM player where username = '" + username + "'AND'" + password + "';", conn);

            Console.WriteLine(cmd1.CommandText);

            var reader2 = cmd5.ExecuteReader();

            reader2.Read();

            int player_name = reader2.GetInt32(0);

            conn5.Close();

            //删除owning表信息
            NpgsqlConnection conn2 = new NpgsqlConnection(connString);
            conn2.Open();

            Console.WriteLine("数据库连接成功");

            var cmd2 = new NpgsqlCommand(string.Format("DELETE FROM owning WHERE treasure_id = '{0}'", treasure_id), conn2);
            Console.WriteLine(cmd2.CommandText);
            var delete1 = cmd2.ExecuteNonQuery();
            conn2.Close();

            //将这些信息放入市场
            NpgsqlConnection conn3 = new NpgsqlConnection(connString);
            conn3.Open();

            Console.WriteLine("数据库连接成功");

            var cmd3 = new NpgsqlCommand(string.Format("INSERT INTO market(treasure_id,treasure_name,number,seller_id,seller_name,coin,price) VALUES({0},'{1}',{2},{3},'{4}',{5},{6})", treasure_id,request.name,request.number,player_id,player_name,request.coin,request.cost), conn3);
            Console.WriteLine(cmd3.CommandText);
            var insert1 = cmd3.ExecuteNonQuery();
            Console.WriteLine("市场插入成功！");
            conn3.Close();

        }
    }
}
