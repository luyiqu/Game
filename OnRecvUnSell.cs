using Common;
using Backend.Game;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvUnSell(IChannel channel, Message message)
        {
            CUnSell request = message as CUnSell;
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

           

            //删除market表信息
            NpgsqlConnection conn2 = new NpgsqlConnection(connString);
            conn2.Open();

            Console.WriteLine("数据库连接成功");

            var cmd2 = new NpgsqlCommand(string.Format("DELETE FROM market WHERE seller_id = '{0}' AND treasure_name = '{1}'",player_id,request.name), conn2);
            Console.WriteLine(cmd2.CommandText);
            var delete1 = cmd2.ExecuteNonQuery();
            conn2.Close();

            //将这些信息放入背包
            NpgsqlConnection conn3 = new NpgsqlConnection(connString);
            conn3.Open();

            Console.WriteLine("数据库连接成功");

            var cmd3 = new NpgsqlCommand(string.Format("INSERT INTO owning(treasure_id,owner_id,status) VALUES({0},{1},'inventory')",treasure_id,player_id),conn3);
            Console.WriteLine(cmd3.CommandText);
            var insert1 = cmd3.ExecuteNonQuery();
            Console.WriteLine("宝物撤销挂牌成功！");
            conn3.Close();

        }
    }
}
