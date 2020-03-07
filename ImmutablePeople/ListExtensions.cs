using System;
using System.Collections.Generic;
using System.Text;

namespace ImmutablePeople
{
    public static class ListExtensions
    {
        public static void PrintAll(this List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine(person + " has password \"" + person.Password + "\"");
            }
        }
        public static void WithPasswordResetByFirstName(this List<Person> people, string firstName, string newPassword)
        {
            var updated = new List<Person>();
            foreach (var person in people)
            {
                if (person.FirstName == firstName)
                {
                    person.
                }
            }
        }
    }
}
