using System;
namespace ThoughtWorksBattlefield.Common
{
    public static class Extensions
    {
        public static int ToInt(this char character)
        {
            return Convert.ToInt16(character.ToString());
        }
        public static int ToIntFromChar(this char character)
        {
            return char.ToUpper(character) - 64;
        }
        public static int ToInt(this string integer)
        {
            return Convert.ToInt16(integer);
        }
        public static char ToChar(this int integer)
        {
            return (char)integer;
        }
    }
}
