using Common;
using System.Collections.Generic;

namespace Gamekit3D.Network
{
    public partial class Incoming
    {
        private void OnRecvTreasure(IChannel channel, Message message)
        {
            STreasure msg = message as STreasure;
            
            Assets._3DGamekit.mycommon.treasure_number = msg.treasure_number;

            foreach(KeyValuePair<string,string>kvp in msg.name_attribute)
            {
                Assets._3DGamekit.mycommon.name_attribute.Add(kvp.Key, kvp.Value);
            }

            foreach (KeyValuePair<string, string> kvp in msg.name_category)
            {
                Assets._3DGamekit.mycommon.name_category.Add(kvp.Key, kvp.Value);
            }

            foreach (KeyValuePair<string, string> kvp in msg.name_status)
            {
                Assets._3DGamekit.mycommon.name_status.Add(kvp.Key, kvp.Value);
            }
            foreach (KeyValuePair<string, int> kvp in msg.name_value)
            {
                Assets._3DGamekit.mycommon.name_value.Add(kvp.Key, kvp.Value);
            }



            //NetworkEntity target = networkEntities[msg.entityId];
            //target.behavior.Die();
        }
    }
}
