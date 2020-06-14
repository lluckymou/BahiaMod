using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BahiaMod.Items.Weapons
{
	public class MastersBerimbau : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Master's Berimbau");
			Tooltip.SetDefault("A traditional Berimbau, but only for the most experienced");
		}

		public override void SetDefaults() 
		{
			item.summon = true;
			item.damage = 20;
			item.width = 40;
			item.height = 40;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 7;
			item.value = Item.sellPrice(0, 0, 26, 0);
			item.shoot = mod.ProjectileType("BahiaNote");
			item.shootSpeed = 2.5f;
			item.rare = ItemRarityID.Green;
			if (!Main.dedServ) item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Berimbau").WithPitchVariance(.2f);
			item.autoReuse = false;
		}
	}
}