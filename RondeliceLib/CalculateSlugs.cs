using SlugsLib.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SlugsLib
{
    public class CalculateSlugs
    {
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Radius { get; set; }
        public decimal EdgeLength { get; set; }
        public decimal EdgeWidth { get; set; }
        public decimal MinDistanceItem { get; set; }
        public int SlugsSum { get; set; }

        public CalculateSlugs()
        { }

        public CalculateSlugs(decimal length, decimal width, decimal radius, decimal edgeLength, decimal edgeWidth, decimal minDistanceItem)
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
            ValidateInputValues();

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

        private void ValidateInputValues()
        {
            //1. Premer rondelice ne sme bit večji kot širina traku in ne sme bit negativna
            //2. Dolžina ne sme bit večja od širine in ne sme bit negativna???
            //3. Robovi ne smejo bit negativni oz večji od dolžine ali širine (2-kratnik roba ne sme bit večji od širine ali dolžine)
            //4. Minimalna distanca ne sme bit negativna in mora biti večja od 0 in manjša od širine traku
            
            IsNegativeValues();

            if ((2 * Radius) > Width)
                throw new ArgumentValidationException(ValidationRes.res_02);

            if (Width > Length)
                throw new ArgumentValidationException(ValidationRes.res_03);

            if ((2 * EdgeLength) > Width)
                throw new ArgumentValidationException(ValidationRes.res_04);

            if ((2 * EdgeWidth) > Length)
                throw new ArgumentValidationException(ValidationRes.res_05);

            if(MinDistanceItem == 0 || MinDistanceItem > Width)
                throw new ArgumentValidationException(ValidationRes.res_06);
        }

        private void IsNegativeValues()
        {
            foreach (PropertyInfo item in this.GetType().GetProperties())
            {
                decimal value = CommonMethods.ParseDecimal(item.GetValue(this));
                if (value < 0)
                    throw new ArgumentValidationException(ValidationRes.res_01);
            }
        }
    }
}
