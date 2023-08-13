using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PengaelusMod.Projectiles {
	public class HeroSwordBeam : ModProjectile {
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
			Projectile.width = 76;
			Projectile.tileCollide = false;
			Projectile.height = 76;
			Projectile.timeLeft = 100;
			Projectile.penetrate = 10;
			Projectile.friendly = true;
			Projectile.damage = 90;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 20;
		}
		int colortimer;
		public override void AI() {
			timer++;
			if (timer <= 50) colortimer++;
			if (timer > 50) colortimer--;
			if (timer >= 100) timer = 0;
			Projectile.rotation += 0.4f;
			bool chasing = true;
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
		public override bool PreDraw(ref Color lightColor) {
			Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
			for (int k = 0; k < Projectile.oldPos.Length; k++) {
				Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
				Main.EntitySpriteDraw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
			}
			return false;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) => true;
		public override Color? GetAlpha(Color lightColor) => new Color(60 + colortimer, 60 + colortimer, 60 + colortimer, 100);
	}
}