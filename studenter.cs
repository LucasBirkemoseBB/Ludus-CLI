using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace StudentSystem
{
    public class Student
    {
        public Student() // tom konstruktør
        {

        }
        public string navn { get; set; }
        public int alder { get; set; }
        public string studieRetning { get; set; }
        public string klassår { get; set; }
        public int studienummer { get; set; }
        public string studiemail { get; set; }
        
        public string Hentoplysninger()
        {
            return $"Navnet er:{navn} : Alder er:{alder} : Studieretning:{studieRetning} : Klasse og Årgang:{klassår} : Studienummer:{studienummer} : Studiemail{studiemail} \n";
        }

        public void UpdatereFeltStudieretning(string nytFelt)
        {
            studieRetning = nytFelt;
        }

    }// end class

    public class StudentHandler 
    {
        public List<Student> studenter = new List<Student>();

        public void addStudent(Student student)
        {
            studenter.Add(student);
        }

        public void removeStudent(Student student) 
        {
            studenter.Remove(student);
        }

        public Student getExampleStudent() 
        {
            Student student = new Student();
            student.alder = 32;
            student.navn = "among balls";
            return student;
        }

        public void saveToFile(string path) 
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));

            using (StringWriter stringWriter = new StringWriter())
            {    
                serializer.Serialize(stringWriter, studenter);
                string xmlString = stringWriter.ToString();
                File.WriteAllText(path, xmlString);
            }
        }

        public void loadFromFile(string path)
        {
            string xmlString = File.ReadAllText(path);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));

            using (StringReader stringReader = new StringReader(xmlString))
            {
                studenter = (List<Student>)serializer.Deserialize(stringReader);
            }
        }
    }

}// end namespace
