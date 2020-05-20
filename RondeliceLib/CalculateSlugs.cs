using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlugsLib
{
    public class CalculateSlugs
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public decimal Radius { get; set; }
        public decimal EdgeLength { get; set; }
        public decimal EdgeWidth { get; set; }
        public decimal MinDistanceItem { get; set; }
        public int SlugsSum { get; set; }
        
        public CalculateSlugs()
        { }

        public CalculateSlugs(int length, int width, decimal radius, decimal edgeLength, decimal edgeWidth, decimal minDistanceItem)
        {
            Length = length;
            Width = width;
            Radius = radius;
            EdgeLength = edgeLength;
            EdgeWidth = edgeWidth;
            MinDistanceItem = minDistanceItem;
        }

        public int CalculateSum()
        {
            int validLength = Convert.ToInt32(Length - (2 * EdgeLength));
            int validWidth = Convert.ToInt32(Width - (2 * EdgeWidth));

            int circleResult = 0;
            double minDistanceSlug = Convert.ToDouble(MinDistanceItem);
            double radius = Convert.ToDouble(Radius);

            PlaneTape planTape = new PlaneTape(validLength, validWidth);
            CellPoint centerCirclePoint = planTape.InitializeFirstCircle(Radius, minDistanceSlug);

            if (centerCirclePoint != null)
            {
                circleResult++;

                int iterations = Convert.ToInt32((validLength + validWidth) / Radius);

                for (int i = 0; i < iterations; i++)
                {
                    CellPoint newPoint = planTape.GetNextBestPoint(centerCirclePoint, radius, minDistanceSlug);
                    if (newPoint != null)
                    {
                        centerCirclePoint = newPoint;
                        circleResult++;
                    }
                }
            }

            return circleResult;
        }
    }
}
