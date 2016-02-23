using DungeonsOfAWLib;
using Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items
{
    internal class Dragon : Item
    {
        internal int AttackStrength { get; set; }

        internal Dragon(string name, int weight, int attackstrength, ConsoleColor color) : base(name, weight, color = ConsoleColor.Magenta)
        {
        }
        public override void PickUp(Player player)
        {
            player.BackPack.Add(this);
            player.AttackStrength += AttackStrength;
        }
    }
}
