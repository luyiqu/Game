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

                conn.Close();

                if (reader1.Read())
                {
                    ClientTipInfo(channel, "Username already exists");
                }
                else
                {

                    NpgsqlConnection conn2 = new NpgsqlConnection(connString);
                    conn2.Open();

                    var cmd2 = new NpgsqlCommand(string.Format("INSERT INTO player(username,password) VALUES('{0}','{1}')", username, password), conn2);

                    Console.WriteLine(cmd2.CommandText);
                    var insert2 = cmd2.ExecuteNonQuery();
                    Console.WriteLine(insert2);
                    if (insert2 > 0)
                    {
                        ClientTipInfo(channel, "TODO: write register info to database");
                    }

                    conn2.Close();

                }


            }

        }
    }
}
