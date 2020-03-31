
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
        
        
         

    }

}