using System;
namespace ThoughtWorksBattlefield
{
	public static class Extensions
{
        public static int ToInt(this char character)
        {
            return char.ToUpper(character) - 64;
        }
        public static char ToChar(this int integer){
            return (char)integer;   
        }
}
}
