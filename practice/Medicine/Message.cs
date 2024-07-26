using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine
{
    public class Message
    {
        public static void SuccessMessage(string item, string operation) => Console.WriteLine($"{item} başarıyla {operation}.");
        public static void NotFoundMessage(string item) => Console.WriteLine($"{item} not found.");
        public static void TimeOccupiedMessage() => Console.WriteLine("Another appointment is already scheduled for this time period.");
        public static void AvailableSlotMessage(string patientName, string doctorName, DateTime date) => Console.WriteLine($"Appointment scheduled for {patientName} with {doctorName} on {date}.");
        public static void InputMessage(string action, string item) => Console.WriteLine($"Please {action} {item}.");
    }
}
