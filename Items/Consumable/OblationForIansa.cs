﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using static Terraria.ModLoader.ModContent;

namespace BahiaMod.Items.Consumable
{
    public class OblationForIansa : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oblation For Iansã");
            Tooltip.SetDefault("Sends prayers directly to Oya\nManipulates strong desert winds");
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
            if (Sandstorm.Happening) BahiaMod.StopSandstorm();
            else BahiaMod.StartSandstorm();

            Main.NewText("Oya listened to your prayers", 50, 255, 130);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 20);
            recipe.AddIngredient(ItemType<OtherworldlyEssence>(), 2);
            recipe.AddIngredient(ItemType<Offering>());
            recipe.AddTile(mod.TileType("EshuCarpet"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}