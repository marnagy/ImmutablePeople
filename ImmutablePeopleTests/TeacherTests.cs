using System;
using ImmutablePeople;
using Xunit;

namespace ImmutablePeopleTests
{
    public class TeacherTests
    {
        [Fact]
        public void WithNameTest()
        {
            //Arrange
            Teacher s1 = Teacher.Default;
            Teacher s2;

            //Act
            s2  = s1.WithName("Marek Nagy");

            //Assert
            Assert.NotEqual(s1, s2);
        }
        [Fact]
        public void WithPasswordTest()
        {
            //Arrange
            Teacher s1 = Teacher.Default.WithPassword("great_passwd");
            Teacher s2;

            //Act
            s2  = s1.WithPassword("good_passwd");

            //Assert
            Assert.NotEqual(s1, s2);
        }
        [Fact]
        public void WithCoursesTest()
        {
            //Arrange
            Teacher s1 = Teacher.Default.WithCoursesHeld(21);
            Teacher s2;

            //Act
            s2  = s1.WithCoursesHeld(20);

            //Assert
            Assert.NotEqual(s1, s2);
        }
        [Fact]
        public void EqualsTest()
        {
            //Arrange
            Teacher s1 = Teacher.Default.WithName("Marek Nagy").WithPassword("good_passwd").WithCoursesHeld(20);
            Teacher s2 = Teacher.Default.WithCoursesHeld(20).WithName("Marek Nagy");

            //Act
            s2  = s2.WithPassword("good_passwd");

            //Assert
            Assert.Equal(s1, s2);
        }
    }
}
