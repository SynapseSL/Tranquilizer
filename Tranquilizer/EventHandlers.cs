using Synapse;
using Synapse.Api.Items;

namespace Tranquilizer
{
    internal class EventHandlers
    {
        internal EventHandlers()
        {
            Server.Get.Events.Player.PlayerPickUpItemEvent += OnPickup;
            Server.Get.Events.Player.LoadComponentsEvent += OnLoad;
            Server.Get.Events.Round.RoundStartEvent += RoundStart;
            Server.Get.Events.Player.PlayerReloadEvent += OnReload;
            Server.Get.Events.Player.PlayerDropItemEvent += OnDrop;
            Server.Get.Events.Player.PlayerShootEvent += OnShoot;
        }

        private void OnShoot(Synapse.Api.Events.SynapseEventArguments.PlayerShootEventArgs ev)
        {
            if(ev.Weapon.ID == PluginClass.TranquilizerID)
            {
                ev.Weapon.Durabillity = 0;
                if (ev.Target != null)
                {
                    ev.Target.GetComponent<TranquilizerPlayerScript>().Stun();
                    ev.Allow = false;
                }
            }
        }

        private void OnDrop(Synapse.Api.Events.SynapseEventArguments.PlayerDropItemEventArgs ev)
        {
            if (!ev.Player.GetComponent<TranquilizerPlayerScript>().Stuned) return;

            ev.Allow = false;
            ev.Player.GiveTextHint(PluginClass.GetTranslation("stuneddrop"));
        }

        private void OnReload(Synapse.Api.Events.SynapseEventArguments.PlayerReloadEventArgs ev)
        {
            if (ev.Item.ID != PluginClass.TranquilizerID) return;

            if (!PluginClass.Config.Reloadable)
            {
                ev.Allow = false;
                ev.Player.GiveTextHint(PluginClass.GetTranslation("noreload"));
                return;
            }

            if (ev.Player.Ammo9 >= 18) return;

            ev.Allow = false;
            ev.Player.GiveTextHint(PluginClass.GetTranslation("noammo"));
        }

        private void RoundStart()
        {
            foreach(var point in PluginClass.Config.TranquilizerSpawns)
            {
                var item = new SynapseItem(PluginClass.TranquilizerID, 18, 0, 0, 0);
                item.Position = point.Parse().Position;
                item.Drop();
            }
        }

        private void OnLoad(Synapse.Api.Events.SynapseEventArguments.LoadComponentEventArgs ev)
        {
            if (ev.Player.GetComponent<TranquilizerPlayerScript>() == null)
                ev.Player.AddComponent<TranquilizerPlayerScript>();
        }

        private void OnPickup(Synapse.Api.Events.SynapseEventArguments.PlayerPickUpItemEventArgs ev)
        {
            if (ev.Item.ID == PluginClass.TranquilizerID)
                ev.Player.SendBroadcast(7, PluginClass.GetTranslation("pickuptranq"));
        }
    }
}
