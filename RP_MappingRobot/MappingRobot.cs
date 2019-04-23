using System;
using System.Globalization;

namespace RP_MappingRobot
{
    public class MappingRobot
    {

        //empty constructor
        public MappingRobot()
        {

        }

        //starting up the project
        public static void Main(string[] args)
        {
            MappingRobot mappingRobot = new MappingRobot();
            Console.WriteLine("Welcome to Mapping Robot. \n");
            mappingRobot.ReadDestinationInput();
            Console.WriteLine("Would you like to continue? Y or N");
            if (Console.ReadLine().Equals("Y"))
                mappingRobot.ReadDestinationInput();
        }

        /// <summary>
        /// ReadDestinationInput reads the destination information the user inputs into the project.
        /// It will split the info on a semicolon and if the array produced isn't of length, then there is some portion of
        /// information missing. If the submitted information seems fine, move onto converting the input into valid Robot information
        /// </summary>
        private void ReadDestinationInput()
        {
            Console.WriteLine("Please enter a destination as follows: YYYY-MM-DD; Destination Name; Destination Path ." +
                "\n For Example: 2017-01-01; Coffee Shop; L2, L5, L5, R5, L2 \n");
            string destinationInput = Console.ReadLine();
            string[] destinationValues = destinationInput.Split(';');
            if (destinationValues.Length != 3)
            {
                Console.WriteLine("Invalid destination. Please check your submission and reenter your destination. \n");
                ReadDestinationInput();
            }
            else
            {
                ConvertInput(destinationValues);
            }
        }

        /// <summary>
        /// ConvertInput converts the user submitted information into valid variables that can be used by the Robot class.
        /// DestinationDate must be a DateTime value.
        /// DestinationName can contain any characters.
        /// DestinationPath must exist and each direction must start with L or R.
        /// </summary>
        /// <param name="destinationValues">The input submitted by the user.</param>
        private void ConvertInput(string[] destinationValues)
        {
            DateTime destinationDate;
            if(!DateTime.TryParseExact(destinationValues[0], "yyyy-MM-dd", new CultureInfo("en-US"),
                              DateTimeStyles.None,
                              out destinationDate))
            {
                Console.WriteLine("Invalid Destination Date. Please check your submission and reenter your destination. \n");
                ReadDestinationInput();
            }
            string destinationName = destinationValues[1].Trim();
            string[] destinationPath = destinationValues[2].Replace(" ", "").Split(',');
            foreach(string s in destinationPath)
            {
                if(!s.StartsWith("L") && !s.StartsWith("R"))
                {
                    Console.WriteLine("Invalid Destination Path. Please check your submission and reenter your destination. \n");
                    ReadDestinationInput();
                }
            }
            Robot robot = new Robot(destinationDate, destinationName, destinationPath);
            Console.WriteLine(robot.BuildPath());
            Console.ReadLine();
        }

    }
}
