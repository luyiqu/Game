using Common;
using Backend.Game;
using Npgsql;
using System;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvLogin(IChannel channel, Message message)   
        {
            CLogin request = message as CLogin;            
            SPlayerEnter response = new SPlayerEnter();    //进入那个场景的response
            SAttribute response1 = new SAttribute();

            string scene = "Level1";
            response.user = request.user;
            response.token = request.user;
            response.scene = scene;
            


            Console.WriteLine("Login start");

            string username = request.user;  //取出账号
            string password = request.password;         //取出密码
            Console.WriteLine("username" + username);
            Console.WriteLine("password" + password);


             

            // Host info
            String connString = "Host=localhost;Port=5432;Username=postgres;Password=592761jy.;Database=Game";

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();

            Console.WriteLine("数据库连接成功");


            var cmd = new NpgsqlCommand(string.Format("SELECT password, player_id,working_value,luck_value,attack_value,gold_coin,silver_coin,hunting FROM player WHERE username = '{0}'", username), conn);

            //var cmd = new NpgsqlCommand("SELECT username,password  FROM player where username = '" + username + "'AND'" + password + "';", conn);

            Console.WriteLine(cmd.CommandText);

            var reader = cmd.ExecuteReader();     
           

            //Console.WriteLine(reader.HasRows);
            
           
           if(!reader.HasRows)            // 一定要写这个，不然GetString 读不了
            {
                ClientTipInfo(channel, "User doesn't exist");    

            }
           else 
            {
                reader.Read();
                if (reader.GetString(0) == password)
                {
                    Console.WriteLine(reader.GetString(0));

                    response1.player_id = reader.GetInt32(1);
                    response1.working_value = reader.GetInt32(2);    //是32位的吗
                    response1.luck_value = reader.GetInt32(3);
                    response1.attack_value = reader.GetInt32(4);
                    response1.gold_coin = reader.GetInt32(5);
                    response1.silver_coin = reader.GetInt32(6);
                    response1.hunting = reader.GetBoolean(7);

                    Console.WriteLine(response1.player_id);
                    Console.WriteLine(response1.working_value);
                    Console.WriteLine(response1.luck_value);
                    Console.WriteLine(response1.attack_value);
                    Console.WriteLine(response1.gold_coin);
                    Console.WriteLine(response1.silver_coin);
                    Console.WriteLine(response1.hunting);

                    Console.WriteLine(password);
                    ClientTipInfo(channel, "Welcome to the 3d Gamekit");
                    channel.Send(response);
                    channel.Send(response1);   //需要传吗？
                }
                else
                {
                    ClientTipInfo(channel, "password is wrong");
                }
            }



            Console.WriteLine("login end");



            conn.Close();
            Player player = new Player(channel);
            player.scene = scene;
            // TODO read from database
            DEntity dentity = World.Instance.EntityData["Ellen"];
            player.FromDEntity(dentity);
            player.forClone = false;
            //ClientTipInfo(channel, "TODO: get player's attribute from database");
            // player will be added to scene when receive client's CEnterSceneDone message
        }
    }
}
