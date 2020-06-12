using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BahiaMod.Items.Placeable
{
	public class FlagOfBahia : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Not to be confused with the US' flag");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 22;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 500;
			item.rare = ItemRarityID.White;
			item.createTile = TileType<Tiles.FlagOfBahia>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddIngredient(ItemID.Wood, 4);
			recipe.AddRecipeGroup("IronBar");
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}