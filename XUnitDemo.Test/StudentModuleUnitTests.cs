using System;
using System.Collections.Generic;
using Xunit;
using XUnitDemo.Contract;

namespace XUnitDemo.Tests
{
    public class StudentModuleUnitTests
    {
        private readonly StudentModule _studentModule;

        public StudentModuleUnitTests()
        {
            _studentModule = new StudentModule();
        }

        /// <summary>
        /// Unit test for inserting new student
        /// </summary>
        [Fact]
        public void InsertStudent_ShouldReturnNewStudentId_WhenSuccessful()
        {
            // Arrange
            var student = new StudentDTO
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(2000, 1, 1),
                Email = "john.doe@example.com",
                EnrollmentDate = DateTime.Now
            };

            // Act
            int result = _studentModule.InsertStudent(student);

            // Assert
            Assert.NotEqual(-1, result); // Assuming a valid ID is returned
        }

        /// <summary>
        /// Unit testing for updating new student
        /// </summary>
        [Fact]
        public void UpdateStudent_ShouldReturnAffectedRows_WhenSuccessful()
        {
            // Arrange
            var student = new StudentDTO
            {
                StudentID = 1,
                FirstName = "Jane",
                LastName = "Doe",
                DateOfBirth = new DateTime(2000, 1, 1),
                Email = "jane.doe@example.com",
                EnrollmentDate = DateTime.Now
            };

            // Act
            int result = _studentModule.UpdateStudent(student);

            // Assert
            Assert.NotEqual(-1, result); // Assuming a positive number indicates success
        }

        /// <summary>
        /// Unit testing for deleting student
        /// </summary>
        [Fact]
        public void DeleteStudent_ShouldReturnAffectedRows_WhenSuccessful()
        {
            // Arrange
            int studentId = 1;

            // Act
            int result = _studentModule.DeleteStudent(studentId);

            // Assert
            Assert.NotEqual(-1, result); // Assuming a positive number indicates success
        }

        /// <summary>
        /// unit test for getting all student
        /// </summary>
        [Fact]
        public void GetAllStudents_ShouldReturnListOfStudents_WhenSuccessful()
        {
            // Act
            var result = _studentModule.GetAllStudents();

            // Assert
            Assert.NotNull(result); // Ensure the result is not null
            Assert.IsType<List<StudentDTO>>(result); // Ensure the result is a list of StudentDTO
        }
    }
}
