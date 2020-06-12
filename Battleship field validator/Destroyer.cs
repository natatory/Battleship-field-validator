using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_field_validator
{
    class Destroyer : Ship
    {
        public Destroyer(int[] bowCoordinates, int[] sternCoordinates)
    : base(bowCoordinates, sternCoordinates) { }

        public override string Name { get => "Destroyer"; }
    }
}
