using Cw3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.DAL
{
   
        public class MockDbService : IDbService
        {
            private static IEnumerable<Student> _students;
            static MockDbService()
            {
                _students = new List<Student>
         {
             new Student{IndexNumber ="1", FirstName="Jan", LastName="Kowalski",BirthDate="1980-05-10",IdEnrollment=1 } ,
             new Student{IndexNumber ="2", FirstName="Anna", LastName="Majewski",BirthDate="1980-05-10", IdEnrollment=1} ,
             new Student{ IndexNumber ="3", FirstName="Andrzej", LastName="Andrzejewski",BirthDate="1980-05-10",IdEnrollment=1}

         };

            }
            public IEnumerable<Student> GetStudents()
            {
                return _students;
            }

        IEnumerable<Student> IDbService.GetStudents()
        {
            throw new NotImplementedException();
        }
    }
    }

