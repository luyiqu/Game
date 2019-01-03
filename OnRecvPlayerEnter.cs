using Common;
using Backend.Game;
using System;
using Npgsql;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class Incoming
    {

        private void OnRecvPlayerEnter(IChannel channel, Message message)
        {
            CPlayerEnter request = message as CPlayerEnter;
            STreasure response = new STreasure();

            String connString = "Host=localhost;Port=5432;Username=postgres;Password=592761jy.;Database=game";
            //int player_id = BEGlobal.player_id;

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();

            Console.WriteLine("数据库连接成功");


            var cmd = new NpgsqlCommand(string.Format("SELECT name,attribute,attribute_val,owning.status,category FROM owning,treasure WHERE owning.owner_id = '{0}' AND treasure.treasure_id = owning.treasure_id", request.player_id), conn);

            //var cmd = new NpgsqlCommand("SELECT username,password  FROM player where username = '" + username + "'AND'" + password + "';", conn);

            Console.WriteLine(cmd.CommandText);

            var reader = cmd.ExecuteReader();
            int i = 0;

            while (reader.Read())            // 一定要写这个，不然GetString 读不了
            {
                i++;
                Console.WriteLine(reader.GetString(0)); 
                // 进行很多个判断吧，或者这里定义一个dictionary，name作为key，number作为value，如果存在的话，就在value+1，不存在的话加add进去！
                
                //字典中不存在该宝物， 后面的value和category和属性是不会变得
               if(!response.name_status_count.ContainsKey(reader.GetString(0)))
                {
                    status_count tmp;
                    if (reader.GetString(3) == "wear")
                    {
                        tmp.wear = 1;
                        tmp.inventory = 0;
                        response.name_status_count.Add(reader.GetString(0), tmp);
                        response.name_attribute.Add(reader.GetString(0), reader.GetString(1));
                        response.name_category.Add(reader.GetString(0), reader.GetString(4));
                        response.name_value.Add(reader.GetString(0), reader.GetInt32(2));

                    }
                    else if (reader.GetString(3) == "inventory")
                    {
                        tmp.inventory = 1;
                        tmp.wear = 0;
                        response.name_status_count.Add(reader.GetString(0), tmp);
                        response.name_attribute.Add(reader.GetString(0), reader.GetString(1));
                        response.name_category.Add(reader.GetString(0), reader.GetString(4));
                        response.name_value.Add(reader.GetString(0), reader.GetInt32(2));
                    }    
                    

                }

               //字典中已经存在该宝物
                else
                {
                    status_count tmp;
                    if (reader.GetString(3) == "wear")
                    {
                        tmp.wear = response.name_status_count[reader.GetString(0)].wear;
                        tmp.wear++;
                        tmp.inventory = response.name_status_count[reader.GetString(0)].inventory;

                        response.name_status_count[reader.GetString(0)] = tmp;
                    }
                    else if (reader.GetString(3) == "inventory")
                    {
                        tmp.wear = response.name_status_count[reader.GetString(0)].wear;
                        tmp.inventory = response.name_status_count[reader.GetString(0)].inventory;
                        tmp.inventory++;
                        response.name_status_count[reader.GetString(0)] = tmp;

                    }
                }
              
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
