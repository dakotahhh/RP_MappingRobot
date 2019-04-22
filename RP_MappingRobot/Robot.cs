using System;

namespace RP_MappingRobot
{
    /// <summary>
    /// The Robot Class.
    /// This class creates a robot that contains the method to finding the most optimal route for a destination.
    /// </summary>
    public class Robot
    {
        /// <summary>
        /// None of these properties need to be public as they are only referred to in this class.
        /// </summary>
        private DateTime _destinationDate;
        private string _destinationName;
        private string[] _destinationPath;
        private int _west, _north, _east, _south = 0;

        /// <summary>
        /// Creates a Robot with properties passed from the user input.
        /// </summary>
        /// <param name="date">the converted date</param>
        /// <param name="name">the name of the location we are traveling to</param>
        /// <param name="path">the path taken</param>
        public Robot(DateTime date, string name, string[] path)
        {
            _destinationDate = date;
            _destinationName = name;
            _destinationPath = path;
        }

        /// <summary>
        /// We will traverse through each step of the instructed path and determine where to go based off of each step
        /// We will split up each step so that we can determine how many blocks we have traveled in each direction. 
        /// We will then call  _DetermineFastestPath() to return the fastest path we can take to our destination.
        /// </summary>
        /// <returns>Returns the date, location, and fastest path for the user submitted instructions.</returns>
        public string BuildPath()
        {
            char direction = 'W';
            foreach(string step in _destinationPath)
            {
                switch(direction)
                {
                    case 'W':
                        if (step.StartsWith("L"))
                        {
                            direction = 'S';
                            _south += Convert.ToInt32(step.Substring(1));
                        }
                        else
                        {
                            direction = 'N';
                            _north += Convert.ToInt32(step.Substring(1));
                        }
                        break;
                    case 'N':
                        if (step.StartsWith("L"))
                        {
                            direction = 'W';
                            _west += Convert.ToInt32(step.Substring(1));
                        }
                        else
                        {
                            direction = 'E';
                            _east += Convert.ToInt32(step.Substring(1));
                        }
                        break;
                    case 'E':
                        if (step.StartsWith("L"))
                        {
                            direction = 'N';
                            _north += Convert.ToInt32(step.Substring(1));
                        }
                        else
                        {
                            direction = 'S';
                            _south += Convert.ToInt32(step.Substring(1));
                        }
                        break;
                    case 'S':
                        if (step.StartsWith("L"))
                        {
                            direction = 'E';
                            _east += Convert.ToInt32(step.Substring(1));
                        }
                        else
                        {
                            direction = 'W';
                            _west += Convert.ToInt32(step.Substring(1));
                        }
                        break;
                    default:
                        break;
                }
            }

            return _destinationDate.ToString("yyyy-MM-dd") + "; " + _destinationName + "; " + _DetermineFastestPath();

        }

        /// <summary>
        /// Logic to determine the final path is as follows:
        /// Essentially North and East are always going to be Right values while South and West are always going to be Left values
        /// If the amount of steps we have taken North is greater than we have taken South, then we know that going North is the fastest way to get to a location and vice versa
        /// We will subtract the number of steps we have taken south from the amount of steps we have taken from north to get the shortest amount of steps there and vice versa.
        /// The same rules apply for East and West.
        /// If North and South are the same value, we will default to North so long as we can turn left and right.
        /// </summary>
        /// <returns>The most optimal route to reach our destination</returns>
        private string _DetermineFastestPath()
        {
            string finalPath = "";

            if (_north >= _south)
                finalPath += "R" + (_north - _south);
            else
                finalPath += "L" + (_south - _north);
            finalPath += ", ";
            
            if (_east >= _west)
            {
                if(_east != _west)
                    finalPath += "R" + (_east - _west);
            }
            else
                finalPath += "L" + (_west - _east);

            return finalPath;
        }
    }
}
