using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    class Sword:Item 
    {
        public int AttackStrength { get; set; }

        public Sword(string name, int weight, int attackStrength):base(name,weight)
        {
            AttackStrength = attackStrength; 
        }

        public override void PickUpItem(Player player)
        {
            player.BackPack.Add(this); 
            player.AttackStrength += AttackStrength;  
        }
    }
}
