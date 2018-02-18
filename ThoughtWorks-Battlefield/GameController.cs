using System;
namespace ThoughtWorksBattlefield
{
    public class GameController
    {
        BattleField _player1;
        BattleField _player2;
        public GameController(BattleField player1, BattleField player2)
        {
            _player1 = player1;
            _player2 = player2;
        }
        void SwitchRoles()
        {
            var temp = _player1;
            _player1 = _player2;
            _player2 = temp;
        }
        private bool turnsRemain(){
            return _player1.LeftOverTargets() > 0 || _player2.LeftOverTargets() > 0;
        }
        public void start()
        {
            while (turnsRemain())
            {
                var target = _player1.Fire();
                if (target == null)
                {
                    Console.WriteLine(_player1.GetName() + " has no more missiles left to launch");
                    SwitchRoles();
                    continue;
                }
                var wasHit = _player2.TakeHit(target);
                if (wasHit)
                {
                    Console.WriteLine(_player1.GetName() + " fires a missle with target " + target.Print() + " which got hit");
                    if (_player2.Destroyed())
                    {
                        Console.WriteLine(_player1.GetName() + " won the battle");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine(_player1.GetName() + " fires a missle with target " + target.Print() + " which got miss");
                    SwitchRoles();
                }
            }
            Console.WriteLine("No one wins, PEACE prevails!!");
        }

    }
}
