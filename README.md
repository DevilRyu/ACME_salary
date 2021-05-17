# ACME SALARY APP
## Overview
This program is designed to calculate the salary to be paid to an employee of the ACME company in a week, the company offers flexible working hours that are the following: 
 ```
Monday - Friday

00:00 - 09:00 25 USD

09:01 - 18:00 15 USD

18:01 - 23:59 20 USD

Saturday and Sunday

00:00 - 09:00 30 USD

09:01 - 18:00 20 USD

18:01 - 23:59 25 USD
  ```
And the days are abbreviated as follows: 
```
MO: Monday

TU: Tuesday

WE: Wednesday

TH: Thursday

FR: Friday

SA: Saturday

SU: Sunday
```
For greater ease and scalability of the program, the schedules were modeled in the **schedule.json** file.

The program inputs have a specific format and are located in the file called **employee.txt**, the format is as follows: 
```
RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00
```
And the expected output is the following:
```
The amount to pay RENE is: 215 USD
```
## Architecture

The architecture consists of a console program which reads a file of type json and another of type .txt and displays the results by console. 

## Methodology
The methodology with which the program was designed is as follows:
1) The program reads the company calendars from the schedule.json file and deserializes them to objects modeled by the Day.cs and Schedule.cs files
2) I continued to read the employee.txt file to know the employee and the hours they work (in one line)
3) The name of the employee and the hours in which he works are extracted from each line.
4) After each schedule, the day and time in which he starts and ends work on that day is obtained
5) Immediately after, check in which time slot this is and it is added to the total cost that must be paid in the week.
6) The name of the employee and the weekly salary are displayed on the console.

## Run instructions
To run the program once cloned from git, the following command must be executed: 
* dotnet run
  