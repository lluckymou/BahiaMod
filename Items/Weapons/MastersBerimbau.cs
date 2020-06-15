using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
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
			item.autoReuse = false;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (!Main.dedServ)
			{
				float cursorPosFromPlayer = (player.Distance(Main.MouseWorld) / ((Main.screenHeight / 2) / 24));
				if (cursorPosFromPlayer > 18) cursorPosFromPlayer = 0.45f;
				else cursorPosFromPlayer = (cursorPosFromPlayer / 12) - 1;
				if (cursorPosFromPlayer < -0.5) cursorPosFromPlayer = -0.5f;
				Main.PlaySound(SoundID.Item, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/Berimbau"), 1, cursorPosFromPlayer);
			}
			return true;
		}
	}
}