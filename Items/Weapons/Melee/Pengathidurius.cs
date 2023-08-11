using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace PengaelusMod.Items.Weapons.Melee {
	public class Pengathidurius : ModItem {
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Pengathidurius");
			// Tooltip.SetDefault("");
		}

		public override void SetDefaults() {
			Item.damage = 200;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
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

		public override bool CanUseItem(Player player) {
			Item.useStyle = ItemUseStyleID.Swing;
			Item.UseSound = SoundID.Item1;
			Item.shootSpeed = 10f;
			return base.CanUseItem(player);
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TerraBlade, 1);
			recipe.AddIngredient(ItemID.MythrilBar, 10);
			recipe.AddIngredient(ItemID.Emerald, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}