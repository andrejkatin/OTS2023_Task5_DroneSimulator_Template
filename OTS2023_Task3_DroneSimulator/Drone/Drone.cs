using OTS2023_Task3_DroneSimulator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2023_Task3_DroneSimulator
{
    public class Drone : IDrone
    {
        protected int step = 1;
        public int[] coordinates;
        protected int[] outerBoundaries;

        // Constructors
        public Drone()
        {

        }

        public Drone(int[] coordinates, int[] outerBoundaries) 
        {
            this.coordinates = coordinates;
            this.outerBoundaries = outerBoundaries;
        }

        // Core methods
        public void MoveBack()
        {
            if (ValidateDronePositionAfter("back"))
            {
                coordinates[2] += step;
            }
            else
            {
                throw new CustomException("You cannot move back if you don't pass valid value!");
            }
        }

        public void MoveDown()
        {
            if (ValidateDronePositionAfter("down"))
            {
                coordinates[1] -= step;
            }
        }

        public void MoveForth()
        {
            if (ValidateDronePositionAfter("forth"))
            {
                coordinates[2] -= step;
            }
        }

        public void MoveLeft()
        {
            if (ValidateDronePositionAfter("left"))
            {
                coordinates[0] -= step;
            }
        }

        public void MoveRight()
        {
            if (ValidateDronePositionAfter("right"))
            {
                coordinates[0] += step;
            }
        }

        public void MoveUp()
        {
            if (ValidateDronePositionAfter("up"))
            {
                coordinates[1] += step;
            }
        }

        // Validators
        public bool ValidateDronePositionAfter(string command)
        {
            int[] newCoordinates;
            switch (command)
            {
                case "up":
                    newCoordinates = new int[] { coordinates[0], coordinates[1] + 1, coordinates[2] };
                    return ValidateDroneCoordinates(newCoordinates);
                case "down":
                    newCoordinates = new int[] { coordinates[0], coordinates[1] - 1, coordinates[2] };
                    return ValidateDroneCoordinates(newCoordinates);
                case "left":
                    newCoordinates = new int[] { coordinates[0] - 1, coordinates[1], coordinates[2] };
                    return ValidateDroneCoordinates(newCoordinates);
                case "right":
                    newCoordinates = new int[] { coordinates[0] + 1, coordinates[1], coordinates[2] };
                    return ValidateDroneCoordinates(newCoordinates);
                case "back":
                    newCoordinates = new int[] { coordinates[0], coordinates[1], coordinates[2] + 1 };
                    return ValidateDroneCoordinates(newCoordinates);
                case "forth":
                    newCoordinates = new int[] { coordinates[0], coordinates[1], coordinates[2] - 1 };
                    return ValidateDroneCoordinates(newCoordinates);
            }
            return false;
        }

        public bool ValidateDroneCoordinates(int[] coordinates)
        {
            if (coordinates[0] > outerBoundaries[0] || coordinates[1] > outerBoundaries[1] || coordinates[2] > outerBoundaries[2])
            {
                return false;
            }
            else if (coordinates[0] < 0 || coordinates[1] < 0 || coordinates[2] < 0)
            {
                return false;
            }
            else if ((coordinates[1] >= 10 && coordinates[1] <= 40) && ((coordinates[0] >= 10 && coordinates[0] <= 40) && (coordinates[2] >= 10 && coordinates[2] <= 40)))
            {
                return false;
            }
            else if ((coordinates[0] >= 10 && coordinates[0] <= 40) && ((coordinates[1] >= 10 && coordinates[1] <= 40) && (coordinates[2] >= 10 && coordinates[2] <= 40)))
            {
                return false;
            }
            else if ((coordinates[2] >= 10 && coordinates[2] <= 40) && ((coordinates[1] >= 10 && coordinates[1] <= 40) && (coordinates[0] >= 10 && coordinates[0] <= 40)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Helpers
        public string GetFormatedCoordinates()
        {
            if (ValidateDroneCoordinates(coordinates))
            {
                return "Drone position: (" + coordinates[0] + ","
                        + coordinates[1] + ","
                        + coordinates[2] + ")";
            }
            else
            {
                return "Drone is not in a valid position.";
            }
        }
    }
}
