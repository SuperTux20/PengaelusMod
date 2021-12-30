using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PengaelusMod.Items.Weapons.Melee {
	public class TruePengathidurius : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("True Pengathidurius");
			Tooltip.SetDefault("Rains down swords, Right Click for different swords");
		}

		public override void SetDefaults() {
			item.damage = 270;
			item.melee = true;
			item.width = 64;
			item.height = 64;
			item.useTime = 14;
			item.crit = 55;
			item.useAnimation = 14;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 7f;
			item.value = Terraria.Item.sellPrice(0, 8, 25, 50);
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override bool AltFunctionUse(Player player) => true;
		public override Vector2? HoldoutOffset() => new Vector2(-10, 0);
		public override bool CanUseItem(Player player) {
			if (player.altFunctionUse == 2) {
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.UseSound = SoundID.Item1;
				item.shootSpeed = 10f;
				item.shoot = ProjectileID.MagicMissile;
			} else {
				item.damage = 400;
				item.melee = true;
				Item.staff[item.type] = true;
				item.channel = true; // Channel so that you can hold the weapon [Important]
				item.useTime = 44;
				item.UseSound = SoundID.Item13;
				item.useStyle = ItemUseStyleID.HoldingOut;
				item.shootSpeed = 14f;
				item.useAnimation = 20;
				item.crit = 30;
				item.shoot = ProjectileID.DemonScythe;
			}
			return base.CanUseItem(player);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			if (Main.myPlayer == player.whoAmI) {
				Vector2 origVect = new Vector2(speedX, speedY);
				for (int i = 0; i < 6; ++i) {
					Vector2 newVect = origVect.RotatedBy((((float)Math.PI * 2) / 6) * i);
					Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, damage, knockBack, player.whoAmI);
				}
			}
			return false;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Pengathidurius>(), 1);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
			recipe.AddIngredient(ItemID.LargeEmerald, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}