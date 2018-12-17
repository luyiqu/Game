using Common;


namespace Gamekit3D.Network
{
    public partial class Incoming
    {
        private void OnRecvAttribute(IChannel channel, Message message)
        {
            SAttribute msg = message as SAttribute;
 
            Assets._3DGamekit.mycommon.working_value = msg.working_value;
            Assets._3DGamekit.mycommon.luck_value = msg.luck_value;
            Assets._3DGamekit.mycommon.player_id = msg.player_id;
            Assets._3DGamekit.mycommon.attack_value = msg.attack_value;
            Assets._3DGamekit.mycommon.gold_coin = msg.gold_coin;
            Assets._3DGamekit.mycommon.silver_coin = msg.silver_coin;
            Assets._3DGamekit.mycommon.hunting = msg.hunting;


            //NetworkEntity target = networkEntities[msg.entityId];
            //target.behavior.Die();
        }
    }
}
