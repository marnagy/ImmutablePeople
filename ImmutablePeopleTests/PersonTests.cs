using System;
using ImmutablePeople;
using Xunit;

namespace ImmutablePeopleTests
{
    public class PersonTests
    {
        [Fact]
        public void WithNamePTest_Student()
        {
            //Arrange
            Person p = Student.Default.WithName("Marek Nagy");

            //Act
            p = p.WithNameP("Pavel Jezek");

            //Assert
            Assert.Equal("Pavel", p.FirstName);
        }
        [Fact]
        public void WithNamePTest_Teacher()
        {
            //Arrange
            Person p = Teacher.Default.WithName("Marek Nagy");

            //Act
            p = p.WithNameP("Pavel Jezek");

            //Assert
            Assert.Equal("Pavel", p.FirstName);
        }
        [Fact]
        public void WithPasswordPTest_Student()
        {
            //Arrange
            Person p = Student.Default.WithPasswordP("Marek Nagy");

            //Act
            p = p.WithNameP("Pavel Jezek");

            //Assert
            Assert.Equal("Pavel", p.FirstName);
        }
        [Fact]
        public void WithPasswordPTest_Teacher()
        {
            //Arrange
            Person p = Teacher.Default.WithPasswordP("Marek Nagy");

            //Act
            p = p.WithNameP("Pavel Jezek");

            //Assert
            Assert.Equal("Pavel", p.FirstName);
        }
    }
}
