using System;
using System.Collections.Generic;
using System.IO;

namespace Jamaker
{
    public class Skf
    {
        public List<double> sfps;
        public List<double> kfps;
        public Skf(List<double> sfps, List<double> kfps)
        {
            this.sfps = sfps;
            this.kfps = kfps;
        }
        
        public static Skf Load(string path)
        {
            List<double> sfs = new List<double>();
            List<double> kfs = new List<double>();

            FileStream fs = new FileStream(path, FileMode.Open);

            int didread;
            byte[] buffer = new byte[sizeof(double) * (1024 + 1)];

            int length, residual_length;

            didread = fs.Read(buffer, 0, sizeof(int) * 2);
            int sfsLength = BitConverter.ToInt32(buffer, 0);
            int kfsLength = BitConverter.ToInt32(buffer, sizeof(int));

            int count = 0;

            while ((didread = fs.Read(buffer, 0, sizeof(double) * 1024)) != 0)
            {
                length = didread;
                residual_length = length % sizeof(double);

                length -= residual_length;

                for (int index = 0; index < length; index += sizeof(double))
                {
                    double value = BitConverter.ToDouble(buffer, index);
                    if (count < sfsLength)
                        sfs.Add(value);
                    else if (count < sfsLength + kfsLength)
                        kfs.Add(value);
                    else
                    {

                    }
                    count++;
                }
            }

            fs.Close();

            //Console.WriteLine(sfs.Count + "/" + sfsLength + ", " + kfs.Count + "/" + kfsLength);

            return new Skf(sfs, kfs);
        }
        
        public int Save(string path)
        {
            int length = 0;

            byte[] buffer;
            FileStream fs = new FileStream(path, FileMode.Create);

            buffer = BitConverter.GetBytes(sfps.Count);
            fs.Write(buffer, 0, buffer.Length);
            length += buffer.Length;

            buffer = BitConverter.GetBytes(kfps.Count);
            fs.Write(buffer, 0, buffer.Length);
            length += buffer.Length;

            foreach (double sf in sfps)
            {
                buffer = BitConverter.GetBytes(sf);
                fs.Write(buffer, 0, buffer.Length);
                length += buffer.Length;
            }

            foreach (double kf in kfps)
            {
                buffer = BitConverter.GetBytes(kf);
                fs.Write(buffer, 0, buffer.Length);
                length += buffer.Length;
            }

            fs.Close();

            //Console.Write("save length: " + length);

            return length;
        }
        
        public List<double> GetSfps10()
        {
            List<double> result = new List<double>();

            double[] vs = new double[10];
            for (int i = 0; i < sfps.Count; i++)
            {
                vs[i % 10] = sfps[i];
                if (i < 9) continue;

                double sum = 0;
                foreach (double v in vs)
                {
                    sum += v;
                }
                result.Add(sum);
            }

            return result;
        }
    }
}
