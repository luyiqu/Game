using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class CUnSell : Message
    {
        public CUnSell() : base(Command.C_UNSELL) { }
        //public Dictionary<string, market_commodity_info> market_commodity;     //treausre_name : coin，cost,number
        public string player_id;        //player_id
        public string name;             //treasure_name

    }
}
