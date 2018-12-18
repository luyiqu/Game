using Common;
using Backend.Game;
using System;
using Npgsql;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvPlayerEnter(IChannel channel, Message message)
        {
            CPlayerEnter request = message as CPlayerEnter;
            STreasure response = new STreasure();

            String connString = "Host=localhost;Port=5432;Username=postgres;Password=592761jy.;Database=game";
            int player_id = BEGlobal.player_id;

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();

            Console.WriteLine("数据库连接成功");


            var cmd = new NpgsqlCommand(string.Format("SELECT name,attribute,attribute_val,owning.status,category FROM owning,treasure WHERE owning.owner_id = '{0}' AND treasure.treasure_id = owning.treasure_id", player_id), conn);

            //var cmd = new NpgsqlCommand("SELECT username,password  FROM player where username = '" + username + "'AND'" + password + "';", conn);

            Console.WriteLine(cmd.CommandText);

            var reader = cmd.ExecuteReader();
            int i = 0;

            while (reader.Read())            // 一定要写这个，不然GetString 读不了
            {
                i++;
                Console.WriteLine(reader.GetString(0));
                response.name_attribute.Add(reader.GetString(0), reader.GetString(1));
                response.name_category.Add(reader.GetString(0), reader.GetString(4));
                response.name_value.Add(reader.GetString(0), reader.GetInt32(2));
                response.name_status.Add(reader.GetString(0), reader.GetString(3));
            }

            response.treasure_number = i;

            channel.Send(response);

            conn.Close();

            Player player = (Player)channel.GetContent();
            Scene scene = World.Instance.GetScene(player.scene);


          
            // add the player to the scene
            player.Spawn();
            scene.AddEntity(player);
        }
    }
}
