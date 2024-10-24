using System;
using System.Collections.Generic;
using Xunit;
using XUnitDemo.Contract;

namespace XUnitDemo.Tests
{
    public class SqlDBConnectionModuleUnitTests
    {
        /// <summary>
        /// Unit test for testing connections
        /// </summary>
        [Fact]
        public void CheckConnection_ShouldReturnTrue_WhenConnectionIsSuccessful()
        {
            // Act
            bool result = SqlDBConnectionModule.CheckConnection();

            // Assert
            Assert.True(result);
        }


        /// <summary>
        /// Unit test for testing ExecuteList method
        /// </summary>
        [Fact]
        public void ExecuteList_ShouldReturnListOfStudents_WhenQueryIsValid()
        {
            // Arrange
            string query = "SELECT * FROM Students"; // Ensure this is valid for your test database

            // Act
            var result = SqlDBConnectionModule.ExecuteList<StudentDTO>(query);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<StudentDTO>>(result);
        }

        /// <summary>
        /// unit test for testing ExecuteScalar method
        /// </summary>
        [Fact]
        public void ExecuteScalar_ShouldReturnSingleValue_WhenQueryIsValid()
        {
            // Arrange
            string query = "SELECT COUNT(*) FROM Students"; // A simple scalar query

            // Act
            int result = SqlDBConnectionModule.ExecuteScalar<int>(query);

            // Assert
            Assert.True(result >= 0); // Ensure it returns a non-negative count
        }

        /// <summary>
        /// Unit test for testing ExecuteNonQuery Method
        /// </summary>
        [Fact]
        public void ExecuteNonQuery_ShouldInsertStudent_WhenQueryIsValid()
        {
            // Arrange
            var student = new StudentDTO
            {
                FirstName = "Test",
                LastName = "User",
                DateOfBirth = new DateTime(2000, 1, 1),
                Email = "test.user@example.com",
                EnrollmentDate = DateTime.Now
            };

            string query = "INSERT INTO Students (FirstName, LastName, DateOfBirth, Email, EnrollmentDate) " +
                           "VALUES (@FirstName, @LastName, @DateOfBirth, @Email, @EnrollmentDate);";

            // Act
            int affectedRows = SqlDBConnectionModule.ExecuteNonQuery(query, new 
                {
                    student.FirstName,
                    student.LastName,
                    student.DateOfBirth,
                    student.Email,
                    student.EnrollmentDate
                });

            // Assert
            Assert.Equal(1, affectedRows); // Assuming one row is affected on successful insert
        }
    }
}
