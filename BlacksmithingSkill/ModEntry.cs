using System;
using Microsoft.Xna.Framework;
using SpaceCore;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using Leclair.Stardew.BetterCrafting;
using StardewValley;
using HarmonyLib;
using Leclair.Stardew.BetterCrafting.Patches;
using StardewValley.Projectiles;
using static StardewValley.Projectiles.BasicProjectile;
using StardewValley.Tools;

namespace BlacksmithingSkillCode
{
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry : Mod
    {
        internal static ModEntry Instance;
        public BlacksmithingSkill blacksmithingSkill;
        public static IBetterCrafting BetterCrafting;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            //helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            I18n.Init(helper.Translation);
            Instance = this;
            blacksmithingSkill = new BlacksmithingSkill();
            Skills.RegisterSkill(blacksmithingSkill);
            helper.Events.GameLoop.GameLaunched += Events.OnGameLaunched;

            Harmony harmony = new Harmony(ModManifest.UniqueID);

            harmony.Patch(
                original: AccessTools.Method(typeof(MeleeWeapon), nameof(MeleeWeapon.salePrice)),
                postfix: new HarmonyMethod(typeof(Patches), nameof(Patches.SalePrice_Postfix))
            );

            harmony.Patch(
                original: AccessTools.Method(typeof(StardewValley.Objects.Furniture), "loadDescription"),
                postfix: new HarmonyMethod(typeof(Patches), nameof(Patches.LoadDescription_Postfix))
            );

            harmony.Patch(
                original: AccessTools.Method(typeof(StardewValley.Internal.ShopBuilder), "GetToolUpgradeConventionalTradeItem"),
                postfix: new HarmonyMethod(typeof(Patches), nameof(Patches.GetToolUpgradeConventionalTradeItem_Postfix))
            );

            harmony.Patch(
                original: AccessTools.Constructor(typeof(CraftingRecipe), new Type[] { typeof(string), typeof(bool) }),
                postfix: new HarmonyMethod(typeof(Patches), nameof(Patches.CraftingRecipeConstructor_Postfix))
            );

            /*harmony.Patch(
                original:AccessTools.Constructor(typeof(BasicProjectile), new Type[] {typeof(int), typeof(int), typeof(int), typeof(int), typeof(float), typeof(float), typeof(float), typeof(Vector2), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(GameLocation), typeof(Character), typeof(BasicProjectile.onCollisionBehavior), typeof(string)}),
                postfix: new HarmonyMethod(typeof(Patches), nameof(Patches.BasicProjectileConstructor_Postfix))
            );*/

            harmony.Patch(
                original: AccessTools.Method(typeof(MeleeWeapon), nameof(MeleeWeapon.FireProjectile)),
                postfix: new HarmonyMethod(typeof(Patches), nameof(Patches.FireProjectile_Postfix))
            );
        }
    }
}