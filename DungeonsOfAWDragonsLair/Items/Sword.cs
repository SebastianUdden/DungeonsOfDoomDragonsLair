using DungeonsOfAWDragonsLair;
using Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items
{
    class Sword:Item 
    {
        public int AttackStrength { get; set; }

        public Sword(string name, int weight, int attackStrength, ConsoleColor color):base(name,weight, color)
        {
            AttackStrength = attackStrength; 
        }

        public override void PickUp(Player player)
        {
            player.BackPack.Add(this); 
            player.AttackStrength += AttackStrength;  
        }
    }
}
