using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    class Axe:Item
    {
        public int AttackStrength { get; set; }

        public Axe(string name, int weight, int attackStrength):base(name,weight)
        {
            AttackStrength = attackStrength;
        }

        public override void PickUpItem(Player player)
        {
            player.BackPack.Add(this);
            player.AttackStrength += AttackStrength/2;
        }

    }
}
