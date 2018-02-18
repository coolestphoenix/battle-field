using System;
using System.Linq;
using System.Collections.Generic;
using ThoughtWorks_Battlefield;
using ThoughtWorksBattlefield.Common;

namespace ThoughtWorksBattlefield
{
    public class Player
    {
        List<PartOfAShip> _parts;
        Queue<Position> _targets;
        string _name;

        public Player(string name)
        {
            _name = name;
            _parts = new List<PartOfAShip>();
        }
        public void SetupShips(int strength, int height, int width, string coordinates)
        {
            var startingX = coordinates[1].ToInt();
            var startingY = coordinates[0].ToIntFromChar();
            for (int yCoordinate = startingY; yCoordinate < height + startingY;
                yCoordinate++)
            {
                for (int xCoordinate = startingX;
                     xCoordinate < width + startingX;
               xCoordinate++)
                {
                    _parts.Add(new PartOfAShip
                    {
                        position = new Position(xCoordinate, yCoordinate),
                        strengthRemaining = strength
                    });
                }
            }
        }
        public void SetupMissiles(string targetsInput)
        {
            _targets = new Queue<Position>(targetsInput.Split(" ").ToList().Select(s => new Position(s)));
        }
        public bool TakeHit(Position missilePosition)
        {
            var shipAtThatPosition = _parts.FirstOrDefault(shipPart => shipPart.strengthRemaining > 0 && shipPart.position.Equals(missilePosition));
            if (shipAtThatPosition != null)
            {
                shipAtThatPosition.strengthRemaining--; ;
                return true;
            }
            return false;
        }
        public Position Fire()
        {
            return _targets.Count != 0 ? _targets.Dequeue() : null;
        }
        public bool Destroyed()
        {
            return !_parts.Any(part => part.strengthRemaining > 0);
        }
        public string GetName()
        {
            return _name;
        }
        public int LeftOverTargets()
        {
            return _targets.Count;
        }
    }
}
