using LandscapeGeneratorInterface;
using StorageTestImplementation;
using System;
using System.Collections.Generic;
using System.Drawing;
using StorageInterface;

namespace LandscapeGeneratorImplementation
{   

    public class LandscapeGenerator : ILandscapeGenerator
    {

        private IStorageInterface backend = new StorageTest();
        private List<Point> pointList = new List<Point>();
        private Random random = new Random();

        private List<Point> CalculateNextIteration(List<Point> points, int heightStep)
        {
            List<Point> newList = new List<Point>();
            newList.Add(points[0]);
            for (int i = 1; i < points.Count; i++)
            {
                Point startPoint = points[i - 1];
                Point endPoint = points[i];
                // calculate new midpoint                
                int newX = (startPoint.X + endPoint.X) / 2;
                int deltaY = random.Next(-heightStep, heightStep);
                int newY = ((startPoint.Y + endPoint.Y) / 2) + deltaY;
                Point midPoint = new Point(newX, newY);
                newList.Add(midPoint);
                newList.Add(endPoint);
            }
            return newList;
        }

        public List<Point> PointList {
            get
            {
                return pointList;
            }
        }

        public void ResetPointList(int width, int height)
        {
            pointList = new List<Point>()
            {
                new Point()
                {   X = 0,
                    Y = height/2,
                },
                new Point()
                {   X = width,
                    Y = height/2,
                }
            };
        }

        public void CalculateLandscape(int nrOfIterations, int heightStep)
        {
            for (int i = 0; i < nrOfIterations; i++)
            {
                pointList = CalculateNextIteration(pointList,heightStep);
                heightStep /= 2;
            }
        }

        public void SaveLandscape(string name)
        {
            backend.SaveLandscape(name, PointList);
        }

        public void LoadLandscape(string name)
        {
            pointList =  backend.LoadLandscape(name);
        }
    }
}
