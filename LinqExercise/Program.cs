using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine($"Sum of numbers: {numbers.Sum()}");

            //TODO: Print the Average of numbers
            Console.WriteLine($"Average of numbers: {numbers.Average()}");

            //TODO: Order numbers in ascending order and print to the console
            var ascendingOrder = numbers.OrderBy(item => item);

            Console.WriteLine("Ascending Order:");
            foreach (var num in ascendingOrder) 
            {
                Console.WriteLine($"{num}");
            }

            //TODO: Order numbers in decsending order and print to the console
            Console.WriteLine("Descending Order:");
            numbers.OrderByDescending(item => item).ToList().ForEach(Console.WriteLine);


            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("Greater than 6:");
            numbers.Where(x => x > 6).ToList().ForEach(Console.WriteLine);

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var onlyFour = numbers.OrderBy(num => num).Take(4);

            Console.WriteLine("Take only 4:");
            foreach (var num in onlyFour)
            {
                Console.WriteLine(num);
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            //numbers[4] = 20;
            numbers.SetValue(20, 4);

            Console.WriteLine("Change 4 to Age:");
            numbers.ToList().ForEach(Console.WriteLine);

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var onlyCAndS = employees.Where(person => person.FirstName.ToLower().StartsWith('c')
            || person.FirstName.ToLower()[0] == 's').OrderBy(name => name.FirstName);

            Console.WriteLine("C || S:");
            onlyCAndS.ToList().ForEach(x => Console.WriteLine(x.FirstName));
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var over26 = employees.Where(person => person.Age > 26).OrderBy(person => person.Age).ThenBy(person => person.FirstName);

            Console.WriteLine("Over 26 years old:");
            foreach(var person in over26)
            {
                Console.WriteLine($"Name: {person.FullName} Age: {person.Age}");
            }

            Console.WriteLine();

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var sumOfExperience = employees.Where(person => person.YearsOfExperience <= 10 && person.Age > 35);

            Console.WriteLine($"Total Years of Experience: {sumOfExperience.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Average Years of Experience: {sumOfExperience.Average(x => x.YearsOfExperience)}");
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Jake", "Johnston", 20, 1)).ToList();

            foreach(var emp in employees)
            {
                Console.WriteLine(emp.FullName);
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
