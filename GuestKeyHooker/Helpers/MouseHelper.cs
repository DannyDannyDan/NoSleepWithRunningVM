using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestKeyHooker.Helpers
{
    internal static class MouseHelper
    {
        public static void MoveMouse(Point point)
        {
            while (Cursor.Position.X < point.X)
                Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y);
            while (Cursor.Position.X > point.X)
                Cursor.Position = new Point(Cursor.Position.X - 1, Cursor.Position.Y);
            while (Cursor.Position.Y < point.Y)
                Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + 1);
            while (Cursor.Position.Y > point.Y)
                Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y - 1);


        }

    }
}
