using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_field_validator
{
    class Cruiser : Ship
    {
        public Cruiser(int[] bowCoordinates, int[] sternCoordinates)
    : base(bowCoordinates, sternCoordinates) { }
        public override string Name { get => "Cruiser"; }
    }
}
