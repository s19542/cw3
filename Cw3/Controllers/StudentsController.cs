
using System.Collections.Generic;
using System.Data.SqlClient;
using Cw3.DAL;
using Cw3.Models;
using Microsoft.AspNetCore.Mvc;


namespace Cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {


        private const string ConString = "Data Source=db-mssql;Initial Catalog=s19542;Integrated Security=True";



        [HttpGet]
        public IActionResult GetStudents()
        {
            var list = new List<Student>();


            using (SqlConnection con = new SqlConnection(ConString))

            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select FirstName,LastName,BirthDate, Name, Semester from Student INNER JOIN Enrollment en ON Student.IdEnrollment = en.IdEnrollment INNER JOIN Studies st ON en.IdStudy = st.IdStudy;";

                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();

                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = dr["BirthDate"].ToString();
                    st.NazwaStudiow = dr["Name"].ToString();
                    st.NumerSemestru = dr["Semester"].ToString();

                    list.Add(st);


                }

            }




            return Ok(list);
        }

        [HttpGet("{IndexNumber}")]
        public IActionResult GetStudents(string indexNumber)
        {

            using (SqlConnection con = new SqlConnection(ConString))
              
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select Semester, StartDate, Name  from Enrollment INNER JOIN Studies on Enrollment.IdStudy = Studies.IdStudy WHERE IdEnrollment = (select IdEnrollment from student where indexNumber like @id ); ";
                com.Parameters.AddWithValue("id", indexNumber);
                con.Open();
                var dr = com.ExecuteReader();

               
                if (dr.Read())
                {
                  
                 return Ok(string.Concat("Semester: " + dr["Semester"].ToString(), "\nStartDate: ", dr["StartDate"].ToString(), "\nName of studies: ", dr["Name"].ToString()));
                }
               

            } 
               return NotFound();
        }

    }
}
