using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlugsLib
{
    public class CoordinateSystem
    {
        const int xCoorFactor = 10;
        const int yCoorFactor = 10;
        private List<Coordinate> coordinates;
        public CoordinateSystem()
        { }

        /// <summary>
        /// Generiramo koordinatni sistem za lažje preverjanje koordinat na podlagi dolžine in širine traka.
        /// </summary>
        /// <param name="width">dolžina traka</param>
        /// <param name="height">širina traka</param>
        public void GenerateCoordinateSystem(int width, int height)
        {
            //širino in dolžino traka pomnožimo z fakrotjem da na koordinatnem sistemu dobimo več razdelkov.
            int xCoorMax = (width * xCoorFactor);
            int yCoorMax = (height * yCoorFactor);

            //generiramo koordinatni sistem ki bo imel enako število koordinat na x in y osi.
            if (xCoorMax > yCoorMax)
                GenerateCoordinates(xCoorMax);
            else if (xCoorMax < yCoorMax)
                GenerateCoordinates(yCoorMax);
            else
                GenerateCoordinates(xCoorMax);
        }

        private void GenerateCoordinates(int maxCoor)
        {
            coordinates = new List<Coordinate>();
            Coordinate coor = null;

            for (int i = 0; i <= maxCoor; i++)
            {
                for (int j = 0; j <= maxCoor; j++)
                {
                    coor = new Coordinate();

                    coor.X = i;
                    coor.Y = j;

                    coordinates.Add(coor);
                }
            }
        }
        /// <summary>
        /// Za lažje vmeščanje rondelic na trak se uporabijo celice v katerih je seznam točk s pomočjo katerih lažje določamo nove središčne točke
        /// </summary>
        /// <param name="circleRadious">polmer krožnice</param>
        /// <param name="width">Dolžina traka</param>
        /// <param name="height">Širina traka</param>
        /// <returns>Seznam celic</returns>
        public List<Cell> GenerateCells(decimal circleRadious, int width, int height)
        {
            //poizkušamo dobiti dve celici na polovico rondelice (4 celice na celotno rondelico)
            decimal squareCellSize = circleRadious;
            int cellCountX = Convert.ToInt32(squareCellSize * width);
            int cellCountY = Convert.ToInt32(squareCellSize * height);
            List<Cell> listOfCells = new List<Cell>();
            Cell cell = null;
            for (int i = 0; i < cellCountX; i++)
            {
                for (int j = 0; j < cellCountY; j++)
                {
                    cell = new Cell();
                    cell.width = squareCellSize;
                    cell.height = squareCellSize;
                    //pridobimo začetno koordinato celice. Trenutno celico pomnožimo z velikostjo celice in faktorjem za X koordinato. Enako za Y
                    cell.startCoordinate = new Coordinate { X = Convert.ToInt32(i * (squareCellSize * xCoorFactor)), Y = Convert.ToInt32(j * (squareCellSize * yCoorFactor)) };

                    cell.listOfPoints = GenerateCellPoints(Convert.ToInt32(squareCellSize * xCoorFactor), Convert.ToInt32(squareCellSize * yCoorFactor), cell.startCoordinate);

                    listOfCells.Add(cell);
                }
            }
            return listOfCells;
        }

        private List<CellPoint> GenerateCellPoints(int pointsCountX, int pointsCountY, Coordinate cellStartCoordinate)
        {
            List<CellPoint> cellPoints = new List<CellPoint>();
            CellPoint point = null;

            for (int i = 0; i < pointsCountX; i++)
            {
                for (int j = 0; j < pointsCountY; j++)
                {
                    point = new CellPoint();
                    //pridobimo začetno koordinato celice in prištevamo nove koordinate trenutni točki na podlagi spremenljivk v zanki.
                    point.cellPointCoor = new Coordinate { X = (cellStartCoordinate.X + i), Y = (cellStartCoordinate.Y + j) };
                    point.isCenterCircle = false;

                    cellPoints.Add(point);
                }
            }

            return cellPoints;
        }

        public int GetxCoorFactor
        {
            get { return xCoorFactor; }
        }

        public int GetyCoorFactor
        {
            get { return yCoorFactor; }
        }

        public int GetMaxCoordinateX
        {
            get { return coordinates.Max(c => c.X); }
        }

        public int GetMaxCoordinateY
        {
            get { return coordinates.Max(c => c.Y); }
        }

        public int GetMinCoordinateX
        {
            get { return coordinates.Min(c => c.X); }
        }

        public int GetMinCoordinateY
        {
            get { return coordinates.Min(c => c.Y); }
        }

        public void ClearCoordinates()
        {
            if(coordinates != null)
                coordinates.Clear();
        }
    }

    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
