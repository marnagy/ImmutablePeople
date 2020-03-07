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
        //protected T WithFirstName<T>(string firstName) where T: Person
        //{
        //    this.FirstName = firstName;
        //    return (T) this;
        //}
        //protected T WithLastName<T>(string lastName) where T: Person
        //{
        //    this.LastName = lastName;
        //    return (T) this;
        //}
        //public T WithName<T>(string fullName) where T: Person
        //{
        //    string[] nameParts = fullName.Split(' ');
        //    return this.WithFirstName<T>(nameParts[0]).WithLastName<T>(nameParts[1]);
        //}
        //public T WithPassword<T>(string passwd) where T: Person
        //{
        //    this.Password = passwd;
        //    return (T) this;
        //}
    }
    public abstract class Person<T> : Person where T: Person<T>, new()
    {
        
    }

    public class Student : Person<Student>
    {
        public DateTime DateEnrolled { get; private set;}
        public static Student Default => new Student();
        public Student WithDateEnrolled(DateTime dateEnrolled)
        {
            this.DateEnrolled = dateEnrolled;
            return this;
        }
        public override string ToString()
        {
            return "Student " + FirstName + " " + LastName;
        }
    }
    public class Teacher : Person<Teacher>
    {
        public int Coureses { get; private set;}
        public static Teacher Default => new Teacher();
        public Teacher WithCoursesHeld(int coursesAmount)
        {
            this.Coureses = coursesAmount;
            return this;
        }
        public override string ToString()
        {
            return "Teacher " + FirstName + " " + LastName;
        }
    }
}
