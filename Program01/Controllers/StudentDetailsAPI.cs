using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Program01.InterfaceClass;
using Program01.Model;
using Program01.Respository;
using Symbol.Serialization;
using System.Security.Cryptography.X509Certificates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Program01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDetailsAPI : ControllerBase
    {
        private readonly DataBaseRespository _dataBaseRespository;

        private readonly ILogInfo _logInfo;

        /// <summary>
        /// Created API controller
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public StudentDetailsAPI(IConfiguration configuration, ILogInfo logInfo) 
        {
            _dataBaseRespository = new DataBaseRespository(configuration);
            _logInfo = logInfo;
        }

        public class Details
        {
            public string FullName { get; set; }
            public bool Deleted { get; set; }

            [JsonConverter(typeof(StringEnumConverter))]
            public UserStatus Status { get; set; }

        }
        /// <summary>
        /// Added to convert while using Json converter
        /// </summary>
        public enum UserStatus
        {
            Active,
            Deleted,
            NotConfirmed
        }

        // GET: api/<StudentDetailsAPI>
        /// <summary>
        /// Getting all student details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            try
            {
                var res = Math.Round(6.5); // output is 6 // for any even number it will result the very previous even number   
                var asd = Math.Round(11.5, 2); // output is 12
                var aasd = Math.Round(11.5); // out put is 12 // for any odd number it will result very next coming even number

                //Reverese for String
                var valueReverse = "Eakhanath";
                var lentofString = valueReverse.Length -1; // to get correct length to reverse string
                char[] charArray = valueReverse.ToCharArray();
                for(int i=0,j=valueReverse.Length-1;i<j;i++,j--)
                {
                    charArray[i] = valueReverse[j]; // mapping charArray value ith value to jth value
                    charArray[j] = valueReverse[i]; // mapping charArray value jth value to ith value
                }
                var reversedString = new string(charArray);

                // giving inputs as "Helloworld" and getting output as Helowrd removing duplicates

                var mainString = "Helloworld";
                var resultString = "";
                var dupStr = "";
                foreach(char s in mainString)
                {
                    if (!resultString.Contains(s))
                    {
                        resultString = resultString + s;
                    }
                }
                var resStr = resultString.ToString();

                /// Nested Ternary operator
                int ntr = 85;
                var ntrPrec = (ntr >= 90) ? "A" :
                               (ntr >= 80) ? "B" :
                                 (ntr >= 70) ? "C" : "Fail";
                var result = _dataBaseRespository.GetAllStudentRecords();

                #region Json Serialization and Deserialization using System.Text.Json



                /// Serialize Object to Json string using Newtonsoft.Json
                var jsonSerializdValues = JsonConvert.SerializeObject(result);

                /// Deserialize Json string to Object using Newtonsoft.Json
                var jsonStringValues = "[{\"StudentID\":1,\"FirstName\":\"John\",\"LastName\":\"Doe\",\"Gender\":\"Male\",\"DateOfBirth\":\"2001-05-10T00:00:00\",\"Age\":20,\"Email\":\"john@example.com\",\"Phone\":\"9876543210\",\"Address\":\"123 Main St\",\"City\":\"Hyderabad\",\"State\":\"Telangana\",\"Country\":\"India\",\"PostalCode\":\"500001\",\"AdmissionDate\":\"2021-08-01T00:00:00\",\"Course\":\"B.Tech\",\"Department\":\"CSE\",\"YearOfStudy\":3,\"GPA\":8.50,\"CreatedDate\":\"2025-10-14T16:43:44.92\"},{\"StudentID\":2,\"FirstName\":\"Alice\",\"LastName\":\"Johnson\",\"Gender\":\"Female\",\"DateOfBirth\":\"2000-03-15T00:00:00\",\"Age\":19,\"Email\":\"alice.johnson@example.com\",\"Phone\":\"9998887776\",\"Address\":\"45 Rosewood Apartments\",\"City\":\"Bangalore\",\"State\":\"Karnataka\",\"Country\":\"India\",\"PostalCode\":\"560001\",\"AdmissionDate\":\"2019-06-20T00:00:00\",\"Course\":\"B.Sc Computer Science\",\"Department\":\"IT\",\"YearOfStudy\":4,\"GPA\":9.20,\"CreatedDate\":\"2025-10-14T16:49:14.807\"},{\"StudentID\":3,\"FirstName\":\"Rahul\",\"LastName\":\"Sharma\",\"Gender\":\"Male\",\"DateOfBirth\":\"2001-07-22T00:00:00\",\"Age\":18,\"Email\":\"rahul.sharma@example.com\",\"Phone\":\"9988776655\",\"Address\":\"12 MG Road\",\"City\":\"Pune\",\"State\":\"Maharashtra\",\"Country\":\"India\",\"PostalCode\":\"411001\",\"AdmissionDate\":\"2020-07-15T00:00:00\",\"Course\":\"B.Tech Mechanical\",\"Department\":\"Engineering\",\"YearOfStudy\":3,\"GPA\":8.10,\"CreatedDate\":\"2025-10-14T16:49:14.807\"},{\"StudentID\":4,\"FirstName\":\"Priya\",\"LastName\":\"Menon\",\"Gender\":\"Female\",\"DateOfBirth\":\"1999-11-30T00:00:00\",\"Age\":22,\"Email\":\"priya.menon@example.com\",\"Phone\":\"9876543210\",\"Address\":\"78 Green Park\",\"City\":\"Chennai\",\"State\":\"Tamil Nadu\",\"Country\":\"India\",\"PostalCode\":\"600002\",\"AdmissionDate\":\"2018-08-10T00:00:00\",\"Course\":\"B.Com\",\"Department\":\"Commerce\",\"YearOfStudy\":4,\"GPA\":8.70,\"CreatedDate\":\"2025-10-14T16:49:14.807\"},{\"StudentID\":5,\"FirstName\":\"David\",\"LastName\":\"Thomas\",\"Gender\":\"Male\",\"DateOfBirth\":\"2002-01-10T00:00:00\",\"Age\":19,\"Email\":\"david.thomas@example.com\",\"Phone\":\"9123456780\",\"Address\":\"19 Lake View\",\"City\":\"Hyderabad\",\"State\":\"Telangana\",\"Country\":\"India\",\"PostalCode\":\"500001\",\"AdmissionDate\":\"2021-06-25T00:00:00\",\"Course\":\"BCA\",\"Department\":\"Computer Applications\",\"YearOfStudy\":2,\"GPA\":8.90,\"CreatedDate\":\"2025-10-14T16:49:14.807\"},{\"StudentID\":6,\"FirstName\":\"Neha\",\"LastName\":\"Patel\",\"Gender\":\"Female\",\"DateOfBirth\":\"2000-09-05T00:00:00\",\"Age\":20,\"Email\":\"neha.patel@example.com\",\"Phone\":\"9001122334\",\"Address\":\"220 Lotus Street\",\"City\":\"Ahmedabad\",\"State\":\"Gujarat\",\"Country\":\"India\",\"PostalCode\":\"380001\",\"AdmissionDate\":\"2019-06-18T00:00:00\",\"Course\":\"BA Economics\",\"Department\":\"Humanities\",\"YearOfStudy\":3,\"GPA\":8.40,\"CreatedDate\":\"2025-10-14T16:49:14.807\"},{\"StudentID\":7,\"FirstName\":\"Arjun\",\"LastName\":\"Reddy\",\"Gender\":\"Male\",\"DateOfBirth\":\"2001-04-17T00:00:00\",\"Age\":19,\"Email\":\"arjun.reddy@example.com\",\"Phone\":\"9090909090\",\"Address\":\"5 Sunrise Colony\",\"City\":\"Hyderabad\",\"State\":\"Telangana\",\"Country\":\"India\",\"PostalCode\":\"500002\",\"AdmissionDate\":\"2020-07-05T00:00:00\",\"Course\":\"B.Tech CSE\",\"Department\":\"Engineering\",\"YearOfStudy\":3,\"GPA\":9.50,\"CreatedDate\":\"2025-10-14T16:49:14.807\"},{\"StudentID\":8,\"FirstName\":\"Sara\",\"LastName\":\"Williams\",\"Gender\":\"Female\",\"DateOfBirth\":\"2000-12-25T00:00:00\",\"Age\":17,\"Email\":\"sara.williams@example.com\",\"Phone\":\"8887776665\",\"Address\":\"41 Palm Grove\",\"City\":\"Delhi\",\"State\":\"Delhi\",\"Country\":\"India\",\"PostalCode\":\"110001\",\"AdmissionDate\":\"2019-07-12T00:00:00\",\"Course\":\"BBA\",\"Department\":\"Business\",\"YearOfStudy\":4,\"GPA\":8.80,\"CreatedDate\":\"2025-10-14T16:49:14.807\"},{\"StudentID\":9,\"FirstName\":\"Karan\",\"LastName\":\"Singh\",\"Gender\":\"Male\",\"DateOfBirth\":\"1999-08-18T00:00:00\",\"Age\":17,\"Email\":\"karan.singh@example.com\",\"Phone\":\"9786541230\",\"Address\":\"33 Market Road\",\"City\":\"Jaipur\",\"State\":\"Rajasthan\",\"Country\":\"India\",\"PostalCode\":\"302001\",\"AdmissionDate\":\"2018-07-30T00:00:00\",\"Course\":\"B.Sc Physics\",\"Department\":\"Science\",\"YearOfStudy\":4,\"GPA\":7.90,\"CreatedDate\":\"2025-10-14T16:49:14.807\"},{\"StudentID\":10,\"FirstName\":\"Meena\",\"LastName\":\"Kumari\",\"Gender\":\"Female\",\"DateOfBirth\":\"2002-03-08T00:00:00\",\"Age\":22,\"Email\":\"meena.kumari@example.com\",\"Phone\":\"9873216540\",\"Address\":\"18 Galaxy Lane\",\"City\":\"Kochi\",\"State\":\"Kerala\",\"Country\":\"India\",\"PostalCode\":\"682001\",\"AdmissionDate\":\"2021-08-01T00:00:00\",\"Course\":\"BCA\",\"Department\":\"Computer Applications\",\"YearOfStudy\":2,\"GPA\":8.60,\"CreatedDate\":\"2025-10-14T16:49:14.807\"},{\"StudentID\":11,\"FirstName\":\"John\",\"LastName\":\"Doe\",\"Gender\":\"Male\",\"DateOfBirth\":\"2001-05-10T00:00:00\",\"Age\":21,\"Email\":\"john.doe@example.com\",\"Phone\":\"9876543210\",\"Address\":\"123 Main St\",\"City\":\"Mumbai\",\"State\":\"Maharashtra\",\"Country\":\"India\",\"PostalCode\":\"400001\",\"AdmissionDate\":\"2020-08-15T00:00:00\",\"Course\":\"B.Tech Civil\",\"Department\":\"Engineering\",\"YearOfStudy\":3,\"GPA\":7.80,\"CreatedDate\":\"2025-10-14T16:49:14.807\"}]";
                var jsonDesrializeValues = JsonConvert.DeserializeObject<List<StudentRecords>>(jsonStringValues);


                ///Serialize empty object and find difference between using DefaultValueHandling -- output is all values with nulls and zeros
                var defaultStudent = new StudentRecords();
                string someJsonData = JsonConvert.SerializeObject(defaultStudent);
                // here we will get all default values of object properties mainly with all null and zeros -- output  is {}
                string sommJsonWithOutDefaultValues = JsonConvert.SerializeObject(defaultStudent, new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore, // to ignore default values like null and zeros
                    MissingMemberHandling = MissingMemberHandling.Error, // to throw error if any member is missing in json while deserialization use this while deserializing json to object
                    NullValueHandling = NullValueHandling.Ignore, // to ignore null values while serialization and also we have inlcude option to include null values.
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat, // to provide Time Formate for Data and time values

                });


                string json = @"{
                  'FullName': 'Dan Dom',
                  'Deleted': true,
                  'UserStatus': 'Deleted',
                    }";
                MemoryTraceWriter traceWriter = new MemoryTraceWriter();
                Details details = JsonConvert.DeserializeObject<Details>(json, new JsonSerializerSettings
                {
                    TraceWriter = traceWriter
                });
                /* Trace Writer will give below details.
                 * {2025-11-14T21:31:32.812 Info Started deserializing Program01.Controllers.StudentDetailsAPI+Details. Path 'FullName', line 2, position 29.
                    2025-11-14T21:31:32.822 Verbose Could not find member 'DeletedDate' on Program01.Controllers.StudentDetailsAPI+Details. Path 'DeletedDate', line 4, position 32.
                    2025-11-14T21:31:32.822 Info Finished deserializing Program01.Controllers.StudentDetailsAPI+Details. Path '', line 5, position 21.
                    2025-11-14T21:31:32.822 Verbose Deserialized JSON: 
                    {
                      "FullName": "Dan Deleted",
                      "Deleted": true,
                      "DeletedDate": "2013-01-20T00:00:00"
                    }}
                 */

                // Calling Enum to Json Converter using Json Convertor attribute property.
                Details details2 = new Details
                {
                    FullName = "Sam Smith",
                    Deleted = false,
                    Status = UserStatus.NotConfirmed
                };
                string details1 = JsonConvert.SerializeObject(details2);


                string studentDetails01 = JsonConvert.SerializeObject(result);
                /// Here we will not get Student ID details as that is not marked with JsonProperty attribute in StudentRecordsJsonModel class
                List<StudentRecordsJsonModel> studentRecordsJsonModels = JsonConvert.DeserializeObject<List<StudentRecordsJsonModel>>(studentDetails01);

                DefaultContractResolver contractResolver = new DefaultContractResolver { 
                        NamingStrategy = new KebabCaseNamingStrategy()
                };

                /// above object class data is converting to json string in below line.
                var formateValue = JsonConvert.SerializeObject(studentRecordsJsonModels, new JsonSerializerSettings
                {
                    ContractResolver = contractResolver
                });
                #endregion

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        // GET api/<StudentDetailsAPI>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("{studentId}")]
        public IActionResult GetStudentResultId(int studentId)
        {
            try
            {
                var result = _dataBaseRespository.GetStudentRecordsById(studentId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        // POST api/<StudentDetailsAPI>
        [HttpPost]
        public IActionResult Post([FromBody] StudentRecords student)
        {
            try
            {
                _dataBaseRespository.AddStudenDetails(student);
                return Ok(student.StudentID+ " Add new student Successfully");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // PUT api/<StudentDetailsAPI>/5
        [HttpPut("{studentId}")]
        public IActionResult Put(int studentId, [FromBody] StudentRecords student)
        {
            try
            {
                student.StudentID = studentId;
                _dataBaseRespository.UpdateStudentRecord(student);
                return Ok(student.ToString() + "Updated successfully");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // DELETE api/<StudentDetailsAPI>/5
        [HttpDelete("{studentId}")]
        public IActionResult Delete(int studentId)
        {
            try
            {
                _dataBaseRespository.DeleteStudenDetailsByID(studentId);
                return Ok(studentId.ToString() + " Deleted Requested Student Details");

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
