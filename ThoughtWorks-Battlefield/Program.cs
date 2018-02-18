using System;
using System.Collections.Generic;
using System.Linq;
using ThoughtWorksBattlefield;

namespace ThoughtWorks_Battlefield
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] battleAreaDimensions =Console.ReadLine().Split(" ");
            int width = Convert.ToInt16(battleAreaDimensions[0]);
            if (width < 1 || width > 9)
            {
                throw new ArgumentException("invalid width");
            }
            int height = battleAreaDimensions[1][0].ToInt();
            if (height < 1 || height > 26)
            {
                throw new ArgumentException("invalid height");
            }
            int numberOfBattleShips = Convert.ToInt16(Console.ReadLine());
            if (numberOfBattleShips < 1 || numberOfBattleShips > (width * height))
            {
                throw new ArgumentException("invalid number of ships");
            }
            List<ShipPart> p1 = new List<ShipPart>();
            List<ShipPart> p2 = new List<ShipPart>();

            for (int i = 0; i < numberOfBattleShips; i++)
            {
                var shipTypeAndCoordinates = Console.ReadLine().Split(' ');
                var widthOfShip = Convert.ToInt16(shipTypeAndCoordinates[1]);
                if (widthOfShip < 1 || widthOfShip > width)
                {
                    throw new ArgumentException("Invalid ship width");
                }
                var heightOfShip = Convert.ToInt16(shipTypeAndCoordinates[2]);
                if (heightOfShip < 1 || heightOfShip > height)
                {
                    throw new ArgumentException("Invalid ship height");
                }
                int strength = 0;
                if (shipTypeAndCoordinates[0] == "P")
                {
                    strength = 1;
                }
                else if (shipTypeAndCoordinates[0] == "Q")
                {
                    strength = 2;
                }
                var p1Coordinates = shipTypeAndCoordinates[3];
                var startingX = Convert.ToInt16(p1Coordinates[1].ToString());
                var startingY = p1Coordinates[0].ToInt();
                for (int internalHeightCount = startingY; internalHeightCount < heightOfShip + startingY;
                    internalHeightCount++)
                {
                    for (int internalWidthCount = startingX;
                         internalWidthCount < widthOfShip + startingX;
                   internalWidthCount++)
                    {
                        p1.Add(new ShipPart
                        {
                            pos = new Position(internalWidthCount, internalHeightCount),
                            lives = strength
                        });
                    }
                }
                
                var p2Coordinates = shipTypeAndCoordinates[4];
                startingX = Convert.ToInt16(p2Coordinates[1].ToString());
                startingY = p2Coordinates[0].ToInt();
                for (int internalHeightCount = startingY; internalHeightCount < heightOfShip + startingY;
                    internalHeightCount++)
                {
                    for (int internalWidthCount = startingX;
                         internalWidthCount < widthOfShip + startingX;
                   internalWidthCount++)
                    {
                        p2.Add(new ShipPart
						{
							pos = new Position(internalWidthCount, internalHeightCount),
                            lives = strength
                        });
                    }
                }
            }
            var input1 = Console.ReadLine();
            var input2 = Console.ReadLine();
            var player1Targets = new Queue<Position>(input1.Split(" ").ToList().Select(s => new Position(s)));
            var player2Targets = new Queue<Position>(input2.Split(" ").ToList().Select(s => new Position(s)));
            BattleField b1 = new BattleField(p1, player1Targets, "Player-1");
            BattleField b2 = new BattleField(p2, player2Targets, "Player-2");
            GameController d = new GameController(b1, b2);
            d.start();
        }

    
    
    }

    public class ShipPart
    {
        public Position pos;
        public int lives;
    }
}
