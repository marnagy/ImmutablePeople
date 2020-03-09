using System;
using System.Collections.Generic;
using System.Text;

namespace ImmutablePeople
{
    public abstract class Person
    {
        public string FirstName {get; protected set;}
        public string LastName {get; protected set;}
        public string Password {get; protected set;}
        public abstract Person WithNameP(string fullName);
        public abstract Person WithPasswordP(string passwd);
    }
    public abstract class Person<T> : Person where T: Person<T>
    {
        public abstract T WithName(string fullName);
        public abstract T WithPassword(string passwd);
        public override sealed Person WithNameP(string fullName)
        {
            return WithName(fullName);
        }
        public override sealed Person WithPasswordP(string passwd)
        {
            return WithPassword(passwd);
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
        public DateTime DateEnrolled { get;}
        public static Student Default => new Student("", "", "", DateTime.Today);
        public Student WithDateEnrolled(DateTime dateEnrolled)
        {
            return new Student(this.FirstName, this.LastName, this.Password, dateEnrolled);
        }

        public override Student WithName(string fullName) 
        {
            string[] nameParts = fullName.Split(' ');
            if (nameParts.Length != 2) throw new ArgumentException("Invalid name format.");
            return new Student(nameParts[0], nameParts[1], this.Password, this.DateEnrolled);
        }
        public override Student WithPassword(string passwd)
        {
            return new Student(this.FirstName, this.LastName, passwd, this.DateEnrolled);
        }
        public override string ToString()
        {
            return "Student " + FirstName + " " + LastName;
        }
        public override bool Equals(object obj)
        {
            bool res = false;
            Student s = obj as Student;
            if ( s != null){
                if (this.FirstName == s.FirstName &&
                    this.LastName == s.LastName &&
                    this.Password == s.Password &&
                    this.DateEnrolled == s.DateEnrolled)
                {
                    res = true;
                }
            }
            return res;
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

        public override Teacher WithName(string fullName)
        {
            string[] nameParts = fullName.Split(' ');
            return new Teacher(nameParts[0], nameParts[1], this.Password, this.Courses);
        }

        public override Teacher WithPassword(string passwd)
        {
            return new Teacher(this.FirstName, this.LastName, passwd, this.Courses);
        }
        public override string ToString()
        {
            return "Teacher " + FirstName + " " + LastName;
        }
        public override bool Equals(object obj)
        {
            bool res = false;
            Teacher t = obj as Teacher;
            if ( t != null){
                if (this.FirstName == t.FirstName &&
                    this.LastName == t.LastName &&
                    this.Password == t.Password &&
                    this.Courses == t.Courses)
                {
                    res = true;
                }
            }
            return res;
        }
    }
}
