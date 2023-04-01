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
    public class DroneCsvData
    {
        public static IEnumerable GetTestCasesData(string filename)
        {
            string path = $@"{AppDomain.CurrentDomain.BaseDirectory}\{filename}";
            string[] lines = File.ReadAllLines(path);

            List<TestCaseData> testCasesData = new List<TestCaseData>();
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                int x = Int32.Parse(values[0]);
                int y = Int32.Parse(values[1]);
                int z = Int32.Parse(values[2]);
                int[] coordinates = { x, y, z };
                int expectedResult = Int32.Parse(values[3]);
                testCasesData.Add(new TestCaseData(coordinates, expectedResult));
            }
            return testCasesData;
        }
    }
}
