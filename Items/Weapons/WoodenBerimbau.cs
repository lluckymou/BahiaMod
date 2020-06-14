using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BahiaMod.Items.Weapons
{
	public class WoodenBerimbau : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Classic Berimbau similar to those from Salvador, Bahia");
		}

		public override void SetDefaults() 
		{
			item.summon = true;
			item.damage = 7;
			item.width = 40;
			item.height = 40;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 2;
			item.value = Item.sellPrice(0, 0, 0, 40);
			item.shoot = mod.ProjectileType("BahiaNote");
			item.shootSpeed = 2.5f;
			item.rare = ItemRarityID.White;
			if (!Main.dedServ) item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Berimbau").WithPitchVariance(.2f);
			item.autoReuse = false;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PalmWood, 15);
			recipe.AddIngredient(ItemID.Wood, 2);
			recipe.AddIngredient(ItemID.StoneBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}