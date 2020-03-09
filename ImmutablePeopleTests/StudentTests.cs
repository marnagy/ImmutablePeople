using System;
using Xunit;
using ImmutablePeople;

namespace ImmutablePeopleTests
{
    public class StudentTests
    {
        [Fact]
        public void WithNameTest()
        {
            //Arrange
            Student s1 = Student.Default;
            Student s2;

            //Act
            s2  = s1.WithName("Marek Nagy");

            //Assert
            Assert.NotEqual(s1, s2);
        }
        [Fact]
        public void WithPasswordTest()
        {
            //Arrange
            Student s1 = Student.Default;
            Student s2;

            //Act
            s2  = s1.WithPassword("good_passwd");

            //Assert
            Assert.NotEqual(s1, s2);
        }
        [Fact]
        public void WithDateEnrolledTest()
        {
            //Arrange
            Student s1 = Student.Default.WithDateEnrolled( new DateTime(2020,01,02) );
            Student s2;

            //Act
            s2  = s1.WithDateEnrolled(DateTime.Now);

            //Assert
            Assert.NotEqual(s1, s2);
        }
        [Fact]
        public void EqualsTest()
        {
            //Arrange
            Student s1 = Student.Default.WithName("Marek Nagy").WithPassword("good_passwd").WithDateEnrolled( new DateTime(2020,01,01) );
            Student s2 = Student.Default.WithName("Marek Nagy").WithDateEnrolled( new DateTime(2020,01,01) );

            //Act
            s2  = s2.WithPassword("good_passwd");

            //Assert
            Assert.Equal(s1, s2);
        }
    }
}
