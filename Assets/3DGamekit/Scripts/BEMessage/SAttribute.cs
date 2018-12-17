using System;

namespace Common
{
    [Serializable]
    public class SAttribute : Message
    {
        public SAttribute() : base(Command.S_ATTRIBUTE) { }
        public int player_id;
        public int working_value;
        public int luck_value;
        public int attack_value;
        public int gold_coin;
        public int silver_coin;
        public Boolean hunting;
    }
}
