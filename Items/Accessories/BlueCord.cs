using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BahiaMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Waist)]
	class BlueCord : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Capoeira Cord (Blue)");
			Tooltip.SetDefault("Grants the \"ginga\" (sway) of Capoeira\n7% increased minion damage and movement speed");
		}

		public override void SetDefaults()
		{
			sbyte realWaistSlot = item.waistSlot;
			item.CloneDefaults(ItemID.BlackBelt);
			item.value = 0;
			item.rare = ItemRarityID.Orange;
			item.waistSlot = realWaistSlot;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.minionDamage += 0.07f;
			player.moveSpeed += 0.07f;
		}
	}
}