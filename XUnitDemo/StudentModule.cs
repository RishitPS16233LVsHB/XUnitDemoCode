using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitDemo.Contract;

namespace XUnitDemo
{
    public class StudentModule
    {
        /// <summary>
        /// Inserts student using DTO
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int InsertStudent(StudentDTO student)
        {
            try
            {
                string query = "INSERT INTO Students (FirstName, LastName, DateOfBirth, Email, EnrollmentDate) " +
                               "VALUES (@FirstName, @LastName, @DateOfBirth, @Email, @EnrollmentDate); " +
                               "SELECT CAST(SCOPE_IDENTITY() AS int);";

                // Execute the query and return the newly created StudentID
                return SqlDBConnectionModule.ExecuteScalar<int>(query, new
                {
                    student.FirstName,
                    student.LastName,
                    student.DateOfBirth,
                    student.Email,
                    student.EnrollmentDate
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Updates Student using DTO
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int UpdateStudent(StudentDTO student)
        {
            try
            {
                string query = "UPDATE Students SET FirstName = @FirstName, LastName = @LastName, " +
                               "DateOfBirth = @DateOfBirth, Email = @Email, EnrollmentDate = @EnrollmentDate " +
                               "WHERE StudentID = @StudentID";

                // Execute the update query
                return SqlDBConnectionModule.ExecuteNonQuery(query, new
                {
                    student.FirstName,
                    student.LastName,
                    student.DateOfBirth,
                    student.Email,
                    student.EnrollmentDate,
                    student.StudentID
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Deletes student on id
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public int DeleteStudent(int studentId)
        {
            try
            {
                string query = "DELETE FROM Students WHERE StudentID = @StudentID";

                // Execute the delete query
                return SqlDBConnectionModule.ExecuteNonQuery(query, new { StudentID = studentId });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Gets all students
        /// </summary>
        /// <returns></returns>
        public List<StudentDTO> GetAllStudents()
        {
            try
            {
                string query = "SELECT * FROM Students";
                return SqlDBConnectionModule.ExecuteList<StudentDTO>(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
