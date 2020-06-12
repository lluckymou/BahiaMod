using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.Enums;

namespace BahiaMod.Tiles
{
    class FlagOfBahia : ModTile
    {
		public override void SetDefaults()
		{
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.CoordinateHeights = new[] {16,16,16};
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidWithTop | AnchorType.SolidTile, TileObjectData.newTile.Width - 2, 0);
			TileObjectData.newTile.Origin = new Point16(0, 2);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Flag Of Bahia");
			AddMapEntry(new Color(200, 200, 200), name);
			animationFrameHeight = 54;
			dustType = DustID.Marble;
			disableSmartCursor = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			Main.tileWaterDeath[Type] = true;
		}

		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frameCounter = (frameCounter + 1) % 11;
			if (frameCounter > 9) frame = (frame + 1) % 4;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 48, 32, mod.ItemType("FlagOfBahia"));
		}
	}
}
