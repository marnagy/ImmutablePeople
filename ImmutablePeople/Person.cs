using System;
using System.Collections.Generic;
using System.Text;

namespace ImmutablePeople
{
    public abstract class PersonG<T> where T:PersonG<T>
    {
        public string FirstName {get; private set;}
        public string LastName {get; private set;}
        public string Password {get; private set;}
        protected T WithFirstName(string firstName)
        {
            this.FirstName = firstName;
            return (T) this;
        }
        protected T WithLastName(string lastName)
        {
            this.LastName = lastName;
            return (T) this;
        }
        public T WithName(string fullName)
        {
            string[] nameParts = fullName.Split(' ');
            return this.WithFirstName(nameParts[0]).WithLastName(nameParts[1]);
        }
        public T WithPassword(string passwd)
        {
            this.Password = passwd;
            return (T) this;
        }
    }
    public abstract class Person : PersonG<Person>
    {

    }
    public class Student : PersonG<Student>
    {
        public static Student Default => new Student();
        public Student WithDateEnrolled(DateTime dateEnrolled)
        {
            
        }
    }
    public class Teacher : PersonG<Teacher>
    {
        public static Teacher Default => new Teacher();
        public Teacher WithCoursesHeld(int coursesAmount)
        {
            
        }
    }
}
