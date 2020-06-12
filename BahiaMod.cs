using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using Terraria.ID;
using System.Reflection;
using System;

namespace BahiaMod
{
	public class BahiaMod : Mod
	{
		private static MethodInfo _startRainMethod = typeof(Main).GetMethod("StartRain", BindingFlags.NonPublic | BindingFlags.Static);
		private static MethodInfo _stopRainMethod = typeof(Main).GetMethod("StopRain", BindingFlags.NonPublic | BindingFlags.Static);
		private static MethodInfo _startSandstormMethod = typeof(Sandstorm).GetMethod("StartSandstorm", BindingFlags.NonPublic | BindingFlags.Static);
		private static MethodInfo _stopSandstormMethod = typeof(Sandstorm).GetMethod("StopSandstorm", BindingFlags.NonPublic | BindingFlags.Static);

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BlinkrootSeeds);
			recipe.AddIngredient(null, "OtherworldlyEssence");
			recipe.AddIngredient(null, "Offering");
			recipe.AddTile(null, "EshuCarpet");
			recipe.SetResult(ItemID.Blinkroot, 2);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.DaybloomSeeds);
			recipe.AddIngredient(null, "OtherworldlyEssence");
			recipe.AddIngredient(null, "Offering");
			recipe.AddTile(null, "EshuCarpet");
			recipe.SetResult(ItemID.Daybloom, 2);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.DeathweedSeeds);
			recipe.AddIngredient(null, "OtherworldlyEssence");
			recipe.AddIngredient(null, "Offering");
			recipe.AddTile(null, "EshuCarpet");
			recipe.SetResult(ItemID.Deathweed, 2);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.FireblossomSeeds);
			recipe.AddIngredient(null, "OtherworldlyEssence");
			recipe.AddIngredient(null, "Offering");
			recipe.AddTile(null, "EshuCarpet");
			recipe.SetResult(ItemID.Fireblossom, 2);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.MoonglowSeeds);
			recipe.AddIngredient(null, "OtherworldlyEssence");
			recipe.AddIngredient(null, "Offering");
			recipe.AddTile(null, "EshuCarpet");
			recipe.SetResult(ItemID.Moonglow, 2);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.ShiverthornSeeds);
			recipe.AddIngredient(null, "OtherworldlyEssence");
			recipe.AddIngredient(null, "Offering");
			recipe.AddTile(null, "EshuCarpet");
			recipe.SetResult(ItemID.Shiverthorn, 2);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.WaterleafSeeds);
			recipe.AddIngredient(null, "OtherworldlyEssence");
			recipe.AddIngredient(null, "Offering");
			recipe.AddTile(null, "EshuCarpet");
			recipe.SetResult(ItemID.Waterleaf, 2);
			recipe.AddRecipe();
		}
		public static void StartRain()
		{
			_startRainMethod.Invoke(null, null);
		}
		public static void StopRain()
		{
			_stopRainMethod.Invoke(null, null);
		}
		public static void StartSandstorm()
		{
			_startSandstormMethod.Invoke(null, null);
		}
		public static void StopSandstorm()
		{
			_stopSandstormMethod.Invoke(null, null);
		}
	}
}