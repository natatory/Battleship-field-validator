using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_field_validator
{
    public class BattleshipField
    {
        private BattleshipField(int[,] field)
        {
            battleField = field;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    chekedСells[i, j] = cellType.SeaCell;
        }
        private int battleShipCount = 0;
        private int cruiserCount = 0;
        private int destroyerCount = 0;
        private int submarineCount = 0;
        private int[,] battleField = new int[10, 10];
        private enum cellType { SeaCell, ShipCell }
        private cellType[,] chekedСells = new cellType[10, 10];
        public static bool ValidateBattlefield(int[,] field)
        {
            BattleshipField game = new BattleshipField(field);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (game.battleField[i, j] == 0 || game.chekedСells[i, j] == cellType.ShipCell) continue;
                    Ship newShip = game.GetShip(i, j);
                    if (newShip == null) return false;
                    switch (newShip.Name)
                    {
                        case "BattleShip":
                            if (++game.battleShipCount > 1) return false;
                            break;
                        case "Cruiser":
                            if (++game.cruiserCount > 2) return false;
                            break;
                        case "Destroyer":
                            if (++game.destroyerCount > 3) return false;
                            break;
                        case "Submarine":
                            if (++game.submarineCount > 4) return false;
                            break;
                    }
                    if (!game.ChekAroundCells(newShip)) return false;
                }
            }
            if (game.battleShipCount != 1 || game.cruiserCount != 2
                || game.destroyerCount != 3 || game.submarineCount != 4)
                return false;
            else return true;
        }
        private Ship GetShip(int i, int j)
        {
            int shipLenght = 1;
            chekedСells[i, j] = cellType.ShipCell;
            int[] bowCoordinates = new int[2] { i, j };
            int[] sternCoordinates = new int[2] { i, j };
            for (int n = 1; n < 4; n++)
            {
                if (i + n > 9) break;
                if (battleField[i + n, j] == 1)
                {
                    chekedСells[i + n, j] = cellType.ShipCell;
                    sternCoordinates[0] = i + n;
                    shipLenght++;
                }
                else break;
            }
            if (shipLenght == 1)
                for (int n = 1; n < 4; n++)
                {
                    if (j + n > 9) break;
                    if (battleField[i, j + n] == 1)
                    {
                        chekedСells[i, j + n] = cellType.ShipCell;
                        sternCoordinates[1] = j + n;
                        shipLenght++;
                    }
                    else break;
                }
            switch (shipLenght)
            {
                case 1: return new Submarine(bowCoordinates, sternCoordinates);
                case 2: return new Destroyer(bowCoordinates, sternCoordinates);
                case 3: return new Cruiser(bowCoordinates, sternCoordinates);
                case 4: return new BattleShip(bowCoordinates, sternCoordinates);
                default: return null;
            }
        }

        private bool ChekAroundCells(Ship ship)
        {
            int _i, _j;
            for (int i = ship.BowCoordinates[0] - 1; i <= ship.SternCoordinates[0] + 1; i++)
                for (int j = ship.BowCoordinates[1] - 1; j <= ship.SternCoordinates[1] + 1; j++)
                {
                    _i = i < 9 ? Math.Abs(i) : i - 1;
                    _j = j < 9 ? Math.Abs(j) : j - 1;
                    if (battleField[_i, _j] == 1
                        && (_i < ship.BowCoordinates[0] || _i > ship.SternCoordinates[0]
                        || _j < ship.BowCoordinates[1] || _j > ship.SternCoordinates[1]
                        || (_i >= ship.BowCoordinates[0] && _i <= ship.SternCoordinates[0] && (_j < ship.BowCoordinates[1] || _j > ship.SternCoordinates[1]))
                        || (_j >= ship.BowCoordinates[1] && _j <= ship.SternCoordinates[1] && (_i < ship.BowCoordinates[0] || _i > ship.SternCoordinates[0])))
                        )
                        return false;
                }
            return true;
        }
    }
}
