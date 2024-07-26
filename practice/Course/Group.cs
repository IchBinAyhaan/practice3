﻿
namespace Course
{
    public  class Group
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Limit { get; set; }
        public List<Student> Students { get; }

        public Group(int id, string name, int limit)
        {
            Id = id;
            Name = name;
            Limit = limit;
            Students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            if (Students.Count < Limit)
            {
                Students.Add(student);
                Console.WriteLine($"Student {student.Name} added to group {Name}");
            }
            else
            {
                Console.WriteLine($"Group {Name} is full. Cannot add more students.");
            }
        }

        public void RemoveStudent(int studentId)
        {
            Student studentToRemove = null;
            foreach (Student student in Students)
            {
                if (student.Id == studentId)
                {
                    studentToRemove = student;
                    break; 
                }
            }
            if (studentToRemove is not null)
            {
                Students.Remove(studentToRemove);
                Console.WriteLine($"Student {studentToRemove.Name} removed from group {Name}");
            }
            else
            {
                Console.WriteLine($"Student with ID {studentId} not found in group {Name}");
            }
        }

        public void DisplayStudents()
        {
            Console.WriteLine($"Students in group {Name}:");
            foreach (var student in Students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
            }
        }
    }
}
