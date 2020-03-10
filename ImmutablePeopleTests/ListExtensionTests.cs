using System;
using System.Collections.Generic;
using ImmutablePeople;
using Xunit;

namespace ImmutablePeopleTests
{
    public class ListExtensionTests
    {
        //unable to test PrintAll
        [Fact]
        public void WithPasswordResetByFirstNameTest1()
        {
            //Arrange
            List<Person> list = new List<Person>();
            list.Add(Student.Default.WithName("Marek Nagy").WithPassword("great_passwd") );
            list.Add(Teacher.Default.WithName("Peter Nagy").WithPassword("good_passwd") );

            //Act
            var updated = list.WithPasswordResetByFirstName(firstName: "Marek", newPassword: "super_Password");

            //Assert
            Assert.Equal("super_Password", updated[0].Password);
            Assert.Equal("good_passwd", updated[1].Password);
            
        }
    }
}
