using System;

namespace Common
{
    [Serializable]
    public class CWear : Message
    {
        public CWear() : base(Command.C_WEAR) { }
        public string new_treasure;  //穿上的treasure
        public string old_treasure;  //如果脱下了原来的，就也要原来的treasure_name,否则为null
        public string treasure_attribute;
        public int treasure_value;
        public int player_id;
    }
}
