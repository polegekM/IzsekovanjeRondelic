using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlugsLib
{
    public class Cell
    {
        public int ID { get; set; }
        public decimal width { get; set; }
        public decimal height { get; set; }
        /// <summary>
        /// koordinata ki nakazuje začetek celice. Zgornji levi kot. 
        /// </summary>
        public Coordinate startCoordinate { get; set; }
        public List<CellPoint> listOfPoints { get; set; }
        public bool isOccupied { get; set; }
    }

    public class CellPoint
    {
        public int ID { get; set; }
        public Coordinate cellPointCoor { get; set; }

        public bool isCenterCircle { get; set; }
    }
}
