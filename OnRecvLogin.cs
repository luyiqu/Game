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
            CLogin request = message as CLogin;            // 
            SPlayerEnter response = new SPlayerEnter();    //进入那个场景的response
            string scene = "Level1";
            response.user = request.user;
            response.token = request.user;
            response.scene = scene;
            
            
            Console.WriteLine("Login start");

            string username = request.user;  //取出账号
            string password = request.password;         //取出密码
            //Console.WriteLine("username" + username);
            //Console.WriteLine("password" + password);


             

            // Host info
            String connString = "Host=localhost;Port=5432;Username=postgres;Password=592761jy.;Database=Game";

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();

            //Console.WriteLine("数据库连接成功");


            var cmd = new NpgsqlCommand(string.Format("SELECT password FROM player WHERE username = '{0}'", username), conn);

            //var cmd = new NpgsqlCommand("SELECT username,password  FROM player where username = '" + username + "'AND'" + password + "';", conn);

            //Console.WriteLine(cmd.CommandText);

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
                    Console.WriteLine(password);
                    ClientTipInfo(channel, "Welcome to the 3d Gamekit");
                    channel.Send(response);
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
