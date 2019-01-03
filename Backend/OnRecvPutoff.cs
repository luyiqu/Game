using Common;
using Backend.Game;
using Npgsql;
using System;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvPutoff(IChannel channel, Message message)
        {
            CPutoff request = message as CPutoff;
            string old_treasure = request.old_treasure;
            //int update_treasure_attribute_val;


            String connString = "Host=localhost;Port=5432;Username=postgres;Password=592761jy.;Database=game";

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();

            Console.WriteLine("数据库连接成功");


            var cmd = new NpgsqlCommand(string.Format("UPDATE owning SET status = 'inventory' WHERE owner_id = '{0}' AND treasure_id IN (SELECT treasure_id FROM treasure WHERE name = '{1}')", request.player_id, old_treasure), conn);

            Console.WriteLine(cmd.CommandText);

            var update = cmd.ExecuteNonQuery();

            conn.Close();


            NpgsqlConnection conn5 = new NpgsqlConnection(connString);
            conn5.Open();

            Console.WriteLine("插入属性值数据库连接成功");

            if (request.treasure_attribute == "equipment" )
            {
                var cmd5 = new NpgsqlCommand(string.Format("UPDATE player SET attack_value = {0} WHERE player_id = '{1}'", request.treasure_value, request.player_id), conn5);

                Console.WriteLine(cmd5.CommandText);

                var update3 = cmd5.ExecuteNonQuery();

                Console.WriteLine("插入成功");

                conn5.Close();


                //if(request.treasure_attribute == "elixir")
                //{
                //    //删除owning关系！
                //}
            }
            else if (request.treasure_attribute == "accessories")
            {
                var cmd5 = new NpgsqlCommand(string.Format("UPDATE player SET luck_value = {0} WHERE player_id = '{1}'", request.treasure_value,request.player_id), conn5);

                Console.WriteLine(cmd5.CommandText);

                var update3 = cmd5.ExecuteNonQuery();
                Console.WriteLine("插入成功");
                conn5.Close();
            }

            else if (request.treasure_attribute == "tool")
            {
                var cmd5 = new NpgsqlCommand(string.Format("UPDATE player SET working_value =  {0} WHERE player_id = '{1}'", request.treasure_value, request.player_id), conn5);

                Console.WriteLine(cmd5.CommandText);

                var update3 = cmd5.ExecuteNonQuery();
                Console.WriteLine("插入成功");
                conn5.Close();


            }



        }
    }
}
