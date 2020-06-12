using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace BahiaMod.Items.Consumable
{
    public class Offering : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Offering to the Orishas\nDo not eat");
        }

        public override void SetDefaults()
        {
            item.useTime = 15;
            item.useAnimation = 15;
            item.width = 30;
            item.height = 18;
            item.maxStack = 30;
            item.value = 6000;
            item.rare = ItemRarityID.Blue;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.UseSound = SoundID.Item2;
            item.consumable = true;
        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)(Main.LocalPlayer.position.X) + 16*20, (int)(Main.LocalPlayer.position.Y) + 16*30, mod.NPCType("AngrySpirit"));
            Main.LocalPlayer.AddBuff(BuffID.Slow, 1800);
            Main.LocalPlayer.AddBuff(BuffID.Stinky, 1800);
            return true;
        }
    }
}