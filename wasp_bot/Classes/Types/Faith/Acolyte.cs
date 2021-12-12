using System;
using Bot.Modules;
using Microsoft.Data.Sqlite;

namespace Bot.Types
{
    class Acolyte : Archetype
    {
        readonly Provider provider = new Provider();

        private int TakeBonusForLevel(int level, string stat)
        {
            int[] lvlhealth = { 34, 44, 57, 74, 96, 124, 161, 209, 271, 352, 457, 594, 772, 1003, 1303, 1693, 2200, 2860, 3718, 4833 };
            int[] lvldamage = { 45, 58, 75, 97, 126, 163, 211, 274, 356, 462, 600, 780, 1014, 1318, 1713, 2226, 2893, 3760, 4888, 6354 };
            int[] lvlarmor = { 31, 40, 53, 68, 89, 115, 149, 194, 252, 327, 425, 552, 717, 932, 1211, 1574, 2046, 2659, 3457, 4494 };

            if (stat.Equals("health"))
                return lvlhealth[level - 1];
            else if (stat.Equals("damage"))
                return lvldamage[level - 1];
            else if (stat.Equals("armor"))
                return lvlarmor[level - 1];

            return 0;
        }

        public Acolyte(string name, ulong id)
        {
            int level = Convert.ToInt32(provider.GetFieldAwonaByID("level", Convert.ToString(id), "discord_id", "users"));
            _name = name;
            _id = id;
            _lvl = level;
            _health = TakeBonusForLevel(level, "health");
            _damage = TakeBonusForLevel(level, "damage");
            _armor = TakeBonusForLevel(level, "armor");
            _protection = 1.6f;
            _dodge = 0.6f;
            _luck = 0.2f;
            _multiplier = 1.6f;
        }
    }
}
