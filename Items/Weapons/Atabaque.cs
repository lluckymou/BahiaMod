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
			item.autoReuse = true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (!Main.dedServ)
			{
				float cursorPosFromPlayer = (player.Distance(Main.MouseWorld) / ((Main.screenHeight / 2) / 24));
				if (cursorPosFromPlayer > 24) cursorPosFromPlayer = 1;
				else cursorPosFromPlayer = (cursorPosFromPlayer / 12) - 1;
				if (cursorPosFromPlayer < 0) Main.PlaySound(SoundID.Item, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/AtabaqueKick"), 1, -cursorPosFromPlayer);
				else Main.PlaySound(SoundID.Item, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/AtabaqueSnare"), 1, cursorPosFromPlayer);
			}
			return true;
		}
	}
}