using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace PengaelusMod.Items.Materials {
	public class PrimaOre : ModItem {
		public override void SetStaticDefaults() {
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 18));
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults() {
			Item.width = 14;
			Item.height = 12;
			Item.value = 120000;
			Item.rare = ItemRarityID.Purple;
			Item.maxStack = 9999;
		}
	}
}
