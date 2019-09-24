
using System;

namespace FactoryPattern
{
    //problem with this factory is that point constructor has to be made public 
    //nothing is then stopping the user of point class to directly use the constructor since the constructor is public
    public class PointFactory
    {
        //public static Point NewCartesianPoint(double x, double y)
        //{
        //    return new Point(x, y);
        //}

        //public static Point NewPolarPoint(double rho, double theta)
        //{
        //    return new Point(rho * Math.Sin(theta), rho * Math.Cos(theta));
        //}

    }
}
