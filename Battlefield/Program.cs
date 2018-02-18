using System;
using ThoughtWorksBattlefield.Builders;

namespace ThoughtWorks_Battlefield
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensionsInput = Console.ReadLine();
            var shipCountInput = Console.ReadLine();

            var battleField = new BattleFieldBuilder()
                .SetDimensions(dimensionsInput)
                .SetShipCount(shipCountInput)
                .SetupPlayers()
                .SetupController()
                .Build();

            for (int i = 0; i < battleField.ShipCount; i++)
            {
                var shipTypeAndCoordinates = Console.ReadLine();
                battleField.ArrangeShips(shipTypeAndCoordinates);
            }
            var targets1 = Console.ReadLine();
            var targets2 = Console.ReadLine();

            battleField.Player1.SetupMissiles(targets1);
            battleField.Player2.SetupMissiles(targets2);

            battleField.StartGame();
        }
    }
}
