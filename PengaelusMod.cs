using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace PengaelusMod
{
	public class PengaelusMod : Mod
	{
		// Your mod instance has a Logger field, use it.
		// OPTIONAL: You can create your own logger this way, recommended is a custom logging class if you do a lot of logging
		// You need to reference the log4net library to do this, this can be found in the tModLoader repository
		// inside the references folder. You do not have to add this to build.txt as tML has it natively.
		// internal ILog Logging = LogManager.GetLogger("PengaelusMod");

		public PengaelusMod()
		{
			// By default, all Autoload properties are True. You only need to change this if you know what you are doing.
			//Properties = new ModProperties()
			//{
			//	Autoload = true,
			//	AutoloadGores = true,
			//	AutoloadSounds = true,
			//	AutoloadBackgrounds = true
			//};
		}

		public override void Load()
		{
			// Will show up in client.log under the PengaelusMod name
			Logger.InfoFormat("{0} example logging", Name);
			// In older tModLoader versions we used: ErrorLogger.Log("blabla");
			// Replace that with above

			// Register custom mod translations, lives left is for Spirit of Purity
			// See the .lang files in the Localization folder for an easier to manage approach to translations. These few examples are here just to illustrate the concept.
			ModTranslation text = CreateTranslation("LivesLeft");
			text.SetDefault("{0} has {1} lives left!");
			AddTranslation(text);
			text = CreateTranslation("LifeLeft");
			text.SetDefault("{0} has 1 life left!");
			AddTranslation(text);
			text = CreateTranslation("NPCTalk");
			text.SetDefault("<{0}> {1}");
			AddTranslation(text);
			text = CreateTranslation("Common.LocalizedLabelDynamic");
			text.SetDefault($"[i:{ModContent.ItemType<Items.Weapons.SpectreGun>()}]  This dynamic label is added in PengaelusMod.Load");
			AddTranslation(text);

			text = CreateTranslation("BossSpawnInfo.Abomination");
			text.SetDefault("Use a [i:" + ModContent.ItemType<Items.Abomination.FoulOrb>() + "] in the underworld after Plantera has been defeated");
			AddTranslation(text);

			// Volcano warning is for the random volcano tremor
			text = CreateTranslation("VolcanoWarning");
			text.SetDefault("Did you hear something....A Volcano! Find Cover!");
			AddTranslation(text);
		}

		public override void Unload()
		{
		}
	}
}

