using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BahiaMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Waist)]
	class PurpleCord : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Capoeira Cord (Purple)");
			Tooltip.SetDefault("Grants the \"ginga\" (sway) of Capoeira\n12% increased minion damage and movement speed\nIncreases your max number of minions by 1");
		}

		public override void SetDefaults()
		{
			sbyte realWaistSlot = item.waistSlot;
			item.CloneDefaults(ItemID.BlackBelt);
			item.value = 0;
			item.rare = ItemRarityID.Pink;
			item.waistSlot = realWaistSlot;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.minionDamage += 0.12f;
			player.maxMinions += 1;
			player.moveSpeed += 0.12f;
		}
	}
}