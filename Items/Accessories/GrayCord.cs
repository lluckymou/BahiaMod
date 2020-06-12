using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BahiaMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Waist)]
	class GrayCord : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Capoeira Cord (Gray)");
			Tooltip.SetDefault("Grants the \"ginga\" (sway) of Capoeira\n2% increased minion damage and movement speed");
		}

		public override void SetDefaults()
		{
			sbyte realWaistSlot = item.waistSlot;
			item.CloneDefaults(ItemID.BlackBelt);
			item.value = 40000;
			item.rare = ItemRarityID.Blue;
			item.waistSlot = realWaistSlot;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.minionDamage += 0.02f;
			player.moveSpeed += 0.02f;
		}
	}
}