using System;
using System.Linq;
using System.Collections.Generic;
using ThoughtWorks_Battlefield;

namespace ThoughtWorksBattlefield
{
    public class BattleField
    {
        List<ShipPart> _parts;
        Queue<Position> _targets;
        string _name;
        public BattleField(List<ShipPart> parts, Queue<Position> targets, string name)
        {
            _parts = parts;
            _targets = targets;
            _name = name;
        }
        public bool TakeHit(Position missilePosition)
        {
            var shipAtThatPosition = _parts.FirstOrDefault(shipPart => shipPart.lives > 0 && shipPart.pos.Equals(missilePosition));
            if (shipAtThatPosition != null)
            {
                shipAtThatPosition.lives--;;
                return true;
            }
            return false;
        }
        public Position Fire(){
            return _targets.Count != 0 ? _targets.Dequeue() : null;
        }
        public bool Destroyed(){
            return !_parts.Any(part => part.lives > 0);
        }
        public string GetName(){
            return _name;
        }
        public int LeftOverTargets(){
            return _targets.Count;
        }
    }
}
