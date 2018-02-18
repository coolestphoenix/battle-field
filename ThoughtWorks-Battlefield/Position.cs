using System;
namespace ThoughtWorksBattlefield
{
    public class Position : IEquatable<Position>
    {
        private readonly int _xCoordinate;
        private readonly int _yCoordinate;
        private readonly char _yCharacter;
        public Position(int x, int y)
        {
            _xCoordinate = x;
            _yCoordinate = y;
            _yCharacter = y.ToChar();
        }
        public Position(string position)
        {
            _yCharacter = position[0];
            _yCoordinate = position[0].ToInt();
            _xCoordinate = Convert.ToInt16(position[1].ToString());
        }
        internal string Print()
        {
            return (_yCharacter + "" + _xCoordinate).ToUpper();
        }

        public bool Equals(Position other)
        {
            return this._xCoordinate == other._xCoordinate && this._yCoordinate == other._yCoordinate;
        }
    }
}
