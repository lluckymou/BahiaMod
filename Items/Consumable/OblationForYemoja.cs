using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BahiaMod.Items.Consumable
{
    public class OblationForYemoja : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oblation For Iemanjá");
            Tooltip.SetDefault("Sends prayers directly to Yemoja\nManipulates the moon and seas");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.useAnimation = 15;
            item.useTime = 15;
            item.maxStack = 15;
            item.value = 0;
            item.rare = ItemRarityID.Green;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.UseSound = SoundID.Item46;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            if (Main.dayTime)
            {
                Main.time = 0.0;
                Main.dayTime = false;
            }
            else Main.time = 27000.0;

            Main.NewText("Yemoja listened to your prayers", 50, 255, 130);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.AddIngredient(ItemType<OtherworldlyEssence>());
            recipe.AddIngredient(ItemType<Offering>());
            recipe.AddTile(mod.TileType("EshuCarpet"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}