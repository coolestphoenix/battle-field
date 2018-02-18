using System;
using ThoughtWorksBattlefield.Common;

namespace ThoughtWorksBattlefield
{
    public class BattleFieldGame : IBattleFieldGame
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int ShipCount { get; set; }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public GameController Controller { get; set; }
        public void ArrangeShips(string input)
        {
            var shipTypeAndCoordinates = input.Split(" ");
            var widthOfShip = shipTypeAndCoordinates[1].ToInt();
            if (widthOfShip < 1 || widthOfShip > this.Width)
            {
                throw new ArgumentException("Invalid ship width");
            }
            var heightOfShip = shipTypeAndCoordinates[2].ToInt();
            if (heightOfShip < 1 || heightOfShip > this.Height)
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
            Player1.SetupShips(strength, heightOfShip, widthOfShip, p1Coordinates);

            var p2Coordinates = shipTypeAndCoordinates[4];
            Player2.SetupShips(strength, heightOfShip, widthOfShip, p2Coordinates);
        }
        public void StartGame()
        {
            Controller.start();
        }
    }
}
