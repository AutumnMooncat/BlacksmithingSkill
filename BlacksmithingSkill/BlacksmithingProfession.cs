using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using SpaceCore;

namespace BlacksmithingSkillCode
{
    internal class BlacksmithingProfession : Skills.Skill.Profession
    {
        public Func<string> nameFunc;
        public Func<string> descFunc;

        public BlacksmithingProfession(Skills.Skill skill, string id, Func<string> nameFunc, Func<string> descFunc, string pathToIcon) : base(skill, id)
        {
            Icon = ModEntry.Instance.Helper.ModContent.Load<Texture2D>(pathToIcon);
            this.nameFunc = nameFunc;
            this.descFunc = descFunc;
        }

        public override string GetDescription()
        {
            return descFunc.Invoke();
        }

        public override string GetName()
        {
            return nameFunc.Invoke();
        }
    }
}
