using Microsoft.Xna.Framework;
using PengaelusMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PengaelusMod.Items.Weapons.Melee {
	public class AncientHeroSword : ModItem {
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			Item.damage = 70;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 60;
			Item.height = 60;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 7f;
			Item.value = Item.sellPrice(0, 3, 0, 0);
			Item.rare = ItemRarityID.Blue;
			Item.shootSpeed = 7f;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<AncientProj>();
			Item.autoReuse = true;
		}
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			if (Main.rand.Next(4) == 0) {
				target.AddBuff(BuffID.ShadowFlame, 500, true);
				if (Main.rand.Next(3) == 0) {
					for (int k = 0; k < 20; k++) {
						Dust.NewDust(target.position, target.width, target.height, 225, 2.5f, -2.5f, 0, Color.White, 0.7f);
						Dust.NewDust(target.position, target.width, target.height, 225, 2.5f, -2.5f, 0, default(Color), .34f);
					}
				}
			}
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BrokenHeroSword, 2);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}