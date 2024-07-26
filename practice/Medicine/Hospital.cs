namespace Medicine
{
    namespace Medicine
    {
        public class Hospital
        {
            private List<Doctor> doctors = new List<Doctor>();
            private List<Appointment> appointments = new List<Appointment>();

            public void AddDoctor(string name)
            {
                doctors.Add(new Doctor(name));
                Message.SuccessMessage("added", $"Doctor {name}");
            }

            public void ViewAllDoctors()
            {
                Console.WriteLine("List of doctors:");
                foreach (var doctor in doctors)
                {
                    Console.WriteLine(doctor.Name);
                }
            }

            public void ScheduleAppointment(string doctorName, string patientName, DateTime date)
            {
                Doctor doctor = doctors.FirstOrDefault(d => d.Name == doctorName);

                if (doctor == null)
                {
                    Message.NotFoundMessage("Doctor");
                    return;
                }

                bool isSucceeded = !doctor.Appointments.Any(a => date >= a.Date && date < a.Date.AddHours(1));

                if (isSucceeded)
                {
                    doctor.Appointments.Add(new Appointment(patientName, date));
                    Message.AvailableSlotMessage(patientName, doctorName, date);
                }
                else
                {
                    Message.TimeOccupiedMessage();
                }
            }

            public void ViewAppointmentsOfDoctor(string doctorName)
            {
                Doctor doctor = doctors.FirstOrDefault(d => d.Name == doctorName);

                if (doctor == null)
                {
                    Message.NotFoundMessage("Doctor");
                    return;
                }

                Console.WriteLine($"Appointments for Doctor {doctorName}:");
                foreach (var appointment in doctor.Appointments)
                {
                    Console.WriteLine($"- {appointment.Date}");
                }
            }
        }
    }
}
