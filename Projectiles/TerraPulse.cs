using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PengaelusMod.Projectiles {
	public class TerraPulse : ModProjectile {
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			Projectile.damage = 270;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.width = 64;
			Projectile.height = 64;
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = 100;
			Projectile.knockBack = 7f;
			Projectile.timeLeft = 600;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
		}
		public override void AI() {
			int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.TerraBlade, 0f, 0f, 0, default, 1f);
			Main.dust[dust].velocity *= 0.25f;
			Main.dust[dust].scale = (float)(Main.rand.Next(50,200) * 0.01);
		}
	}
}