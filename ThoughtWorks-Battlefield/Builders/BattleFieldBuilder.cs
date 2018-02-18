using System;
using ThoughtWorksBattlefield.Common;

namespace ThoughtWorksBattlefield.Builders
{
    public class BattleFieldBuilder : IBattleFieldBuilder
    {
        private readonly IBattleField _battleField;
        public BattleFieldBuilder()
        {
            _battleField = new BattleField();
        }

        public IBattleField Build()
        {
            return this._battleField;
        }

        public IBattleFieldBuilder SetDimensions(string dimension)
        {
            string[] battleAreaDimensions = dimension.Split(" ");
            _battleField.Width = battleAreaDimensions[0].ToInt();
            _battleField.Height = battleAreaDimensions[1][0].ToIntFromChar();

            if (_battleField.Width < 1 || _battleField.Width > 9)
            {
                throw new ArgumentException("Invalid Width");
            }
            if (_battleField.Height < 1 || _battleField.Height > 26)
            {
                throw new ArgumentException("Invalid Height");
            }
            return this;
        }

        public IBattleFieldBuilder SetShipCount(string shipCount)
        {
            _battleField.ShipCount = shipCount.ToInt();
            if (_battleField.ShipCount < 1 || _battleField.ShipCount > (_battleField.Width * _battleField.Height))
            {
                throw new ArgumentException("invalid number of ships");
            }
            return this;
        }

        public IBattleFieldBuilder SetupPlayers()
        {
            _battleField.Player1 = new Player("Player-1");
            _battleField.Player2 = new Player("Player-2");
            return this;
        }
        public IBattleFieldBuilder SetupController()
        {
            _battleField.Controller = new GameController(_battleField.Player1, _battleField.Player2);
            return this;
        }
    }
}
