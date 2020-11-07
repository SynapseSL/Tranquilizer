using Synapse;
using Synapse.Api.Plugin;
using System.Collections.Generic;

namespace Tranquilizer
{
    //Original: https://github.com/NeonWizard/SCP-TranquilizerGun
    [PluginInformation(
        Author = "Dimenzio",
        Description = "A Plugin which adds the Tranquilizer to the Game (ID 42)",
        LoadPriority = 1,
        Name = "Tranquilizer",
        SynapseMajor = SynapseController.SynapseMajor,
        SynapseMinor = SynapseController.SynapseMinor,
        SynapsePatch = SynapseController.SynapsePatch,
        Version = "v.1.0.1"
        )]
    public class PluginClass : AbstractPlugin
    {
        [Synapse.Api.Plugin.Config(section = "Tranquilizer")]
        public static Config Config;

        private static PluginClass pclass;

        public override void Load()
        {
            pclass = this;
            Server.Get.ItemManager.RegisterCustomItem(new Synapse.Api.Items.CustomItemInformation()
            {
                BasedItemType = ItemType.GunUSP,
                ID = TranquilizerID,
                Name = "Tranquilizer"
            });

            var trans = new Dictionary<string, string>
            {
                {"pickuptranq","<b>You picked up a <color=blue>Tranquilizer</color>!\nThis Weapon will stun your enemys</b>" },
                {"stun","<b>You are stuned by a <color=blue>Tranquilizer</color></b>" },
                {"noammo","You dont have enough Ammo to Reload your Tranquilizer" },
                {"stuneddrop","You cant drop any Item while you are stuned!" },
                {"noreload","You cant Reload the Tranquilizer on this Server" }
            };
            Translation.CreateTranslations(trans);

            new EventHandlers();
        }

        public static string GetTranslation(string key) => pclass.Translation.GetTranslation(key);

        public const int TranquilizerID = Synapse.Api.Items.ItemManager.HighestItem + 1;
    }
}
