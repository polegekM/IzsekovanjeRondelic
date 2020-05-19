using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlugsLib.Common
{
    public static class CommonMethods
    {
        public static int ParseInt(object value)
        {
            int num = 0;
            if (value != null)
                int.TryParse(value.ToString(), out num);
            
            return num;
        }

        public static decimal ParseDecimal(object value)
        {
            decimal num = 0;
            if (value != null)
                decimal.TryParse(value.ToString(), out num);

            return num;
        }

        public static double ParseDouble(object value)
        {
            double num = 0;
            if (value != null)
                double.TryParse(value.ToString(), out num);

            return num;
        }

        public static double ConvertToRadians(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }

        public static Coordinate GetNewCoordinateByDegree(CellPoint centerCirclePoint, int xCoorFacotr, double radious, double degree)
        {
            Coordinate coor = new Coordinate();

            coor.X = Convert.ToInt32(Math.Round(centerCirclePoint.cellPointCoor.X + (Convert.ToDouble(radious * xCoorFacotr) * Math.Cos(CommonMethods.ConvertToRadians(degree)))));
            coor.Y = Convert.ToInt32(Math.Round(centerCirclePoint.cellPointCoor.Y + (Convert.ToDouble(radious * xCoorFacotr) * Math.Sin(CommonMethods.ConvertToRadians(degree)))));

            return coor;
        }
    }
}
