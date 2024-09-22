using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SpaceCore;

namespace BlacksmithingSkillCode
{
    internal class BlacksmithingSkill : Skills.Skill
    {
        public const string BlacksmithingSkillID = "MistressAutumn.Blacksmithing";
        public static BlacksmithingProfession Profession5a;
        public static BlacksmithingProfession Profession5b;
        public static BlacksmithingProfession Profession10a1;
        public static BlacksmithingProfession Profession10a2;
        public static BlacksmithingProfession Profession10b1;
        public static BlacksmithingProfession Profession10b2;

        public BlacksmithingSkill() : base(BlacksmithingSkillID)
        {
            Icon = ModEntry.Instance.Helper.ModContent.Load<Texture2D>("assets/SmithingIconA.png");
            SkillsPageIcon = ModEntry.Instance.Helper.ModContent.Load<Texture2D>("assets/SmithingIconB.png");
            ExperienceBarColor = new Color(89, 89, 89);
            ExperienceCurve = new int[]
            {
                100,
                380,
                770,
                1300,
                2150,
                3300,
                4000,
                6900,
                10000,
                15000
            };
            Profession5a = new BlacksmithingProfession(this, "Smithing5a", () => I18n.Smithing5a_Name(), () => I18n.Smithing5a_Desc(), "assets/Smithing5a.png");
            Profession5b = new BlacksmithingProfession(this, "Smithing5b", () => I18n.Smithing5b_Name(), () => I18n.Smithing5b_Desc(), "assets/Smithing5b.png");
            Profession10a1 = new BlacksmithingProfession(this, "Smithing10a1", () => I18n.Smithing10a1_Name(), () => I18n.Smithing10a1_Desc(), "assets/Smithing10a1.png");
            Profession10a2 = new BlacksmithingProfession(this, "Smithing10a2", () => I18n.Smithing10a2_Name(), () => I18n.Smithing10a2_Desc(), "assets/Smithing10a2.png");
            Profession10b1 = new BlacksmithingProfession(this, "Smithing10b1", () => I18n.Smithing10b1_Name(), () => I18n.Smithing10b1_Desc(), "assets/Smithing10b1.png");
            Profession10b2 = new BlacksmithingProfession(this, "Smithing10b2", () => I18n.Smithing10b2_Name(), () => I18n.Smithing10b2_Desc(), "assets/Smithing10b2.png");

            Professions.Add(Profession5a);
            Professions.Add(Profession5b);
            ProfessionsForLevels.Add(new ProfessionPair(5, Profession5a, Profession5b, null));
            Professions.Add(Profession10a1);
            Professions.Add(Profession10a2);
            ProfessionsForLevels.Add(new ProfessionPair(10, Profession10a1, Profession10a2, Profession5a));
            Professions.Add(Profession10b1);
            Professions.Add(Profession10b2);
            ProfessionsForLevels.Add(new ProfessionPair(10, Profession10b1, Profession10b2, Profession5b));
        }

        public override string GetName()
        {
            return I18n.Skill_Name();
        }

        public override List<string> GetExtraLevelUpInfo(int level)
        {
            return new List<string> { I18n.Skill_Perk() };
        }

        public override string GetSkillPageHoverText(int level)
        {
            return I18n.Skill_PerkBonus(bonus: level);
        }
    }
}
