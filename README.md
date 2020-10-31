# Tranquilizer
The Tranquilizer is a Weapon which looks like a Usp and spawns additionaly to the normal USP in a Position you can set in the Config and can stun almost every class.

The Tranquilizer Itemid is 42 (so you can get it with `giveitem playerid 42`)

# Credits
Original [Scp-TranquilizerGun](https://github.com/NeonWizard/SCP-TranquilizerGun) plugin by [NeonWizard](https://github.com/NeonWizard)

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
