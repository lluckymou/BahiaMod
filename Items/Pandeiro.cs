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
			item.useTime = 25;
			item.scale = 0.5f;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 0;
			item.value = Item.buyPrice(0,0,50,0);
			item.rare = ItemRarityID.Blue;
			if (!Main.dedServ) item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/PandeiroKick").WithPitchVariance(.2f);
			item.autoReuse = true;
		}
		public override bool UseItem(Player player)
		{
			if (!Main.dedServ) item.UseSound = Main.rand.NextBool() ? mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/PandeiroKick").WithPitchVariance(.2f) : mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/PandeiroSnare").WithPitchVariance(.2f);
			return true;
		}
	}
}