using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class CSell : Message
    {
        public CSell() : base(Command.C_SELL) { }
        //public Dictionary<string, market_commodity_info> market_commodity;     //treausre_name : coin，cost,number
        public string player_id;        //player_id
        public string name;             //treasure_name
        public Boolean coin;            //true -- gold   //  false -- silver
        public int cost;                //price
        public int number;              //number

    }
}
