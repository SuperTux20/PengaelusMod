using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace PengaelusMod.Items.Weapons.Melee {
	public class Pengathidurius : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pengathidurius");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults() {
			item.damage = 200;
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

		public override bool CanUseItem(Player player) {
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.UseSound = SoundID.Item1;
			item.shootSpeed = 10f;
			return base.CanUseItem(player);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TerraBlade, 1);
			recipe.AddIngredient(ItemID.MythrilBar, 10);
			recipe.AddIngredient(ItemID.Emerald, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}