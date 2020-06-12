using Terraria.ID;
using Terraria.ModLoader;
namespace BahiaMod.Projectiles
{
    class BahiaNote : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Berimbau Notes");
		}

		public override void SetDefaults()
		{
			projectile.minion = true;
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 21;
			projectile.friendly = true;
			projectile.timeLeft = 120;
			projectile.alpha = 100;
			aiType = ProjectileID.TiedEighthNote;
		}
	}
}
