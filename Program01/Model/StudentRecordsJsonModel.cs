using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Scarlet.System.Text.Json.DateTimeConverter;

namespace Program01.Model
{
    /// <summary>
    /// Added [JsonObject(NamingStrategyType =(typeof(CamelCaseNamingStrategy)))]  for  camcle case format of values 
    /// and Memeber Serializaton.OptIn to include and exclude the class properties while serailazation and deserialization
    /// </summary>
    [JsonObject(MemberSerialization.OptIn,NamingStrategyType = (typeof(CamelCaseNamingStrategy)))]
    
    public class StudentRecordsJsonModel
    {
        /// <summary>
        /// We did not used Json property so this below Student ID will not get seralized and deserialized in JSON format
        /// </summary>
        public int StudentID { get; set; }
        [JsonProperty("first_Name")]
        public string FirstName { get; set; }
        [JsonProperty("last_Name")]
        public string LastName { get; set; }
        [JsonProperty("gender_Details")]
        public string Gender { get; set; }
        //[DataType(DataType.Date)]
        /// <summary>
        /// Using Scarlet Nuget package to convert the date format while JSON serialization and deserialization and converting date format to yyyymmdd
        /// DateOnly will not work in Scarlet package so using DateTime type
        /// [JsonDateTimeConverter("yyyy-MM-dd")] should be MM in capital cause mm - minutes MM- Month in two number like 01,02 etc, if it M- month in on letter
        /// </summary>
        [JsonProperty]
        [JsonDateTimeConverter("yyyy-MM-dd")]
        public DateTime DateOfBirth { get; set; }
        [JsonProperty]
        public int Age { get; set; }
        [JsonProperty("email_address")]
        public string Email { get; set; }
        [JsonProperty("number_details")]
        public string Phone { get; set; }
        [JsonProperty("address_Details")]
        public string Address { get; set; }
        [JsonProperty("CityArea")]
        public string City { get; set; }
        [JsonProperty("state_Area")]
        public string State { get; set; }
        [JsonProperty("nationality_Details")]
        public string Country { get; set; }
        [JsonProperty("pincode_Details")]
        public string PostalCode { get; set; }
        //[DataType(DataType.Date)]
        /// <summary>
        /// Using Scarlet Nuget package to convert the date format while JSON serialization and deserialization and converting date format to yyyymmdd
        /// DateOnly will not work in Scarlet package so using DateTime type
        ///[JsonDateTimeConverter("yyyy-MM-dd")] should be MM in capital cause mm - minutes MM- Month in two number like 01,02 etc, if it M- month in on letter
        /// </summary>
        [JsonProperty("joining_date")]
        [JsonDateTimeConverter("yyyy-MM-dd")]
        public DateTime AdmissionDate { get; set; }
        [JsonProperty("branch_Details")]
        public string Course { get; set; }
        [JsonProperty("department_details")]
        public string Department { get; set; }
        [JsonProperty("joining_year")]
        public int YearOfStudy { get; set; }
        [JsonProperty("marks_details")]
        public decimal GPA { get; set; }
        //[DataType(DataType.Date)]
        /// <summary>
        /// Using Scarlet Nuget package to convert the date format while JSON serialization and deserialization and converting date format to yyyymmdd
        /// DateOnly will not work in Scarlet package so using DateTime type
        /// [JsonDateTimeConverter("yyyy-MM-dd")] should be MM in capital cause mm - minutes MM- Month in two number like 01,02 etc, if it M- month in on letter
        /// </summary>
        [JsonProperty("login_details")]
        [JsonDateTimeConverter("yyyy-MM-dd")]
        public DateTime CreatedDate { get; set; }

        //[JsonConverter(typeof(JsonDateTimeFormatConverter<JsonDateTimeFormat.DateTimeFormat>))]
        //public DateTime Date { get; set; }

    }
}
