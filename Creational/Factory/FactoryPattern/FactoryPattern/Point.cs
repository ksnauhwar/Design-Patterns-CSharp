using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    public class Point
    {
        public double X, Y;

        private Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        
        //This is the inner factory
        //it is solution to the problem of point factory
        public class Factory
        {

            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Sin(theta), rho * Math.Cos(theta));
            }
        }

        public override string ToString()
        {
            return $"x : {X}, y : {Y}";
        }
    }
}
