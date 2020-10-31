using Synapse.Config;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tranquilizer
{
    public class Config : AbstractConfigSection
    {
        [Description("The Maximal Amount of time a Player can be stuned")]
        public float MaxStunTime = 15f;

        [Description("The Minimal Amount of time a Player is stuned")]
        public float MinStunTime = 10f;

        [Description("If Enabled a Player who got shoot at with a tranquilizer drops all his Items")]
        public bool DropInventory = false;

        [Description("If Enabled a Ragdoll will Spawn at the Position where the Player is tranquilized")]
        public bool SpawnRagdoll = true;

        [Description("If Enabled the Tranquilizer can be Reloaded with 18 Ammo9")]
        public bool Reloadable = true;

        [Description("All RoleIds in this List cant be stuned (also CustomRoles)")]
        public List<int> BlockedIDs = new List<int>() { (int)RoleType.Scp173, (int)RoleType.Scp106 };

        [Description("The Positions where the Tranquilizer should Spawn")]
        public List<SerializedMapPoint> TranquilizerSpawns = new List<SerializedMapPoint>() { new SerializedMapPoint("HCZ_457", -1.808868f, 1.330017f, -1.078156f) };
    }
}
