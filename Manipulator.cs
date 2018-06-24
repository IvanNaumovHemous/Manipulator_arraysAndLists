using System;
using System.Collections.Generic;
using System.Linq;

namespace Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            numbers = GetExecutedCommands(numbers);
            PrintAllNumbersInList(numbers);
        }

        static List<int> GetExecutedCommands(List<int> numbers)
        {
            string input = Console.ReadLine();
            while (true)
            {
                if (input.Equals("print"))
                {
                    return numbers;
                }

                string[] command = input.Split(' ').ToArray();
                string typeOfAction = command[0];

                switch (typeOfAction)
                {
                    case "add":
                        int index = int.Parse(command[1]), element = int.Parse(command[2]);
                        numbers = GetAddedElement(numbers, index, element); break;

                    case "addMany":
                        numbers = GetManyAddedElements(numbers, command); break;

                    case "contains":
                        element = int.Parse(command[1]);
                        ContainsElement(numbers, element); break;

                    case "remove":
                        index = int.Parse(command[1]);
                        numbers = GetRemovedIndexList(numbers, index); break;

                    case "shift":
                        int positions = int.Parse(command[1]);
                        numbers = GetShiftedList(numbers, positions); break;

                    case "sumPairs":
                        numbers = GetSummedListByPairs(numbers);
                        break;
                }

                input = Console.ReadLine();
            }
        }

        static List<int> GetAddedElement(List<int> numbers, int index, int element)
        {
            numbers.Insert(index, element);
            return numbers;
        }

        static List<int> GetManyAddedElements(List<int> numbers, string[] command)
        {
            List<int> numbersToBeAdded = new List<int>();
            int index = int.Parse(command[1]);

            for (int i = 2; i < command.Length; i++)
            {
                numbersToBeAdded.Add(int.Parse(command[i]));
            }

            numbers.InsertRange(index, numbersToBeAdded);
            return numbers;
        }

        static void ContainsElement(List<int> numbers, int element)
        {
            int counter = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i].Equals(element))
                {
                    Console.WriteLine(i);
                    counter++;
                    break;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine(-1);
            }
        }

        static List<int> GetRemovedIndexList(List<int> numbers, int index)
        {
            numbers.RemoveAt(index);
            return numbers;
        }     

        static List<int> GetShiftedList(List<int> numbers, int positions)
        {
            while (positions > 0)
            {
                int firstElement = numbers[0];
                numbers.RemoveAt(0);
                numbers.Add(firstElement);
                positions--;
            }

            return numbers;
        }

        static List<int> GetSummedListByPairs(List<int> numbers)
        {
            List<int> summedNumbers = new List<int>();
            if (numbers.Count % 2 != 0)
            {
                numbers.Add(0);
            }
            for (int i = 0; i < numbers.Count; i += 2)
            {
                summedNumbers.Add(numbers[i] + numbers[i + 1]);
            }

            return summedNumbers;
        }

        static void PrintAllNumbersInList(List<int> numbers)
        {
            Console.Write("[");
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                Console.Write($"{numbers[i]}, ");
            }
            Console.WriteLine($"{numbers[numbers.Count - 1]}]");
        }
    }
}
