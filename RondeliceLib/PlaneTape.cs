using SlugsLib.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlugsLib
{
    /// <summary>
    /// Ravninski trak (trak za izsekovanje rondelic)
    /// </summary>
    public class PlaneTape
    {
        CoordinateSystem coorSys;
        int tapeWidth;
        int tapeHeight;
        List<Cell> generatedCells;
        Cell firstCircleCell;
        List<double> degrees;
        List<CellPoint> centerCirclePoints;
        List<Cell> occupiedCellsForNextSlug;

        public PlaneTape(int width, int height)
        {
            tapeWidth = width;
            tapeHeight = height;
            coorSys = new CoordinateSystem();
            coorSys.GenerateCoordinateSystem(width, height);
            generatedCells = new List<Cell>();
            firstCircleCell = new Cell();

            degrees = new List<double> { 0, 45, 90, 135, 180, 225, 270, 315 };
            centerCirclePoints = new List<CellPoint>();

            occupiedCellsForNextSlug = new List<Cell>();
        }
        /// <summary>
        /// Inicializiramo prvi krog na traku.
        /// </summary>
        /// <param name="circleRadious"> Polmer kroga</param>
        public CellPoint InitializeFirstCircle(decimal circleRadious, double aParam)
        {
            generatedCells = coorSys.GenerateCells(circleRadious, tapeWidth, tapeHeight);

            int centerCellCoorX = Convert.ToInt32((circleRadious * coorSys.GetxCoorFactor));
            int centerCellCoorY = Convert.ToInt32((circleRadious * coorSys.GetyCoorFactor));

            firstCircleCell = generatedCells.Where(c => c.listOfPoints
                .Any(ce => ce.cellPointCoor.X == centerCellCoorX && ce.cellPointCoor.Y == centerCellCoorY))
                .FirstOrDefault();

            if (firstCircleCell != null)
            {
                firstCircleCell.isOccupied = true;

                CellPoint centerCirclePoint = firstCircleCell.listOfPoints.Where(cc => cc.cellPointCoor.X == centerCellCoorX && cc.cellPointCoor.Y == centerCellCoorY).FirstOrDefault();

                return centerCirclePoint;
            }
            return null;
        }

        /// <summary>
        /// Poiščemo točko ki bo predstavljala središče krožnice
        /// </summary>
        /// <param name="currentCenterCirclePoint">središčna točka že postavljene rondelice na trak</param>
        /// <param name="radious">polmer</param>
        /// <param name="aParam">minimalna razdalja med roboma rondelic</param>
        /// <returns></returns>
        public CellPoint GetNextBestPoint(CellPoint currentCenterCirclePoint, double radious, double aParam)
        {
            CellPoint circleCenter = null;
            //preverimo iz 8 točk na krožnici
            double aParamFull = (aParam * coorSys.GetxCoorFactor);
            double radiousFull = Convert.ToDouble(radious * coorSys.GetxCoorFactor);

            foreach (double item in degrees)
            {
                //Pridobimo novo točko na krožnici s pomočjo kota
                Coordinate coor = CommonMethods.GetNewCoordinateByDegree(currentCenterCirclePoint, coorSys.GetxCoorFactor, radious, item);
                int sumNewCoor = Convert.ToInt32(radiousFull + aParamFull);// da pridemo do nove točke ki bo predstavljala središče rondelice prištejemo trenutni točki na krožnici še polmer in minimalni razmik med roboma rondelic

                if (item == 0)
                {
                    coor.X += sumNewCoor;
                }
                else if (item == 45)
                {
                    coor.X += Convert.ToInt32(((Math.Cos(item) * radiousFull) + Math.Cos(item) * aParamFull));
                    coor.Y += Convert.ToInt32(((Math.Cos(item) * radiousFull) + Math.Cos(item) * aParamFull));

                }
                else if (item == 90)
                {
                    coor.Y += sumNewCoor;
                }
                else if (item == 135)
                {
                    coor.X += Convert.ToInt32(((Math.Cos(item) * radiousFull) + Math.Cos(item) * aParamFull));
                    coor.Y += Convert.ToInt32(((Math.Cos(item) * radiousFull) + Math.Cos(item) * aParamFull));
                }
                else if (item == 180)
                {
                    coor.X += sumNewCoor;
                }
                else if (item == 225)
                {
                    coor.X += Convert.ToInt32(((Math.Cos(item) * radiousFull) + Math.Cos(item) * aParamFull));
                    coor.Y += Convert.ToInt32(((Math.Cos(item) * radiousFull) + Math.Cos(item) * aParamFull));
                }
                else if (item == 270)
                {
                    coor.Y += sumNewCoor;
                }
                else if (item == 315)
                {
                    coor.X += Convert.ToInt32(((Math.Cos(item) * radiousFull) + Math.Cos(item) * aParamFull));
                    coor.Y += Convert.ToInt32(((Math.Cos(item) * radiousFull) + Math.Cos(item) * aParamFull));
                }

                //poiščemo celico v kateri se nahaja nova točka
                Cell cellNewCircle = generatedCells.Where(c => c.listOfPoints
                .Any(ce => ce.cellPointCoor.X == coor.X && ce.cellPointCoor.Y == coor.Y))
                .FirstOrDefault();

                if (cellNewCircle != null)
                {
                    occupiedCellsForNextSlug.Clear();
                    //najdemo koordinate nove točke
                    circleCenter = cellNewCircle.listOfPoints.Where(cc => cc.cellPointCoor.X == coor.X && cc.cellPointCoor.Y == coor.Y).FirstOrDefault();

                    //preverimo če se nova rondelica/krožnica kje seka z že obstoječimi rondelicami
                    bool isCircleInCollision = IsCircleInCollision(circleCenter, Convert.ToDouble(radious));

                    if (!isCircleInCollision && !cellNewCircle.isOccupied)
                    {
                        cellNewCircle.isOccupied = true;
                        occupiedCellsForNextSlug.ForEach(c => c.isOccupied = true);
                        return circleCenter;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Če je nova krožnica kje v trku z že obstoječimi krožnicami/rondelicami
        /// </summary>
        /// <param name="centerCirclePoint">Nova središčna točka krožnice</param>
        /// <param name="radious">Polmer krožnice</param>
        /// <returns></returns>
        private bool IsCircleInCollision(CellPoint centerCirclePoint, double radious)
        {
            //pridobimo maksimalne in minimalne koordinate
            int maxX = coorSys.GetMaxCoordinateX;
            int maxY = coorSys.GetMaxCoordinateY;
            int minX = coorSys.GetMinCoordinateX;
            int minY = coorSys.GetMinCoordinateY;

            //preverimo 8 točk na na novi še ne vstavljeni krožnici/rondelici
            foreach (double item in degrees)
            {
                Coordinate coor = CommonMethods.GetNewCoordinateByDegree(centerCirclePoint, coorSys.GetxCoorFactor, radious, item);

                if (coor != null)
                {
                    Cell circleCell = generatedCells.Where(c => c.listOfPoints
                        .Any(ce => ce.cellPointCoor.X == coor.X && ce.cellPointCoor.Y == coor.Y))
                        .FirstOrDefault();

                    if (circleCell == null)
                        return true;
                    else
                    {
                        //če še ta celica ne obstaja v seznamu v katerm leži krožnica
                        if (!occupiedCellsForNextSlug.Exists(c => c.startCoordinate.X == circleCell.startCoordinate.X && c.startCoordinate.Y == circleCell.startCoordinate.Y) &&
                            !occupiedCellsForNextSlug.Exists(c => c.startCoordinate.X == coor.X && c.startCoordinate.Y == coor.Y))
                        {
                            if (circleCell.isOccupied)
                                return true;
                            else if (coor.X > maxX)
                                return true;
                            else if (coor.X < minX)
                                return true;
                            else if (coor.Y > maxY)
                                return true;
                            else if (coor.Y < minY)
                                return true;

                            occupiedCellsForNextSlug.Add(circleCell);
                        }
                    }
                }
                else
                    return true;
            }

            return false;
        }

        public void ClearData()
        {
            coorSys = new CoordinateSystem();
            generatedCells.Clear();
            coorSys.ClearCoordinates();
        }
    }
}
