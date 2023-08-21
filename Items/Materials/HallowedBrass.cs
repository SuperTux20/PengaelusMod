using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace PengaelusMod.Items.Materials {
	public class HallowedBrass: ModItem {
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 24;
			Item.value = Item.sellPrice(0, 0, 50, 0);
			Item.rare = ItemRarityID.Pink;
			Item.maxStack = 9999;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CopperBar, 2);
			recipe.AddIngredient(ItemID.IronBar, 1);
			recipe.AddIngredient(ItemID.HallowedBar, 1);
			recipe.AddIngredient(ItemID.Obsidian, 1);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.Register();
		}
	}
}
