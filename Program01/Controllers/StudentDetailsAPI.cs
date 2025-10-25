using Microsoft.AspNetCore.Mvc;
using Program01.Model;
using Program01.Respository;
using Symbol.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Program01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDetailsAPI : ControllerBase
    {
        private readonly DataBaseRespository _dataBaseRespository;
        /// <summary>
        /// Created API controller
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public StudentDetailsAPI(IConfiguration configuration) 
        {
            _dataBaseRespository = new DataBaseRespository(configuration);
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
                var result = _dataBaseRespository.GetAllStudentRecords();
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
