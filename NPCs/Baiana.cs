using Microsoft.Xna.Framework;
using BahiaMod.Items;
using BahiaMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BahiaMod.NPCs
{
	[AutoloadHead]
	public class Baiana : ModNPC
	{
		public override string Texture => "BahiaMod/NPCs/Baiana";

		public override string[] AltTextures => new[] { "BahiaMod/NPCs/Baiana_Alt_1" };

		public override bool Autoload(ref string name)
		{
			name = "Baiana";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 10;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					continue;
				}

				foreach (Item item in player.inventory)
				{
					if (item.type == ItemType<Items.Weapons.WoodenBerimbau>())
					{
						return true;
					}
				}
			}
			return false;
		}

		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(4))
			{
				case 0:
					return "Marileide";
				case 1:
					return "Maria Redonda";
				case 2:
					return "Dandara";
				default:
					return "Abá";
			}
		}
		public override void FindFrame(int frameHeight)
		{
		}

		public override string GetChat()
		{
			switch (Main.rand.Next(5))
			{
				case 0:
					return "You should visit my Bahia someday... It's breath-taking";
				case 1:
					return "Take care of the oceans. You don't want to anger Yemoja, do you?";
				case 2:
					{
						Main.npcChatCornerItem = ItemType<Items.Accessories.RedCord>();
						return "What about increasing your capoeira skills?";
					}
				case 3:
					return "I know you want to interact with the realm of the Orishas, but before that I have to prepare you for such responsibility";
				default:
					return "Do you want some Acarajé my king? I've got some delicious dishes if you want to";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
			button2 = "Capoeira Quests";
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			} 
			else
            {
				if (NPC.downedBoss1)
				{
					if (Main.LocalPlayer.HasItem(ItemType<Items.Accessories.GrayCord>()))
					{
						if (Main.LocalPlayer.HasItem(ItemType<Items.Weapons.WoodenBerimbau>()) && NPC.downedBoss2) // Quest requirements
						{
							Main.LocalPlayer.inventory[
								Main.LocalPlayer.FindItem(ItemType<Items.Weapons.WoodenBerimbau>())
							].TurnToAir();
							Main.LocalPlayer.inventory[
								Main.LocalPlayer.FindItem(ItemType<Items.Accessories.GrayCord>())
							].TurnToAir();
							Main.PlaySound(SoundID.Item105);
							Main.npcChatText = $"Here. Take your new Berimbau. I upgraded your {Lang.GetItemNameValue(ItemType<Items.Accessories.GrayCord>())} to a {Lang.GetItemNameValue(ItemType<Items.Accessories.OrangeCord>())}";
							Main.LocalPlayer.QuickSpawnItem(ItemType<Items.Accessories.OrangeCord>());
							Main.LocalPlayer.QuickSpawnItem(ItemType<Items.Weapons.MastersBerimbau>());
							Main.LocalPlayer.QuickSpawnItem(ItemType<OtherworldlyEssence>());
							Main.npcChatCornerItem = ItemType<Items.Accessories.OrangeCord>();
							return;
						}
						else // Does not have the quest requirements
						{
							Main.npcChatText = $"First, you need a new decent Berimbau. Give me your old [i:{ItemType<Items.Weapons.WoodenBerimbau>()}] and defeat the evil biome's beast";
							Main.npcChatCornerItem = ItemType<Items.Weapons.WoodenBerimbau>();
							return;
						}
					}
					else if (Main.LocalPlayer.HasItem(ItemType<Items.Accessories.OrangeCord>()))
					{
						if (Main.LocalPlayer.HasItem(ItemID.HornetStaff)) // Quest requirements
						{
							Main.LocalPlayer.inventory[
								Main.LocalPlayer.FindItem(ItemType<Items.Accessories.OrangeCord>())
							].TurnToAir();
							Main.PlaySound(SoundID.Item105);
							Main.npcChatText = $"I see... You have a {Lang.GetItemNameValue(ItemID.HornetStaff)}. I upgraded your {Lang.GetItemNameValue(ItemType<Items.Accessories.OrangeCord>())} to a {Lang.GetItemNameValue(ItemType<Items.Accessories.BlueCord>())}";
							Main.LocalPlayer.QuickSpawnItem(ItemType<Items.Accessories.BlueCord>());
							Main.LocalPlayer.QuickSpawnItem(ItemType<OtherworldlyEssence>());
							Main.npcChatCornerItem = ItemType<Items.Accessories.BlueCord>();
							return;
						}
						else // Does not have the quest requirements
						{
							Main.npcChatText = $"In the Capoeira world, we are all about non-violence and peace. I've heard stories about giant evil bees residing inside the deep underground jungle. Prove yourself capable of defeating one of them and show me your summoner strength";
							Main.npcChatCornerItem = ItemID.HornetStaff;
							return;
						}
					}
					else if (Main.LocalPlayer.HasItem(ItemType<Items.Accessories.BlueCord>()))
					{
						if (Main.LocalPlayer.HasItem(ItemID.ImpStaff) && NPC.downedBoss3) // Quest requirements
						{
							Main.LocalPlayer.inventory[
								Main.LocalPlayer.FindItem(ItemType<Items.Accessories.BlueCord>())
							].TurnToAir();
							Main.PlaySound(SoundID.Item105);
							Main.npcChatText = $"Congratulations on your new staff and achievement. I upgraded your {Lang.GetItemNameValue(ItemType<Items.Accessories.BlueCord>())} to a {Lang.GetItemNameValue(ItemType<Items.Accessories.GreenCord>())}";
							Main.LocalPlayer.QuickSpawnItem(ItemType<Items.Accessories.GreenCord>());
							Main.LocalPlayer.QuickSpawnItem(ItemType<Items.Weapons.Atabaque>());
							Main.LocalPlayer.QuickSpawnItem(ItemType<OtherworldlyEssence>(), 2);
							Main.npcChatCornerItem = ItemType<Items.Accessories.GreenCord>();
							return;
						}
						else // Does not have the quest requirements
						{
							Main.npcChatText = $"I'm impressed, you have progressed so quickly it's making me proud. Our journey is only starting, you have yet to liberate the Old Man's curse and conquer the underworld. Only when I see these achievements you'll be rewarded";
							Main.npcChatCornerItem = ItemID.ImpStaff;
							return;
						}
					}
					else if (Main.LocalPlayer.HasItem(ItemType<Items.Accessories.GreenCord>()))
					{
						if (Main.hardMode && Main.LocalPlayer.HasItem(ItemID.SpiderStaff)) // Quest requirements
						{
							Main.LocalPlayer.inventory[
								Main.LocalPlayer.FindItem(ItemType<Items.Accessories.GreenCord>())
							].TurnToAir();
							Main.PlaySound(SoundID.Item105);
							Main.npcChatText = $"Well done, you are on your way to become a respected summoner and Capoeirista. I upgraded your {Lang.GetItemNameValue(ItemType<Items.Accessories.GreenCord>())} to a {Lang.GetItemNameValue(ItemType<Items.Accessories.PurpleCord>())}";
							Main.LocalPlayer.QuickSpawnItem(ItemType<Items.Accessories.PurpleCord>());
							Main.LocalPlayer.QuickSpawnItem(ItemType<OtherworldlyEssence>(), 2);
							Main.npcChatCornerItem = ItemType<Items.Accessories.PurpleCord>();
							return;
						}
						else // Does not have the quest requirements
						{
							Main.npcChatText = $"Now it's time to get some respectable weaponry, penetrate the caverns in search of spiders, and show me what you can do with them";
							Main.npcChatCornerItem = ItemID.SpiderStaff;
							return;
						}
					}
					else if (Main.LocalPlayer.HasItem(ItemType<Items.Accessories.PurpleCord>()))
					{
						if (NPC.downedMechBossAny) // Quest requirements
						{
							Main.LocalPlayer.inventory[
								Main.LocalPlayer.FindItem(ItemType<Items.Accessories.PurpleCord>())
							].TurnToAir();
							Main.PlaySound(SoundID.Item105);
							Main.npcChatText = $"Wow! I wasn't even prepared for you to make that... Congratulations! I upgraded your {Lang.GetItemNameValue(ItemType<Items.Accessories.PurpleCord>())} to a {Lang.GetItemNameValue(ItemType<Items.Accessories.BrownCord>())}";
							Main.LocalPlayer.QuickSpawnItem(ItemType<Items.Accessories.BrownCord>());
							Main.LocalPlayer.QuickSpawnItem(ItemType<Items.Weapons.AtabaqueDaRoda>());
							Main.LocalPlayer.QuickSpawnItem(ItemType<OtherworldlyEssence>(), 5);
							Main.npcChatCornerItem = ItemType<Items.Accessories.BrownCord>();
							return;
						}
						else // Does not have the quest requirements
						{
							Main.npcChatText = $"There are many things in the world that we can all understand. But sometimes things are just too complicated. I've been recently hearing stories about mechanical evil forces... I'm not sure if you're capable of defeating them, but if you do, be certain that the rewards will be great";
							Main.npcChatCornerItem = ItemType<Items.Weapons.Atabaque>();
							return;
						}
					}
					else if (Main.LocalPlayer.HasItem(ItemType<Items.Accessories.BrownCord>()))
					{
						if (NPC.downedPlantBoss) // Quest requirements
						{
							Main.LocalPlayer.inventory[
								Main.LocalPlayer.FindItem(ItemType<Items.Accessories.BrownCord>())
							].TurnToAir();
							Main.PlaySound(SoundID.Item105);
							Main.npcChatText = $"Congratulations, your jounrey is complete. The jungle abomination was defeated and you have proved your capabilities as a Capoeira Master. I upgraded your {Lang.GetItemNameValue(ItemType<Items.Accessories.BrownCord>())} to a {Lang.GetItemNameValue(ItemType<Items.Accessories.RedCord>())}";
							Main.LocalPlayer.QuickSpawnItem(ItemType<Items.Accessories.RedCord>());
							Main.LocalPlayer.QuickSpawnItem(ItemType<OtherworldlyEssence>(), 5);
							Main.npcChatCornerItem = ItemType<Items.Accessories.RedCord>();
							return;
						}
						else // Does not have the quest requirements
						{
							Main.npcChatText = $"It's time for the greatest challenge of all, the challenge that will shape your character as a Capoeirista and Summoner forever. You just have to enter the jungle one more time to slain the greatest evil you have ever fought... I don't have words to describe it, you have to see it yourself";
							Main.npcChatCornerItem = ItemID.JungleSpores;
							return;
						}
					}
					else if (Main.LocalPlayer.HasItem(ItemType<Items.Accessories.RedCord>()))
					{
						Main.npcChatText = "You have already proven yourself capable of all Capoeira skills. Wait! Don't put that cord back yet, I can sell you a powerful thing if you want to";
						Main.npcChatCornerItem = ItemType<Items.Accessories.RedCord>();
						return;
					}
					else // Doesnt even have a cord in the inventory
					{
						switch (Main.rand.Next(3))
						{
							case 0:
								Main.npcChatText = "My king, pardon my vision but I can't see any cord in your bag, are you sure you're not wearing it or have even got one?";
								break;
							case 1:
								Main.npcChatText = "We are all about non-violence in Capoeira my king, I cannot forcibly remove your cord from your waist if you've got any";
								break;
							default:
								Main.npcChatText = "I need the cord in your bag in order to take it!";
								break;
						}
						Main.npcChatCornerItem = ItemType<Items.Accessories.GrayCord>();
						return;
					}
				}
				else
                {
					Main.npcChatText = "You're not strong enough to Begin your Capoeira lessons, show your strength first against great evil forces and come back later.";
					return;
				}
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(ItemID.BlinkrootSeeds);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.DaybloomSeeds);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.WaterleafSeeds);
			nextSlot++;
			if (NPC.downedPlantBoss)
			{
				shop.item[nextSlot].SetDefaults(ItemID.MoonglowSeeds);
				nextSlot++;
			}
			if (NPC.downedFrost)
			{
				shop.item[nextSlot].SetDefaults(ItemID.ShiverthornSeeds);
				nextSlot++;
			}
			if (NPC.downedBoss2)
			{
				shop.item[nextSlot].SetDefaults(ItemID.DeathweedSeeds);
				nextSlot++;
			}
			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(ItemID.Fireblossom);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemType<Pandeiro>());
				nextSlot++;
			}
			if (!Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(ItemID.SpecularFish);
				nextSlot++;
			}
			shop.item[nextSlot].SetDefaults(ItemType<Items.Consumable.Offering>());
			nextSlot++;
			if (NPC.downedBoss1)
			{
				shop.item[nextSlot].SetDefaults(ItemType<Items.Accessories.GrayCord>());
				nextSlot++;
			}
			if (NPC.downedAncientCultist || Main.LocalPlayer.HasItem(ItemType<Items.Accessories.RedCord>()))
            {
				shop.item[nextSlot].SetDefaults(ItemType<OtherworldlyEssence>());
				nextSlot++;
			}
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), ItemType<OtherworldlyEssence>());
		}

		public override bool CanGoToStatue(bool toKingStatue)
		{
			return true;
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 10;
			knockback = 3f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileType<BahiaNote>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 2f;
			randomOffset = .5f;
		}
	}
}