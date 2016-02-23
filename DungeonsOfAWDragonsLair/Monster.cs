using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    class Monster : Character, ILuggable
    {
        public static int MonsterCount { get; set; }

        public int Weight { get; set; }


        public Monster(string name, int health, int attackStrength, int weight) : base(name, health, attackStrength)
        {
            Weight = weight;
            MonsterCount++;
        }

        public override void Fight(Character opponent)
        {
            opponent.Health -= AttackStrength;
        }

        public override string Message(Character opponent)
        {
            return "monster message";
        }

        public void PickUp(Player player)
        {
            player.BackPack.Add(this);
        }
    }
}
