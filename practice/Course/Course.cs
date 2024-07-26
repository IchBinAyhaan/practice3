
namespace Course
{

    public  class Course
    {
        public  List<Group> groups = new List<Group>();

        public  void AddGroup(Group group)
        {
            if (groups.Any(g => g.Name == group.Name))
            {
                Message.AlreadyExistMessage($"Group with name {group.Name}");
            }
            else
            {
                groups.Add(group);
                Message.SuccessMessage($"Group {group.Name}", "added to the course");
            }
        }

        public  void DisplayGroups()
        {
            Console.WriteLine("Groups in the course:");
            foreach (var group in groups)
            {
                Console.WriteLine($"Group ID: {group.Id}, Name: {group.Name}, Limit: {group.Limit}");
            }
        }

        public  void DisplayStudentsInAllGroups()
        {
            foreach (var group in groups)
            {
                group.DisplayStudents();
            }
        }

        public  void AddStudentToGroup(string groupName, Student student)
        {
            Group foundGroup = groups.FirstOrDefault(g => g.Name == groupName);
            if (foundGroup is not null)
            {
                foundGroup.AddStudent(student);
                Message.SuccessMessage($"Student {student.Name} added to group {groupName}", "added");
            }
            else
            {
                Message.NotFoundMessage($"Group {groupName}");
            }
        }

        public  void RemoveStudentFromGroup(string groupName, int studentId)
        {
            Group group = groups.FirstOrDefault(g => g.Name == groupName);
            if (group is not null)
            {
                group.RemoveStudent(studentId);
                Message.SuccessMessage($"Student with ID {studentId} removed from group {groupName}", "removed");
            }
            else
            {
                Message.NotFoundMessage($"Group {groupName}");
            }
        }

        public  void EditStudentInGroup(string groupName, int studentId)
        {
            Group foundGroup = groups.FirstOrDefault(g => g.Name == groupName);
            if (foundGroup is not null)
            {
                Student foundStudent = foundGroup.Students.FirstOrDefault(s => s.Id == studentId);
                if (foundStudent is not null)
                {
                    Console.WriteLine("Enter new details for the student:");
                    Console.Write("Name: ");
                    foundStudent.Name = Console.ReadLine();
                    Console.Write("Surname: ");
                    foundStudent.Surname = Console.ReadLine();
                    Console.Write("Age: ");
                    foundStudent.Age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Grade: ");
                    foundStudent.Grade = Console.ReadLine();
                    Message.SuccessMessage($"Student with ID {studentId} in group {groupName}", "updated");
                }
                else
                {
                    Message.NotFoundMessage($"Student with ID {studentId} in group {groupName}");
                }
            }
            else
            {
                Message.NotFoundMessage($"Group {groupName}");
            }
        }

        public  void SearchStudents(string searchTerm)
        {
            Message.InputMessage($"Search results for '{searchTerm}'");
            foreach (var group in groups)
            {
                foreach (var student in group.Students)
                {
                    if (student.Name.Contains(searchTerm))
                    {
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Group: {group.Name}");
                    }
                }
            }
        }

        public  void RemoveStudentById(int studentId)
        {
            foreach (var group in groups)
            {
                Student student = group.Students.FirstOrDefault(s => s.Id == studentId);
                if (student is not null)
                {
                    group.Students.Remove(student);
                    Message.SuccessMessage($"Student with ID {studentId}", "removed from group");
                    return;
                }
            }
            Message.NotFoundMessage($"Student with ID {studentId} in any group");
        }

        public  void DisplayStudentsInGroup(string groupName)
        {
            Group group = groups.FirstOrDefault(g => g.Name == groupName);
            if (group is not null)
            {
                group.DisplayStudents();
            }
            else
            {
                Message.NotFoundMessage($"Group {groupName}");
            }
        }
    }
}
