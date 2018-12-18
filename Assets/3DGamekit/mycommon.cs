using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._3DGamekit
{
    public static class mycommon
    {
        //player attribute
        public static int player_id;
        public static int working_value;
        public static int luck_value;
        public static int attack_value;
        public static int gold_coin;
        public static int silver_coin;
        public static Boolean hunting;
        
        //treasure attribute
        public static int treasure_number;
        public static Dictionary<string, string> name_attribute = new Dictionary<string, string>();  // treasure_name : tool, accessories,equipment
        public static Dictionary<string, int> name_value = new Dictionary<string, int>();       //  treasure_name : value
        public static Dictionary<string, string> name_category = new Dictionary<string, string>();    // treasure_name : category
        public static Dictionary<string, string> name_status = new Dictionary<string, string>();   //  treasure_name : wear,inventory

    }
}
