using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace BahiaMod.Items.Weapons
{
	public class Atabaque : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Don't forget to bring it to the \"Roda\"");
		}

		public override void SetDefaults() 
		{
			item.summon = true;
			item.damage = 18;
			item.width = 16;
			item.height = 21;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 0;
			item.value = Item.sellPrice(0,0,52,0);
			item.shoot = mod.ProjectileType("BahiaNote");
			item.shootSpeed = 4f;
			item.rare = ItemRarityID.Orange;
			if (!Main.dedServ) item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/AtabaqueKick").WithPitchVariance(.2f);
			item.autoReuse = true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (!Main.dedServ) item.UseSound = Main.rand.NextBool() ? mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/AtabaqueKick").WithPitchVariance(.2f) : mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/AtabaqueSnare").WithPitchVariance(.2f);
			return true;
		}
	}
}