using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP_MappingRobot
{
    public class Robot
    {

        public DateTime DestinationDate;
        public string DestinationName;
        public string[] DestinationPath;
        public char direction;
        public int west, north, east, south;
        private string FinalPath;

        public Robot(DateTime date, string name, string[] path)
        {
            DestinationDate = date;
            DestinationName = name;
            DestinationPath = path;
            direction = 'W';
        }
        
        public void FindFastestPath()
        {
            char[] stepPath;
            foreach(string step in DestinationPath)
            {
                stepPath = step.ToCharArray();
                if(direction.Equals('W'))
                {
                    if(stepPath[0].Equals('L'))
                    {
                        direction = 'S';
                        south += (int)Char.GetNumericValue(stepPath[1]);
                    }
                    else
                    {
                        direction = 'N';
                        north += (int)Char.GetNumericValue(stepPath[1]);
                    }
                }
                else if(direction.Equals('N'))
                {
                    if (stepPath[0].Equals('L'))
                    {
                        direction = 'W';
                        west += (int)Char.GetNumericValue(stepPath[1]);
                    }
                    else
                    {
                        direction = 'E';
                        east += (int)Char.GetNumericValue(stepPath[1]);
                    }
                }
                else if (direction.Equals('E'))
                {
                    if (stepPath[0].Equals('L'))
                    {
                        direction = 'N';
                        north += (int)Char.GetNumericValue(stepPath[1]);
                    }
                    else
                    {
                        direction = 'S';
                        south += (int)Char.GetNumericValue(stepPath[1]);
                    }
                }
                else if (direction.Equals('S'))
                {
                    if (stepPath[0].Equals('L'))
                    {
                        direction = 'E';
                        east += (int)Char.GetNumericValue(stepPath[1]);
                    }
                    else
                    {
                        direction = 'W';
                        west += (int)Char.GetNumericValue(stepPath[1]);
                    }
                }
            }

            if(north > south)
            {
                FinalPath += 'R';
                FinalPath += (north - south);
            }
            else
            {
                FinalPath += 'L';
                FinalPath += (south - north);
                FinalPath += " ";
            }
            if(east > west)
            {
                FinalPath += 'R';
                FinalPath += (east - west);
            }
            else
            {
                FinalPath += 'L';
                FinalPath += (west - east);
                FinalPath += " ";
            }

            Console.WriteLine(FinalPath);
            Console.ReadLine();

        }
    }
}
