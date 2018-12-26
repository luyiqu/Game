using System;
using System.Collections.Generic;
namespace Common
{
    [Serializable]
    public struct status_count
    {
        public int wear; //the number of the items that wearing
        public int inventory; //the number  of the items that in inventory;
    }


    [Serializable]
    public class STreasure : Message
    {
        public STreasure() : base(Command.S_TREASURE) { }
        public int treasure_number;
        public Dictionary<string, string> name_attribute = new Dictionary<string, string>();  // treasure_name : tool, accessories,equipment 
        public Dictionary<string, int> name_value = new Dictionary<string, int>();       //  treasure_name : value
        public Dictionary<string, string> name_category = new Dictionary<string, string>();   // treasure_name : category
        //public Dictionary<string, string> name_status = new Dictionary<string, string>();   //  treasure_name : wear,inventory
        public Dictionary<string, status_count> name_status_count = new Dictionary<string, status_count>();

    }



}
