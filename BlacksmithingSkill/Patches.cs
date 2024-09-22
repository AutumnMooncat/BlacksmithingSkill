using StardewValley.Tools;
using StardewValley.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewValley;
using StardewValley.Projectiles;
using StardewValley.Internal;
using Microsoft.Xna.Framework;

namespace BlacksmithingSkillCode
{
    internal class Patches
    {
        public static void SalePrice_Postfix(MeleeWeapon __instance, ref int __result)
        {
            if (__instance.modData.ContainsKey(Utilities.ExpertKey))
            {
                __result = (int)(__result * 1.5);
            }
            else if (__instance.modData.ContainsKey(Utilities.StylishKey))
            {
                __result = (int)(__result * 1.25);
            }
        }

        public static void LoadDescription_Postfix(Furniture __instance, ref string __result)
        {
            if (__instance.QualifiedItemId.Equals("(F)MistressAutumn.BlacksmithingSkill_SmithingAnvil"))
            {
                __result = I18n.BlacksmithingSkillAnvil_Desc();
            }
        }

        public static void GetToolUpgradeConventionalTradeItem_Postfix(int level, ref string __result)
        {
            switch (level)
            {
                case 1:
                    __result = "(O)MistressAutumn.BlacksmithingSkill_BronzeBar";
                    break;
                case 2:
                    __result = "(O)MistressAutumn.BlacksmithingSkill_SteelBar";
                    break;
                case 3:
                    __result = "(O)MistressAutumn.BlacksmithingSkill_StainlessSteelBar";
                    break;
                case 4:
                    __result = "(O)MistressAutumn.BlacksmithingSkill_TungstensteelBar";
                    break;

            }
        }

        public static void CraftingRecipeConstructor_Postfix(CraftingRecipe __instance)
        {
            if (__instance.name.Equals("MistressAutumn.BlacksmithingSkill_SmithingAnvil"))
            {
                __instance.description = I18n.BlacksmithingSkillAnvil_Desc();
            }
        }

        public static void FireProjectile_Postfix(MeleeWeapon __instance, Farmer who)
        {
            if (__instance.Name.Equals("MistressAutumn.BlacksmithingSkill_BombRod"))
            {
                float shotAngle = 0f;
                switch (who.facingDirection.Value)
                {
                    case 0:
                        shotAngle = 90f;
                        break;
                    case 1:
                        shotAngle = 0f;
                        break;
                    case 2:
                        shotAngle = 270f;
                        break;
                    case 3:
                        shotAngle = 180f;
                        break;
                }
                shotAngle *= 0.017453292f;
                Vector2 shotOrigin = who.getStandingPosition() - new Vector2(32f, 32f);
                int damage = 20;
                int spriteIndex = 10;
                int bounces = 0;
                int tailLength = 1;
                float rotationVelocity = 32 * 0.017453292f;
                float xVelocity = 10 * (float)Math.Cos((double)shotAngle);
                float yVelocity = 10 * (float)-(float)Math.Sin((double)shotAngle);
                Vector2 startingPosition = shotOrigin;
                BasicProjectile projectile = new BasicProjectile(damage, spriteIndex, bounces, tailLength, rotationVelocity, xVelocity, yVelocity, startingPosition, "explosion", null, "fireball", false, true, who.currentLocation, who, new BasicProjectile.onCollisionBehavior(BasicProjectile.explodeOnImpact), null);
                projectile.ignoreTravelGracePeriod.Value = true;
                projectile.ignoreMeleeAttacks.Value = true;
                projectile.maxTravelDistance.Value = -1 * 64;
                projectile.height.Value = 32f;
                who.currentLocation.projectiles.Add(projectile);
            }
        }
    }
}
