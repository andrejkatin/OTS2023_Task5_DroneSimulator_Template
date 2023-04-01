using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2023_Task3_DroneSimulator.Test
{
    public class DronePICTData
    {
        public static IEnumerable GetTestCasesData(string filename)
        {
            string path = $@"{AppDomain.CurrentDomain.BaseDirectory}\{filename}";
            string[] lines = File.ReadAllLines(path);

            List<TestCaseData> testCasesData = new List<TestCaseData>();
            foreach (string line in lines)
            {
                string[] values = line.Split(null);
                int x = Int32.Parse(values[0]);
                int y = Int32.Parse(values[1]);
                int z = Int32.Parse(values[2]);
                int[] coordinates = { x, y, z };
                bool expectedResult = values[3] == "yes";
                testCasesData.Add(new TestCaseData(coordinates, expectedResult));
            }
            return testCasesData;
        }
    }
}
