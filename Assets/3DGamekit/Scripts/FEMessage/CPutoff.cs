using System;

namespace Common
{
    [Serializable]
    public class CPutoff : Message
    {
        public CPutoff() : base(Command.C_PUTOFF) { }
        public string old_treasure;  //穿上的treasure
        public string treasure_attribute;
        public int treasure_value;
        public int player_id;
    }
}
