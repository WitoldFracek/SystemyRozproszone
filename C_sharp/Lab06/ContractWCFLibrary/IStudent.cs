using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ContractWCFLibrary
{
    [ServiceContract]
    public interface IStudent
    {
        [OperationContract]
        string UpperName(Student s);

        [OperationContract]
        int AgeInMonths(Student s);
    }

    [DataContract]
    public class Student
    {
        private string name;
        private string lastName;
        private int age;

        [DataMember]
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
}
