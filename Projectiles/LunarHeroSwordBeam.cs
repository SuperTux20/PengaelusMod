using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PengaelusMod.Projectiles {
	public class LunarHeroSwordBeam : ModProjectile {
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 12;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 300;
			Projectile.height = 16;
			Projectile.width = 16;
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			Projectile.light = 0.5f;
			AIType = ProjectileID.DeathLaser;
			Projectile.extraUpdates = 1;
			DrawOffsetX = -38;
		}
		int timer = 1;
		public override bool PreAI() {
			Projectile.ai[1] += 1f;
			bool chasing = false;
			if (Projectile.ai[1] >= 30f) {
				chasing = true;
				Projectile.friendly = true;
				NPC target = null;
				if (Projectile.ai[0] == -1f) target = ProjectileExtras.FindRandomNPC(Projectile.Center, 960f, false);
				else {
					target = Main.npc[(int)Projectile.ai[0]];
					if (!target.active || !target.CanBeChasedBy()) target = ProjectileExtras.FindRandomNPC(Projectile.Center, 960f, false);
				}
				if (target == null) {
					chasing = false;
					Projectile.ai[0] = -1f;
				} else {
					Projectile.ai[0] = (float)target.whoAmI;
					ProjectileExtras.HomingAI(this, target, 10f, 5f);
				}
			}

			ProjectileExtras.LookAlongVelocity(this);
			if (!chasing) {
				Vector2 dir = Projectile.velocity * 78;
				float vel = Projectile.velocity.Length();
				if (vel != 0f) {
					if (vel < 4f) {
						dir *= 1 / vel;
						Projectile.velocity += dir;
					}
				} else {
					Projectile.velocity.X += Main.rand.Next(2) == 0 ? 0.1f : -0.1f;
				}
			}
			int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 75, Projectile.velocity.X, Projectile.velocity.Y);
			Main.dust[dust].scale = 1f;
			Main.dust[dust].noGravity = true;
			return false;
		}

		public override void Kill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			ProjectileExtras.Explode(Projectile.whoAmI, 120, 120,
				delegate {
					for (int num621 = 0; num621 < 40; num621++) {
						int num622 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 75, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num622].velocity *= 3f;
						if (Main.rand.Next(2) == 0) {
							Main.dust[num622].scale = 0.5f;
							Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
						}
					}
					for (int num623 = 0; num623 < 70; num623++) {
						int num624 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 75, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num624].noGravity = true;
						Main.dust[num624].velocity *= 1.5f;
						num624 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 75, 0f, 0f, 100, default(Color), 1f);
						Main.dust[num624].velocity *= 2f;
					}
				}
			);
		}

		private void AdjustMagnitude(ref Vector2 vector) {
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f) vector *= 6f / magnitude;
		}
	}
}