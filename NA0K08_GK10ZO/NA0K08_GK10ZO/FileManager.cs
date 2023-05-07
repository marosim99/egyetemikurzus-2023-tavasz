﻿using NA0K08_GK10ZO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA0K08_GK10ZO
{
    internal class FileManager
    {
        public static List<RaceResult> GetRaceDataFromCsv(string path)
        {
            var races = new List<RaceResult>();

            using (var reader = new StreamReader(path))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    string country = values[0];
                    int position = values[1] == "NC" ? 0 : Convert.ToInt32(values[1]);
                    int driverNumber = Convert.ToInt32(values[2]);
                    string driverName = values[3];
                    string teamName = values[4];
                    string startedFromPosition = values[5];
                    string numberOfLaps = values[6];
                    int points = Convert.ToInt32(values[8]);
                    bool gotFastestLap = values[9] == "Yes" ? true : false;
                    string fastestLap = values[10];

                    var race = new RaceResult(country, position, driverNumber, driverName, teamName,
                        startedFromPosition, numberOfLaps, points, gotFastestLap, fastestLap);

                    races.Add(race);
                }
            }

            return races;
        }
    }
}