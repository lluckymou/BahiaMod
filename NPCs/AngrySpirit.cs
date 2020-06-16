using BahiaMod.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BahiaMod.NPCs
{
	public class AngrySpirit : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Wraith];
		}

		public override void SetDefaults()
		{
			npc.width = 24;
			npc.height = 44;
			npc.damage = 30;
			npc.defense = 16;
			npc.lifeMax = 120;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 420f;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.alpha = 100;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 22;
			aiType = NPCID.Wraith;
			animationType = NPCID.Wraith;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, DustID.Smoke);
			}
		}
		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), ItemType<OtherworldlyEssence>());
		}
	}
}