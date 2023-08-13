using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using PengaelusMod.Projectiles;

namespace PengaelusMod.Items.Weapons.Melee {
	public class TruePengathidurius : ModItem {
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("True Pengathidurius");
			// Tooltip.SetDefault("Rains down swords, Right Click for different swords");
		}

		public override void SetDefaults() {
			Item.damage = 270;
			Item.DamageType = DamageClass.Melee;
			Item.width = 64;
			Item.height = 64;
			Item.useTime = 14;
			Item.crit = 55;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 7f;
			Item.value = Terraria.Item.sellPrice(0, 8, 25, 50);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override bool AltFunctionUse(Player player) => true;
		public override Vector2? HoldoutOffset() => new Vector2(-10, 0);
		public override bool CanUseItem(Player player) {
			if (player.altFunctionUse == 2) {
				Item.useStyle = ItemUseStyleID.Swing;
				Item.UseSound = SoundID.Item1;
				Item.shootSpeed = 10f;
				Item.shoot = ProjectileID.MagicMissile;
			} else {
				Item.damage = 400;
				Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
				Item.staff[Item.type] = true;
				Item.channel = true; // Channel so that you can hold the weapon [Important]
				Item.useTime = 44;
				Item.UseSound = SoundID.Item13;
				Item.useStyle = ItemUseStyleID.Swing;
				Item.shootSpeed = 14f;
				Item.useAnimation = 20;
				Item.crit = 30;
				Item.shoot = ModContent.ProjectileType<Pengathitile>();
			}
			return base.CanUseItem(player);
		}

		/* some leftover code from the 1.3 version that doesn't work because speedX and speedY are undefined, and yet the weapon seems to work perfectly fine without it, but i'm leaving it in anyways for historical purposes
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			if (Main.myPlayer == player.whoAmI) {
				Vector2 origVect = new Vector2(speedX, speedY);
				for (int i = 0; i < 6; ++i) {
					Vector2 newVect = origVect.RotatedBy((((float)Math.PI * 2) / 6) * i);
					Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, damage, knockBack, player.whoAmI);
				}
			}
			return false;
		}
		*/
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Pengathidurius>(), 1);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
			recipe.AddIngredient(ItemID.LargeEmerald, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}