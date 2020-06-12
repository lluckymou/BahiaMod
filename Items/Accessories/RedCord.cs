using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BahiaMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Waist)]
	class RedCord : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Capoeira Cord (Red)");
			Tooltip.SetDefault("Grants the \"ginga\" (sway) of Capoeira\n15% increased minion damage and movement speed\nIncreases your max number of minions by 1");
		}

		public override void SetDefaults()
		{
			sbyte realWaistSlot = item.waistSlot;
			item.CloneDefaults(ItemID.BlackBelt);
			item.value = 0;
			item.rare = ItemRarityID.Lime;
			item.waistSlot = realWaistSlot;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.minionDamage += 0.15f;
			player.maxMinions += 1;
			player.moveSpeed += 0.15f;
		}
	}
}