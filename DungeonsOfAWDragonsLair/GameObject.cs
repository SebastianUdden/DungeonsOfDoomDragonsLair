using Items;
using Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    abstract class GameObject
    {
        public GameObject(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
