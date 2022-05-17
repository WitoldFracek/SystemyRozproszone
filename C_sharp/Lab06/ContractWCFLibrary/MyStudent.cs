using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractWCFLibrary
{
    public class MyStudent : IStudent
    {
        int IStudent.AgeInMonths(Student s)
        {
            return s.Age * 12;
        }

        string IStudent.UpperName(Student s)
        {
            return s.Name.ToUpper();
        }
    }
}
