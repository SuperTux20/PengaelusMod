using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace PengaelusMod.Projectiles {
	public class AncientProj : ModProjectile {
		int timer = 0;
		bool launch = false;
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults() {
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.light = 0.5f;
			Projectile.width = 36;
			Projectile.tileCollide = true;
			Projectile.height = 36;
			Projectile.timeLeft = 150;
			Projectile.penetrate = 10;
			Projectile.friendly = true;
			Projectile.damage = 90;
			Projectile.alpha = 10;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 20;
		}
		public override void AI() {
			ProjectileExtras.LookAlongVelocity(this);
			int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.TerraBlade, 0f, 0f, 0, default, 1f);
			Main.dust[dust].velocity *= 0.25f;
			Main.dust[dust].scale = (float)(Main.rand.Next(50,100) * 0.01);
		}
	}
}