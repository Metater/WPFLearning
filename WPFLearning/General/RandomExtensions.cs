using devDept.Geometry;
using System;
using System.Drawing;

namespace WPFLearning.General
{
    public static class RandomExtensions
    {
        public static Color GetRandomColor(this Random random)
        {
            int argb = random.Next(int.MinValue, int.MaxValue);

            // Ensure no transparency
            unchecked
            {
                argb |= (int)0xFF000000;
            }

            return Color.FromArgb(argb);
        }

        public static double GetRandomDouble(this Random random, double min, double max)
        {
            return min + ((max - min) * random.NextDouble());
        }

        public static Vector3D GetRandomPosition(this Random random, double min, double max)
        {
            return new Vector3D(GetRandomDouble(random, min, max), GetRandomDouble(random, min, max), GetRandomDouble(random, min, max));
        }
    }
}
