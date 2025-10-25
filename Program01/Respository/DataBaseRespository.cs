using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.IO;
using Microsoft.Extensions.Configuration;
using Program01.Model;

namespace Program01.Respository
{
    public class DataBaseRespository
    {
        private readonly string _connectionStrings;

        // Creating constructor 
        //if your not able to find any class through the extension you can just use full root
        //Iconfirguration is didn't worked so i called it as below
        //Micorsoft.Extensions.Configuration.IConfiguration
        // Constructor should have any return types
        public DataBaseRespository(IConfiguration configuration)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",optional: false).Build();
            _connectionStrings = configuration.GetConnectionString("TestingSQL") ?? throw new InvalidOperationException(" Connection for data base not found");
        }

        /// <summary>
        /// Here we will add the student details for DB
        /// First create connection, Add query, add values and open connection, run query
        /// </summary>
        /// </summary>
        public void AddStudenDetails(StudentRecords studentRecords)
        {
            using (SqlConnection conn = new SqlConnection(_connectionStrings))
            {
                string query = @"INSERT INTO [dbo].[StudentRecords]([FirstName],[LastName],[Gender],[DateOfBirth],[Age],[Email],[Phone],[Address],[City],[State],[Country],[PostalCode],[AdmissionDate],[Course],[Department],[YearOfStudy],[GPA],[IsActive],[CreatedDate],[UpdatedDate])
                                VALUES(@FirstName,@LastName,@Gender,@DateOfBirth,@Age,@Email,@Phone,@Address,@City,@State,@Country,@PostalCode,@AdmissionDate,@Course,@Department,@YearOfStudy,@GPA,1,GETDATE(), GETDATE()),";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", studentRecords.FirstName);
                cmd.Parameters.AddWithValue("@LastName", studentRecords.LastName);
                cmd.Parameters.AddWithValue("@Gender", studentRecords.Gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", studentRecords.DateOfBirth);
                cmd.Parameters.AddWithValue("@Age", studentRecords.Age);
                cmd.Parameters.AddWithValue("@Email", studentRecords.Email);
                cmd.Parameters.AddWithValue("@Phone", studentRecords.Phone);
                cmd.Parameters.AddWithValue("@Address", studentRecords.Address);
                cmd.Parameters.AddWithValue("@City", studentRecords.City);
                cmd.Parameters.AddWithValue("@State", studentRecords.State);
                cmd.Parameters.AddWithValue("@Country", studentRecords.Country);
                cmd.Parameters.AddWithValue("@PostalCode", studentRecords.PostalCode);
                cmd.Parameters.AddWithValue("@AdmissionDate", studentRecords.AdmissionDate);
                cmd.Parameters.AddWithValue("@Course", studentRecords.Course);
                cmd.Parameters.AddWithValue("@Department", studentRecords.Department);
                cmd.Parameters.AddWithValue("@YearOfStudy", studentRecords.YearOfStudy);
                cmd.Parameters.AddWithValue("@GPA", studentRecords.GPA);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

        }
        /// <summary>
        /// Get all data from SQL
        /// Usign SQL Reader
        /// </summary>
        /// <returns></returns>
        public List<StudentRecords> GetAllStudentRecords()
        {
            var studentRecordsList = new List<StudentRecords>();

            using (SqlConnection conn = new SqlConnection(_connectionStrings))
            {
                string query = @"SELECT *  FROM [StudentRecords]";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                // line to get all data form SQL
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    studentRecordsList.Add(
                        new StudentRecords()
                        {
                            StudentID = Convert.ToInt32(reader["StudentID"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            DateOfBirth = DateOnly.FromDateTime(Convert.ToDateTime(reader["DateOfBirth"])),//.Parse(reader["DateOfBirth"].ToString()),
                            Age = Convert.ToInt32(reader["Age"]),
                            Email = reader["Email"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Address = reader["Address"].ToString(),
                            City = reader["City"].ToString(),
                            State = reader["State"].ToString(),
                            Country = reader["Country"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            AdmissionDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["AdmissionDate"])), //.Parse(reader["AdmissionDate"].ToString()),
                            Course = reader["Course"].ToString(),
                            Department = reader["Department"].ToString(),
                            YearOfStudy = Convert.ToInt32(reader["YearOfStudy"]),
                            GPA = Convert.ToDecimal(reader["GPA"]),
                            CreatedDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["CreatedDate"]))
                        });
                }
            }

            return studentRecordsList;
        }

        /// <summary>
        /// GetStudentRecordsById to get the values based on ID
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public StudentRecords GetStudentRecordsById (int studentId)
        {
            StudentRecords studentRecord = new StudentRecords();

            using(SqlConnection conn = new SqlConnection(_connectionStrings))
            {
                string query = @"SELECT *  FROM [StudentRecords] where StudentID=@studentId";
                SqlCommand cmd  = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@studentId", studentId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    studentRecord = new StudentRecords()
                    {
                        StudentID = Convert.ToInt32(reader["StudentID"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        DateOfBirth = DateOnly.FromDateTime(Convert.ToDateTime(reader["DateOfBirth"])),//.Parse(reader["DateOfBirth"].ToString()),
                        Age = Convert.ToInt32(reader["Age"]),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString(),
                        City = reader["City"].ToString(),
                        State = reader["State"].ToString(),
                        Country = reader["Country"].ToString(),
                        PostalCode = reader["PostalCode"].ToString(),
                        AdmissionDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["AdmissionDate"])),
                        Course = reader["Course"].ToString(),
                        Department = reader["Department"].ToString(),
                        YearOfStudy = Convert.ToInt32(reader["YearOfStudy"]),
                        GPA = Convert.ToDecimal(reader["GPA"]),
                        CreatedDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["CreatedDate"]))
                    };
                }
            }

            return studentRecord;
        }

        /// <summary>
        /// Here to update it is similar toinsert and we are doing Execute NON Query () at last
        /// </summary>
        /// <param name="studentRecords"></param>
        public void UpdateStudentRecord(StudentRecords studentRecords)
        {
            using(SqlConnection conn = new SqlConnection(_connectionStrings))
            {
                string query = @"UPDATE [StudentRecords] SET FirstName=@FirstName,LastName=@LastName,Gender=@Gender,DateOfBirth=@DateOfBirth,Age=@Age,Email=@Email,Phone=@Phone,Address=@Address,City=@City,State=@State,Country=@Country,PostalCode=@PostalCode,AdmissionDate=@AdmissionDate,
                                    Course=@Course,Department=@Department,YearOfStudy=@YearOfStudy,GPA=@GPA,UpdatedDate=GETDATE() where StudentID = @StudentID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentRecords.StudentID);
                cmd.Parameters.AddWithValue("@FirstName", studentRecords.FirstName);
                cmd.Parameters.AddWithValue("@LastName", studentRecords.LastName);
                cmd.Parameters.AddWithValue("@Gender", studentRecords.Gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", studentRecords.DateOfBirth);
                cmd.Parameters.AddWithValue("@Age", studentRecords.Age);
                cmd.Parameters.AddWithValue("@Email", studentRecords.Email);
                cmd.Parameters.AddWithValue("@Phone", studentRecords.Phone);
                cmd.Parameters.AddWithValue("@Address", studentRecords.Address);
                cmd.Parameters.AddWithValue("@City", studentRecords.City);
                cmd.Parameters.AddWithValue("@State", studentRecords.State);
                cmd.Parameters.AddWithValue("@Country", studentRecords.Country);
                cmd.Parameters.AddWithValue("@PostalCode", studentRecords.PostalCode);
                cmd.Parameters.AddWithValue("@AdmissionDate", studentRecords.AdmissionDate);
                cmd.Parameters.AddWithValue("@Course", studentRecords.Course);
                cmd.Parameters.AddWithValue("@Department", studentRecords.Department);
                cmd.Parameters.AddWithValue("@YearOfStudy", studentRecords.YearOfStudy);
                cmd.Parameters.AddWithValue("@GPA", studentRecords.GPA);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Added Delete values using Cmd parameter with values and execute Non Query()
        /// </summary>
        /// <param name="studentID"></param>
        public void DeleteStudenDetailsByID (int studentID)
        {
            using(SqlConnection conn = new SqlConnection(_connectionStrings))
            {
                string query = @"Delete From table [StudentRecords] where StudentID = @StudentID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}