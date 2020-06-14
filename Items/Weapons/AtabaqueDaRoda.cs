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
			item.width = 36;
			item.height = 54;
			item.scale = 0.5f;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 0;
			item.value = Item.sellPrice(0, 1, 83, 0);
			item.shoot = mod.ProjectileType("BahiaNote");
			item.shootSpeed = 4f;
			item.rare = ItemRarityID.Pink;
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