using Cw3.Models;
using System.Collections.Generic;


namespace Cw3.DAL
{
    interface IDbService
    {
        public IEnumerable<Student> GetStudents();

    }
}
