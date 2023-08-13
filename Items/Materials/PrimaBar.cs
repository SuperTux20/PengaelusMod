using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PengaelusMod.Items.Materials {
	public class PrimaBar : ModItem {
		public override void SetStaticDefaults() {
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 27));
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 24;
			Item.value = 120000;
			Item.rare = ItemRarityID.Purple;
			Item.maxStack = 9999;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<PrimaOre>(), 5);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.Register();
		}
	}
}