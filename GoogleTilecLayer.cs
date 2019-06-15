using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
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

    public class GoogleTilecLayer : TiledMapServiceLayer
    {
        private const double cornerCoordinate = 20037508.3427892;
        private string _baseURL;
        public GoogleTilecLayer(TypeOfTile typetile)
        {

            _baseURL = typetile.TotileString();

        }

        public override void Initialize()
        {
            ESRI.ArcGIS.Client.Projection.WebMercator mercator = new ESRI.ArcGIS.Client.Projection.WebMercator();
            this.FullExtent = new ESRI.ArcGIS.Client.Geometry.Envelope(-20037508.3427892, -20037508.3427892, 20037508.3427892, 20037508.3427892)
            {
                SpatialReference = new SpatialReference(102100)
            };

            this.SpatialReference = new SpatialReference(102100);

            this.TileInfo = new TileInfo()
            {
                Height = 256,
                Width = 256,
                Origin = new MapPoint(-cornerCoordinate, cornerCoordinate) { SpatialReference = new ESRI.ArcGIS.Client.Geometry.SpatialReference(102100) },
                Lods = new Lod[16]
            };

            double resolution = cornerCoordinate * 2 / 256;
            for (int i = 0; i < TileInfo.Lods.Length; i++)
            {
                TileInfo.Lods[i] = new Lod() { Resolution = resolution };
                resolution /= 2;
            }

            base.Initialize();
        }

        public override string GetTileUrl(int level, int row, int col)
        {

            string url = "http://mt" + (col % 4) + ".google.cn/vt/lyrs=" + _baseURL + "&v=w2.114&hl=en_US&gl=cn&" + "x=" + col + "&" + "y=" + row + "&" + "z=" + level + "&s=Galil";
            if (_baseURL == "s@92")
            {
                url = "http://mt" + (col % 4) + ".google.cn/vt/lyrs=" + _baseURL + "&v=w2.114&hl=en_US&gl=cn&" + "x=" + col + "&" + "y=" + row + "&" + "z=" + level + "&s=Galil";
            }
            if (_baseURL == "t@128")
            {
                url = "http://mt" + (col % 4) + ".google.cn/vt/lyrs=" + _baseURL + ",r@169000000&v=w2.114&hl=en_US&gl=cn&" + "x=" + col + "&" + "y=" + row + "&" + "z=" + level + "&s=Galil";
            }
            if (_baseURL == "m@161000000")
            {
                url = "http://mt" + (col % 4) + ".google.cn/vt/lyrs=" + _baseURL + "&v=w2.114&hl=en_US&gl=cn&" + "x=" + col + "&" + "y=" + row + "&" + "z=" + level + "&s=Galil";
            }


            return string.Format(url);

        }
    }

}
