using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2023_Task3_DroneSimulator
{
    public interface IDrone
    {
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void MoveBack();
        void MoveForth();
        string GetFormatedCoordinates();
    }
}
