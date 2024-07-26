using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public  class Message
    {
        public static void InvalidInputMessages(string title) => Console.WriteLine($"{title} is invalid. Please try again.");
        public static void InputMessage(string title) => Console.WriteLine($"Please input {title}.");
        public static void SuccessMessage(string title, string operation) => Console.WriteLine($"{title} successfully {operation}.");
        public static void ErrorOccuredMessage() => Console.WriteLine("Error occurred. Please try again.");
        public static void NotFoundMessage(string title) => Console.WriteLine($"{title} not found.");
        public static void WantToChangeMessage(string title) => Console.WriteLine($"Do you want to change {title}? (y or n)");
        public static void AlreadyExistMessage(string title) => Console.WriteLine($"{title} already exists, please try another one.");
        public static void WarningMessage(string title) => Console.WriteLine($"There is no any {title}. Add {title} first please.");
        public static void LimitMessage(string title, int count) => Console.WriteLine($"The {title} cannot be less than the current number of students {count}. Please try again.");
    }
}
