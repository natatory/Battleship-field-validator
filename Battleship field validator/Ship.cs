using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_field_validator
{
    public abstract class Ship
    {
        public Ship(int[] bowCoordinates, int[] sternCoordinates)
        {
            BowCoordinates = bowCoordinates;
            SternCoordinates = sternCoordinates;
        }
        public abstract string Name { get; }
        private int[] _bowCoordinates=new int[2];
        private int[] _sternCoordinates = new int[2];
        public int[] BowCoordinates
        {
            get => _bowCoordinates;
            private set { _bowCoordinates[0] = value[0]; _bowCoordinates[1] = value[1]; }
        }
        public int[] SternCoordinates
        {
            get => _sternCoordinates;
            private set { _sternCoordinates[0] = value[0]; _sternCoordinates[1] = value[1]; }
        }
    }
}
