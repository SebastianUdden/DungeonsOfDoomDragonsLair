using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    class Item : GameObject
    {
        public Item(string name, int weigth) : base(name)
        {
            Weight = weigth;
        }
        public int Weight { get; set; }
    }
}
