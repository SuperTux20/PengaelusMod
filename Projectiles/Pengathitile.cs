using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PengaelusMod.Projectiles {
	public class Pengathitile : ModProjectile {
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
			Projectile.light = 0.25f;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
		}
		public override void AI() {
			int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.TerraBlade, 0f, 0f, 0, default, 1f);
			Main.dust[dust].velocity *= 0.3f;
			Main.dust[dust].scale = (float)(Main.rand.Next(100,150) * 0.013);

			int dust2 = Dust.NewDust(Projectile.Center, 1, 1, DustID.Adamantite, 0f, 0f, 0, default, 1f);
			Main.dust[dust2].velocity *= 0.3f;
			Main.dust[dust2].scale = (float)(Main.rand.Next(100,150) * 0.0013);
		}
	}
}