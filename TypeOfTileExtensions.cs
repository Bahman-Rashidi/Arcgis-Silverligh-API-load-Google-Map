using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace GoogleMapLayer
{
    public static class TypeOfTileExtensions
    {

        public static string TotileString(this TypeOfTile me)
        {
            switch (me)
            {
                case TypeOfTile.sateliteImage:
                    return "s@92";
                case TypeOfTile.map:
                    return "m@161000000";

                default:
                    return "t@128";
            }
        }
    }
}
