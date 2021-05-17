using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace EmployeePay
{
    class Program
    {
        private static int dayLength = 2;
        private static double total = 0;
        private static string employeeName = "";
        private static List<Day> days;
        static void Main(string[] args)
        {

            //Read the schedule.json file and deserialize in object 
            readScheduleACM();

            //Read the employee.txt file
            string[] lines = readEmployees();

            //Analize every employee
            analizeEmployees(lines);

        }

        private static void readScheduleACM()
        {
            using (StreamReader r = new StreamReader("schedule.json"))
            {
                string json = r.ReadToEnd();
                days = JsonConvert.DeserializeObject<List<Day>>(json);
            }
        }
        private static string[] readEmployees()
        {
            string[] lines = System.IO.File.ReadAllLines("employee.txt");
            return lines;
        }

        private static void analizeEmployees(string[] lines)
        {
            //Iterate over every employee
            foreach (string line in lines)
            {
                //Extract the name of the Employee and the hours the employee works 
                string[] subarray = line.Split('=');
                employeeName = subarray[0];
                string[] schedules = subarray[1].Split(',');

                //Analize every schedule of the employee
                extractSchedules(schedules);

                Console.WriteLine("The amount to pay "+employeeName+" is: "+total+" USD");
                cleanEmployeeInfo();
            }
        }

        private static void extractSchedules(string[] schedules)
        {
            foreach (string schedule in schedules)
            {
                string dayName = schedule.Substring(0, dayLength);
                string stripe = schedule.Substring(dayLength, schedule.Length - dayLength);
                DateTime begin = DateTime.Parse(stripe.Split('-')[0]);
                DateTime end = DateTime.Parse(stripe.Split('-')[1]);

                //Analize de cost that have to add to the total for every day
                analizeCost(days, dayName, begin, end);
            }
        }

        private static void analizeCost(List<Day> days, string dayName, DateTime begin, DateTime end)
        {
            foreach (Day day in days)
            {
                if (dayName.Equals(day.name))
                {
                    foreach (Schedule sch in day.schedule)
                    {

                        if (sch.begin.CompareTo(begin) <= 0 && sch.begin.CompareTo(end) < 0 && sch.end.CompareTo(end) >= 0)
                        {
                            TimeSpan difference = end.Subtract(begin);
                            total = total + (difference.Hours * sch.costHour);
                            break;
                        }
                    }
                }
            }
        }

        private static void cleanEmployeeInfo()
        {
            total = 0;
            employeeName = "";
        }

    }
}
