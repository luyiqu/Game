using Common;
using Backend.Game;
using System;
using System.IO;
using Npgsql;

namespace Backend.Network
{
    public partial class Incoming
    {
        private void OnRecvRegister(IChannel channel, Message message)
        {
            // TODO ...
            // write to database

            CRegister request = message as CRegister;

           
            Console.WriteLine("Register start");

            string username = request.user;  //取出账号
            string password = request.password;         //取出密码
            string pwRepeat = request.pwRepeat;

            Console.WriteLine("username" + username);
            Console.WriteLine("password" + password);
            Console.WriteLine("pwRepeat" + pwRepeat);

            if(password != pwRepeat)
            {
                ClientTipInfo(channel, "Password mismatch");
            }
            else
            {
                String connString = "Host=localhost;Port=5432;Username=postgres;Password=592761jy.;Database=Game";

                NpgsqlConnection conn = new NpgsqlConnection(connString);
                conn.Open();

                Console.WriteLine("数据库连接成功");

                var cmd1 = new NpgsqlCommand(string.Format("SELECT password FROM player WHERE username = '{0}'", username), conn);

                Console.WriteLine(cmd1.CommandText);
                var reader1 = cmd1.ExecuteReader();
                var result = reader1.Read();
                conn.Close();
                if (result)
                {
                    ClientTipInfo(channel, "Username already exists");
                    
                }
                
                else
                {

                        
                    NpgsqlConnection conn3 = new NpgsqlConnection(connString);
                    conn3.Open();


                    //这里还需要插入playerID
                    var cmd3 = new NpgsqlCommand(string.Format("INSERT INTO player(username,password,working_value,luck_value,attack_value,gold_coin,silver_coin,hunting)VALUES('{0}','{1}',100,100,100,33,100,FALSE)", username, password), conn3);

                    Console.WriteLine(cmd3.CommandText);
                    var insert3 = cmd3.ExecuteNonQuery();
                    Console.WriteLine(insert3);
                    if (insert3 > 0)
                    {
                        ClientTipInfo(channel, "TODO: write register info to database");
                    }

                    conn3.Close();

                }


            }

        }
    }
}
