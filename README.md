# Tranquilizer
It' a Custom Weapon Plugin for SCP:SL(Synapse 2) that adds a tranquilizer gun (it doesn't replace a already existing weapon!).When a player is shot by it, they are temporarily ragdolled for the duration of the tranquilization

# ItemInformations
```
ItemID: 36
ItemName: Tranquilizer
BasedItemType: USP
```

# Credits
Original [Scp-TranquilizerGun](https://github.com/NeonWizard/SCP-TranquilizerGun) plugin by [NeonWizard](https://github.com/NeonWizard)

# Installation
1. Install Synapse 2
2. Place the latest Tranquilizer.dll in `~/Synapse/plugins/server-{serverport}`

# Config
| ConfigName | Type | Description |
| :-------------: | :---------: | :------ |
| maxStunTime | Integer | The longest time a Player can be stuned |
| minStunTime | Integer | The shortest time a Player can be stuned |
| dropInventory | Boolean | If the Player should drop his Inventory when he get stuned |
| spawnRagdoll | Boolean | If a Ragdoll should spawn when a Player get stuned |
| reloadable | Boolean | If the Tranquilizer can be reloaded |
| blockedIDs | Integer list | The RoleIDs which can't be stuned |
| tranquilizerSpawns | MapPoint List | The Position's where the Tranquilizer spawns |

Default:
```
[Tranquilizer]
{
maxStunTime: 15
minStunTime: 10
dropInventory: false
spawnRagdoll: true
reloadable: true
blockedIDs:
- 0
- 3
tranquilizerSpawns:
- room: HCZ_457
  x: -1.80886805
  y: 1.33001697
  z: -1.07815599
}
```
