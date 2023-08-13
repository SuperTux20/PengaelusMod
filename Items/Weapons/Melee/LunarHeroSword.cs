using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using PengaelusMod.Items.Materials;
using PengaelusMod.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace PengaelusMod.Items.Weapons.Melee {
	public class LunarHeroSword : ModItem {
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Lunar Hero Sword");
			// Tooltip.SetDefault("The Moon has blessed this lost sword with it's power, don't abuse it");
		}

		public override void SetDefaults() {
			Item.damage = 300;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 68;
			Item.height = 68;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 15;
			Item.value = Terraria.Item.sellPrice(1, 10, 0, 0);
			Item.rare = 12;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<LunarHeroSwordBeam>();
			Item.shootSpeed = 8f;
			Item.autoReuse = true;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			//conversion to polar from cartesian for velocity
			double x = player.Center.X - Main.MouseWorld.X;
			double y = -player.Center.Y + Main.MouseWorld.Y;
			double r = Math.Sqrt((x * x) + (y * y));
			double q = Math.Atan2(x, y);
			//x = r; r not needed since we always want r=1 so each has the same speed
			y = q;
			float XVel = (float)(8 * Math.Cos(q + 1.57f));
			float YVel = (float)(8 * Math.Sin(q + 1.57f));

			//position randomizer weighted towards central values
			float posX = player.Center.X;
			float posY = player.Center.Y;

			posX += (Main.rand.Next(-50, 50) + Main.rand.Next(-80, 80));
			posY += (Main.rand.Next(-50, 50) + Main.rand.Next(-80, 80));

			int p = Projectile.NewProjectile(null, posX, posY, XVel, YVel, type, damage, knockback, Item.playerIndexTheItemIsReservedFor, 0f, 0f);
			return true;
		}
		// public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) {
		// 	Lighting.AddLight(Item.position, 0.08f, .12f, .52f);
		// 	Texture2D texture;
		// 	texture = TextureAssets.Item[Item.type].Value;
		// 	spriteBatch.Draw(
		// 		Mod.GetTexture("Items/Weapon/Melee/LunarHeroSwordGlow"),
		// 		new Vector2(
		// 			Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
		// 			Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
		// 		),
		// 		new Rectangle(0, 0, texture.Width, texture.Height),
		// 		Color.White,
		// 		rotation,
		// 		texture.Size() * 0.5f,
		// 		scale,
		// 		SpriteEffects.None,
		// 		0f
		// 	);
		// }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentNebula, 15);
			recipe.AddIngredient(ItemID.FragmentStardust, 15);
			recipe.AddIngredient(ItemID.FragmentVortex, 15);
			recipe.AddIngredient(ItemID.FragmentSolar, 15);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(ModContent.ItemType<HeroSword>());
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}