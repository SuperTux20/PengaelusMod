using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using PengaelusMod.Items.Materials;
namespace PengaelusMod.Items.Weapons.Melee {
	public class Pengathidurius : ModItem {
		public override void SetStaticDefaults() {
		}

		public override void SetDefaults() {
			Item.damage = 100;
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

		public override bool CanUseItem(Player player) {
			Item.useStyle = ItemUseStyleID.Swing;
			Item.UseSound = SoundID.Item1;
			Item.shootSpeed = 10f;
			return base.CanUseItem(player);
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(ModContent.ItemType<PrimaBar>(), 10);
			recipe.AddIngredient(ItemID.Emerald, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}