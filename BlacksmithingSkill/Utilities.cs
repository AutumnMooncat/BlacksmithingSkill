using SpaceCore;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithingSkillCode
{
    internal class Utilities
    {
        public const string CraftedKey = "MistressAutumn.BlacksmithingSkill.Crafted";
        public const string StylishKey = "MistressAutumn.BlacksmithingSkill.StylishFinish";
        public const string PracticalKey = "MistressAutumn.BlacksmithingSkill.PracticalFinish";
        public const string ExpertKey = "MistressAutumn.BlacksmithingSkill.ExpertSmith";
        public const string ResourcefulKey = "MistressAutumn.BlacksmithingSkill.ResourcefulSmith";
        public const string GripsKey = "MistressAutumn.BlacksmithingSkill.LuxuryGrips";
        public const string PaddingKey = "MistressAutumn.BlacksmithingSkill.LuxuryPadding";
        public static int GetSmithingLevel(Farmer who)
        {
            Farmer player = Game1.getFarmer(who.UniqueMultiplayerID);
            return Skills.GetSkillLevel(player, BlacksmithingSkill.BlacksmithingSkillID) + Skills.GetSkillBuffLevel(player, BlacksmithingSkill.BlacksmithingSkillID);
        }

        public static void AddSmithingXP(Farmer who, int amount)
        {
            Skills.AddExperience(Game1.getFarmer(who.UniqueMultiplayerID), BlacksmithingSkill.BlacksmithingSkillID, amount);
        }

        public static bool HasStylishFinish(Farmer who)
        {
            return who.HasCustomProfession(BlacksmithingSkill.Profession5a);
        }

        public static bool HasPracticalFinish(Farmer who)
        {
            return who.HasCustomProfession(BlacksmithingSkill.Profession5b);
        }

        public static bool HasExpertSmith(Farmer who)
        {
            return who.HasCustomProfession(BlacksmithingSkill.Profession10a1);
        }

        public static bool HasResourcefulSmith(Farmer who)
        {
            return who.HasCustomProfession(BlacksmithingSkill.Profession10a2);
        }

        public static bool HasLuxuryGrips(Farmer who)
        {
            return who.HasCustomProfession(BlacksmithingSkill.Profession10b1);
        }

        public static bool HasLuxuryPadding(Farmer who)
        {
            return who.HasCustomProfession(BlacksmithingSkill.Profession10b2);
        }
    }
}
