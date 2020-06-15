using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace BahiaMod.Items.Weapons
{
	public class AtabaqueDaRoda : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Straight from the State of Bahia, Brazil");
		}

		public override void SetDefaults()
		{
			item.summon = true;
			item.damage = 20;
			item.width = 18;
			item.height = 29;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 0;
			item.value = Item.sellPrice(0, 1, 83, 0);
			item.shoot = mod.ProjectileType("BahiaNote");
			item.shootSpeed = 4f;
			item.rare = ItemRarityID.Pink;
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