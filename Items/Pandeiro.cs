using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace BahiaMod.Items
{
	public class Pandeiro : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Brazilian Tambourine ready for samba");
		}

		public override void SetDefaults() 
		{
			item.width = 46;
			item.height = 22;
			item.useTime = 15;
			item.scale = 0.5f;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 0;
			item.value = Item.buyPrice(0,0,50,0);
			item.rare = ItemRarityID.Blue;
			item.autoReuse = true;
		}
		public override bool UseItem(Player player)
		{
			if (!Main.dedServ)
			{
				float cursorPosFromPlayer = (player.Distance(Main.MouseWorld) / ((Main.screenHeight / 2) / 24));
				if (cursorPosFromPlayer > 24) cursorPosFromPlayer = 1;
				else cursorPosFromPlayer = (cursorPosFromPlayer / 12) - 1;
				if (cursorPosFromPlayer < 0) Main.PlaySound(SoundID.Item, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/PandeiroKick"), 1, -cursorPosFromPlayer);
				else Main.PlaySound(SoundID.Item, (int)player.Center.X, (int)player.Center.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/PandeiroSnare"), 1, cursorPosFromPlayer);
			}
			return true;
		}
	}
}