using System;
namespace ThoughtWorksBattlefield.Builders
{
    public interface IBattleFieldBuilder
    {
        IBattleFieldBuilder SetDimensions(string dimensions);
        IBattleFieldBuilder SetShipCount(string shipCount);
        IBattleFieldBuilder SetupPlayers();
        IBattleFieldBuilder SetupController();
        IBattleField Build();
    }
}
