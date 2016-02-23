using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    class Dragon : Item
    {
        public int AttackStrength { get; set; }

        public Dragon(string name, int weight, int attackstrength) : base(name, weight)
        {

        }
        public override void PickUp(Player player)
        {
            player.BackPack.Add(this);
            player.AttackStrength += AttackStrength;
        }
    }
}
