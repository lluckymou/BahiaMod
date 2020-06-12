using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BahiaMod.Items.Placeable
{
	public class EshuCarpet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Use this carpet to connect to the Orishas");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 14;
			item.maxStack = 1;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 10000;
			item.rare = ItemRarityID.Blue;
			item.createTile = TileType<Tiles.EshuCarpet>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 3);
			recipe.AddIngredient(ItemType<Consumable.Offering>());
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}