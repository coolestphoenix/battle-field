namespace ThoughtWorksBattlefield
{
    public interface IBattleFieldGame
    {
        int Height { get; set; }
        int Width { get; set; }
        int ShipCount { get; set; }
        Player Player1 { get; set; }
        Player Player2 { get; set; }
        GameController Controller { get; set; }

        void ArrangeShips(string input);
        void StartGame();
    }
}
