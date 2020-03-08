using System;
using System.Collections.Generic;
using System.Text;

namespace ImmutablePeople
{
    public abstract class Person
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Password {get; set;}
        public abstract Person WithName(string fullName);
        public abstract Person WithPassword(string passwd);
    }
    public abstract class Person<T> : Person where T: Person<T>
    {
        public abstract T WithName<T>(string fullName);
        public abstract T WithPassword<T>(string passwd);
        public override sealed Person WithName(string fullName)
        {
            return WithName<T>(fullName);
        }
        public override sealed Person WithPassword(string passwd)
        {
            return WithPassword<T>(passwd);
        }
    }

    public class Student : Person<Student>
    {
        public Student(string firstName, string lastName, string password, DateTime dateEnrolled)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.DateEnrolled = dateEnrolled;
        }
        public DateTime DateEnrolled { get; private set;}
        public static Student Default => new Student("", "", "", DateTime.Now);
        public Student WithDateEnrolled(DateTime dateEnrolled)
        {
            this.DateEnrolled = dateEnrolled;
            return this;
        }

        public override Person WithName<T>(string fullName) 
        {
            string[] nameParts = fullName.Split(' ');
            return new Student(nameParts[0], nameParts[1], this.Password, this.DateEnrolled);
        }

        public override Person WithPassword<T>(string passwd)
        {
            return new Student(this.FirstName, this.LastName, passwd, this.DateEnrolled);
        }
        public override string ToString()
        {
            return "Student " + FirstName + " " + LastName;
        }
    }
    public class Teacher : Person<Teacher>
    {
        public Teacher(string firstName, string lastName, string password, int courses)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Courses = courses;
        }
        public int Courses { get; private set;}
        public static Teacher Default => new Teacher("","","",0);
        public Teacher WithCoursesHeld(int coursesAmount)
        {
            return new Teacher(this.FirstName, this.LastName, this.Password, coursesAmount);
        }
        public override string ToString()
        {
            return "Teacher " + FirstName + " " + LastName;
        }

        public override Person WithName<T>(string fullName)
        {
            string[] nameParts = fullName.Split(' ');
            return new Teacher(nameParts[0], nameParts[1], this.Password, this.Courses);
        }

        public override Person WithPassword<T>(string passwd)
        {
            return new Teacher(this.FirstName, this.LastName, passwd, this.Courses);
        }
    }
}
