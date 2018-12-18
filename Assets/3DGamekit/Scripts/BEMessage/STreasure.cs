using System;
using System.Collections.Generic;
namespace Common
{
    [Serializable]
    public class STreasure : Message
    {
        public STreasure() : base(Command.S_TREASURE) { }
        public int treasure_number;
        public Dictionary<string, string> name_attribute = new Dictionary<string, string>();  // treasure_name : tool, accessories,equipment 
        public Dictionary<string, int> name_value = new Dictionary<string, int>();       //  treasure_name : value
        public Dictionary<string, string> name_category = new Dictionary<string, string>();   // treasure_name : category
        public Dictionary<string, string> name_status = new Dictionary<string, string>();   //  treasure_name : wear,inventory


    }
}
