using MEC;
using Synapse.Api;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tranquilizer
{
    public class TranquilizerPlayerScript : MonoBehaviour
    {
        private Player Player => this.GetComponent<Player>(); 

        public bool Stuned { get; private set; }

        public void Stun() => Timing.RunCoroutine(_stun());

        private IEnumerator<float> _stun()
        {
            if (Player.CustomRole != null && PluginClass.Config.BlockedIDs.Any(x => x == Player.CustomRole.GetRoleID())) yield break;
            if (PluginClass.Config.BlockedIDs.Any(x => x == (int)Player.RoleType)) yield break;

            Player.SendBroadcast(5, PluginClass.GetTranslation("stun"));

            Synapse.Api.Ragdoll rag = null;
            if (PluginClass.Config.SpawnRagdoll)
                rag = Map.Get.CreateRagdoll(Player.RoleType, Player.Position, Quaternion.identity, Vector3.zero, new PlayerStats.HitInfo(), false, Player);

            if (PluginClass.Config.DropInventory)
                Player.Inventory.DropAll();

            var pos = Player.Position;
            Player.GodMode = true;
            Player.Position = Vector3.up;

            Stuned = true;

            yield return Timing.WaitForSeconds(UnityEngine.Random.Range(PluginClass.Config.MinStunTime,PluginClass.Config.MaxStunTime));

            if (rag != null) rag.Destroy();
            Player.GodMode = false;
            Player.Position = pos;
            Stuned = false;
        }
    }
}
