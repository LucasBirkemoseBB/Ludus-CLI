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
        
        public string navn { get; set; }
        public int alder { get; set; }
        public string studieRetning { get; set; }
        public string klassaar { get; set; }
        public int studienummer { get; set; }
        public string studiemail { get; set; }
        
        public Student(string navn, int alder, string retning, string aar, int nummer, string mail) // tom konstruktør
        {
            this.navn = navn;
            this.alder = alder;
            this.studieRetning = retning;
            this.klassaar = aar;
            this.studienummer = nummer;
            this.studiemail = mail;
        }

        public Student() 
        {

        }

        public string Hentoplysninger()
        {
            return $"Navnet er:{navn} : Alder er:{alder} : Studieretning:{studieRetning} : Klasse og Årgang:{klassaar} : Studienummer:{studienummer} : Studiemail{studiemail} \n";
        }

        public void UpdatereFeltStudieretning(string nytFelt)
        {
            studieRetning = nytFelt;
        }

    }// end class

    public class StudentHandler 
    {
        public List<Student> studenter = new List<Student>();
        public Student currentStudent;

        public StudentHandler() 
        {
            loadFromFile("studenter.xml");
        }        

        public void addStudent(Student student)
        {
            studenter.Add(student);
            saveToFile("studenter.xml");
        }

        public void removeStudent(Student student) 
        {
            studenter.Remove(student);
            saveToFile("studenter.xml");
        }

        public Student getExampleStudent() 
        {
            Student student = new Student("", 0, "", "", 0, "");
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
