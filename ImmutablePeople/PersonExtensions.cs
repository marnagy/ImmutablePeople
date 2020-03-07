using System;
using System.Collections.Generic;
using System.Text;

namespace ImmutablePeople
{
    public static class PersonExtensions
    {
        public static T WithFirstName<T>(this T p, string firstName) where T: Person
        {
            T ret = p;
            ret.FirstName = firstName;
            return ret;
        }
        public static T WithLastName<T>(this T p, string lastName) where T: Person
        {
            T ret = p;
            ret.LastName = lastName;
            return ret;
        }
        public static T WithName<T>(this T p, string fullName) where T: Person
        {
            T ret = p;
            string[] nameParts = fullName.Split(' ');
            return p.WithFirstName<T>(nameParts[0]).WithLastName<T>(nameParts[1]);
        }
        public static T WithPassword<T>(this T p, string passwd) where T : Person
        {
            T ret = p;
            ret.Password = passwd;
            return ret;
        }
    }
}
