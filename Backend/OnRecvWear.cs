using Common;
using Backend.Game;
using Npgsql;
using System;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvWear(IChannel channel, Message message)
        {
            CWear request = message as CWear;
            string new_treasure = request.new_treasure;
            string old_treasure = request.old_treasure;
            //int update_treasure_attribute_val;


            String connString = "Host=localhost;Port=5432;Username=postgres;Password=592761jy.;Database=game";

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();

            Console.WriteLine("数据库连接成功");


            var cmd = new NpgsqlCommand(string.Format("UPDATE owning SET status = 'wear' WHERE owner_id = '{0}' AND treasure_id IN (SELECT treasure_id FROM treasure WHERE name = '{1}')", request.player_id,new_treasure), conn);

            Console.WriteLine(cmd.CommandText);

            var update = cmd.ExecuteNonQuery();

            conn.Close();


            NpgsqlConnection conn5 = new NpgsqlConnection(connString);
            conn5.Open();

            Console.WriteLine("插入属性值数据库连接成功");

            if (request.treasure_attribute == "equipment" || request.treasure_attribute == "elixir") 
            {
                var cmd5 = new NpgsqlCommand(string.Format("UPDATE player SET attack_value = {0} WHERE player_id = '{1}'", request.treasure_value, request.player_id), conn5);

                Console.WriteLine(cmd5.CommandText);

                var update3 = cmd5.ExecuteNonQuery();

                Console.WriteLine("插入成功");

                conn5.Close();

            }
            else if (request.treasure_attribute == "accessories")
            {
                var cmd5 = new NpgsqlCommand(string.Format("UPDATE player SET luck_value = {0} WHERE player_id = '{1}'", request.treasure_value, request.player_id), conn5);

                Console.WriteLine(cmd5.CommandText);

                var update3 = cmd5.ExecuteNonQuery();
                Console.WriteLine("插入成功");
                conn5.Close();
            }

            else if(request.treasure_attribute == "tool")
            {
                var cmd5 = new NpgsqlCommand(string.Format("UPDATE player SET working_value =  {0} WHERE player_id = '{1}'", request.treasure_value,request.player_id), conn5);

                Console.WriteLine(cmd5.CommandText);

                var update3 = cmd5.ExecuteNonQuery();
                Console.WriteLine("插入成功");
                conn5.Close();


            }

            if(request.treasure_attribute == "elixir")
            {
                NpgsqlConnection conn4 = new NpgsqlConnection(connString);
                conn4.Open();
                var cmd4 = new NpgsqlCommand(string.Format("DELETE FROM owning WHERE owner_id = '{0}' AND treasure_id IN (SELECT treasure_id FROM treasure WHERE name = '{1}')", request.player_id, new_treasure), conn4);
                Console.WriteLine(cmd4.CommandText);
                var delete = cmd4.ExecuteNonQuery();
                Console.WriteLine("删除成功");
                conn4.Close();

            }
            


            if (old_treasure != string.Empty)
            {


                NpgsqlConnection conn3 = new NpgsqlConnection(connString);
                conn3.Open();

                Console.WriteLine("数据库连接成功");


                var cmd3 = new NpgsqlCommand(string.Format("UPDATE owning SET status = 'inventory' WHERE owner_id = '{0}' AND treasure_id IN (SELECT treasure_id FROM treasure WHERE name = '{1}')", request.player_id, old_treasure), conn3);

                Console.WriteLine(cmd3.CommandText);

                var update2 = cmd3.ExecuteNonQuery();

                conn3.Close();

                //// 获取treasure_attribute 和 treasure_val 
                //NpgsqlConnection conn4 = new NpgsqlConnection(connString);
                //conn4.Open();

                //Console.WriteLine("数据库连接成功");

                //var cmd4 = new NpgsqlCommand(string.Format("SELECT attribute,attribute_val FROM treasure WHERE name = '{0}'", old_treasure), conn4);

                //Console.WriteLine(cmd4.CommandText);

                //var reader2 = cmd4.ExecuteReader();

                //reader2.Read();
                //old_treasure_attribute = reader2.GetString(0);
                //old_treasure_attribute_val = reader2.GetInt32(1);

                //conn4.Close();

                //diff_treasure_attibute_val = new_treasure_attribute_val - old_treasure_attribute_val;

            }

            //else
            // {
            //     Console.WriteLine("********OLD_ATTRIBUTE**********************");
            //     diff_treasure_attibute_val = new_treasure_attribute_val;
            // }

            //updata the attribute_val



        }
    }
}
