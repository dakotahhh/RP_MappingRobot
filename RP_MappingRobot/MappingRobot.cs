using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP_MappingRobot
{
    public class MappingRobot
    {

        public MappingRobot()
        {

        }

        static void Main(string[] args)
        {
            MappingRobot mappingRobot = new MappingRobot();

            Console.WriteLine("Welcome to Mapping Robot. Please enter a destination as follows: YYYY-MM-DD; Destination Name; Destination Path ." +
                "\n For Example: 2017-01-01; Coffee Shop; L2, L5, L5, R5, L2 ");
            string destinationInput = Console.ReadLine();
            string[] destinationValues = destinationInput.Split(';');
            if (destinationValues.Length != 3)
            {
                Console.WriteLine("Invalid destination. Please check your submission and reenter your destination.");
                Console.ReadLine();
            }
            else
            {
                mappingRobot.ConvertPath(destinationValues);
            }

        }

        public void ConvertPath(string[] destinationValues)
        {
            DateTime destinationDate = Convert.ToDateTime(destinationValues[0]);
            string destinationName = destinationValues[1];
            string[] destinationPath = destinationValues[2].Replace(" ", "").Split(',');
            foreach(string s in destinationPath)
            {
                if(!s.StartsWith("L") && !s.StartsWith("R"))
                {
                    Console.WriteLine("Invalid Destination Path");
                    Console.ReadLine();
                }
            }
            Robot robot = new Robot(destinationDate, destinationName, destinationPath);
            robot.FindFastestPath();
        }

    }
}
