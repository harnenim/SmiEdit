using System;
using System.Collections.Generic;

namespace Jamaker
{
    class StDev
    {
        public List<double> values = new List<double>();
        public List<double> pows = new List<double>();
        public double sum = 0;
        public double pSum = 0;
        public double avg = 0;
        public double value = 0;

        public StDev() { }
        public StDev(List<double> values)
        {
            for (int i = 0; i < values.Count; i++)
            {
                Add(values[i]);
            }
        }
        public void Add(double value)
        {
            var pow = value * value;
            sum += value;
            pSum += pow;
            values.Add(value);
            pows.Add(pow);
        }
        public void Replace(int index, double value)
        {
            while (index < 0)
            {
                index += values.Count;
            }
            index %= values.Count;

            var pow = value * value;
            sum += value - values[index];
            pSum += pow - pows[index];
            values[index] = value;
            pows[index] = pow;
        }

        public double GetAvg()
        {
            return sum / values.Count;
        }
        public double GetVar()
        {
            return (pSum / values.Count) - Math.Pow(GetAvg(), 2);
        }
        public StDev Calc()
        {
            avg = sum / values.Count;
            value = Math.Sqrt((pSum / values.Count) - (avg * avg));
            return this;
        }
        public static StDev From(List<double> values)
        {
            return new StDev(values).Calc();
        }
    }





    class MathFunc
    {
        public static double StDev(double[] data)
        {
            double ret = 0;
            int Max = 0;

            try
            {
                Max = data.Length;
                if (Max == 0) { return ret; }
                ret = StDev(data, Avg(data));
            }
            catch (Exception) { throw; }
            return ret;
        }
        public static double StDev(double[] data, double avg)
        {
            double ret = 0;
            double TotalVariance = 0;
            int Max = 0;

            try
            {
                Max = data.Length;
                if (Max == 0) { return ret; }
                for (int i = 0; i < Max; i++)
                {
                    TotalVariance += Math.Pow(data[i] - avg, 2);
                }
                ret = Math.Sqrt(SafeDivide(TotalVariance, Max));
            }
            catch (Exception) { throw; }
            return ret;
        }
        public static double Avg(double[] data)
        {
            double ret = 0;
            double DataTotal = 0;

            try
            {
                for (int i = 0; i < data.Length; i++)
                {
                    DataTotal += data[i];
                }
                ret = SafeDivide(DataTotal, data.Length);
            }
            catch (Exception) { throw; }
            return ret;
        }
        public static double SafeDivide(double value1, double value2)
        {
            double ret = 0;
            try
            {
                if ((value1 == 0) || (value2 == 0)) { return ret; }
                ret = value1 / value2;
            }
            catch { }
            return ret;
        }
    }
}
