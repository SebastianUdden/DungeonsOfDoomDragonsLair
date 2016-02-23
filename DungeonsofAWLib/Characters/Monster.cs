using DungeonsOfAWLib;
using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Characters
{
    class Monster : Character, ILuggable
    {
        internal static int MonsterCount { get; set; }
        public ConsoleColor Color { get; set; }
        public int Weight { get; set; }

        internal Monster(string name, int health, int attackStrength, int weight, ConsoleColor color) : base(name, health, attackStrength)
        {
            Weight = weight;
            Color = color;
            MonsterCount++;
        }

        internal override void Fight(Character opponent)
        {
            opponent.Health -= AttackStrength;
        }

        internal override string Message(Character opponent)
        {
            return "monster message";
        }

        public void PickUp(Player player)
        {
            player.BackPack.Add(this);
        }
    }
}
