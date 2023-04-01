using NUnit.Framework;
using OTS2023_Task3_DroneSimulator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace OTS2023_Task3_DroneSimulator.Test
{
    public class DroneTest
    {
        private Drone drone;

        [SetUp]
        public void SetUp()
        {
            int[] coordinates = { 30, 0, 30 };
            int[] boundaries = { 50, 50, 50 };
            drone = new Drone(coordinates, boundaries);
        }

        [Test]
        public void Drone_MoveUp_SuccessfullMovingUp()
        {
            // ARRANGE
            int expectedYCoordinate = 1;

            // ACT
            drone.MoveUp();

            // ASSERT
            Assert.AreEqual(expectedYCoordinate, drone.coordinates[1]);
        }

        [Test]
        public void Drone_MoveBack_NegativeCoordinates_ExceptionThrown()
        {
            drone.coordinates = new int[]{ -5, -5, -5};

            Exception ex = Assert.Throws<CustomException>(() => drone.MoveBack());
            Assert.That(ex.Message, Is.EqualTo("You cannot move back if you don't pass valid value!"));
        }

        [TestCaseSource(typeof(DroneCsvData), "GetTestCasesData", new object[] { "move-up-data.csv" })]
        public void Drone_MoveUp_SuccessfulCoordinateChange(int[] coordinates, int expectedResult)
        {
            drone.coordinates = coordinates;
            
            drone.MoveUp();
            int actualResult = drone.coordinates[1];
            
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCaseSource(typeof(DronePICTData), "GetTestCasesData", new object[] { "validate-coordinates-data.txt" })]
        public void Drone_ValidateDroneCoordinates_SuccessfulValidation(int[] coordinates, bool expectedResult)
        {
            bool actualResult = drone.ValidateDroneCoordinates(coordinates);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TearDown]
        public void TearDown()
        {
            drone = null;
        }
    }
}
