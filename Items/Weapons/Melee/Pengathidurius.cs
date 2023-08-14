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
			Item.value = Item.sellPrice(0, 40, 0, 0);
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
			recipe.AddIngredient(ItemID.ChlorophyteClaymore);
			recipe.AddIngredient(ItemID.ChlorophyteSaber);
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddIngredient(ModContent.ItemType<PrimaSword>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}