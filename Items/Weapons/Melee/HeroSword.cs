using PengaelusMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace PengaelusMod.Items.Weapons.Melee {
	public class HeroSword : ModItem {
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			Item.damage = 170;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 60;
			Item.height = 60;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 15;
			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.rare = 10;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<HeroSwordBeam>();
			Item.shootSpeed = 8f;
			Item.autoReuse = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.NightsEdge);
			recipe.AddIngredient(ItemID.Excalibur);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}