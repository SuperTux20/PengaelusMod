using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PengaelusMod.Items.Materials {
	class PrimaHeart : ModItem {
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.value = 5000000;
		}
		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 500;
		}
		public override bool? UseItem(Player player) {
			// ModPlayer.ModifyMaxStats(out StatModifier health, out StatModifier mana);
			player.statLife += 500;
			if (Main.myPlayer == player.whoAmI) player.HealEffect(500, true);
			return true;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<PrimaBar>(), 5);
			recipe.AddIngredient(ItemID.LifeFruit, 5);
			recipe.AddIngredient(ItemID.LifeCrystal, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
