﻿
namespace Course
{
    public class Student
    {
        public  int id { get; set; } = 1;
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Grade { get; set; }

        public Student(string name, string surname, int age, string grade)
        {
            Id = id++;
            Name = name;
            Surname = surname;
            Age = age;
            Grade = grade;
        }
    }
}
