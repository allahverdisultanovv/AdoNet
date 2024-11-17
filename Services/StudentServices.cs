using AdoNetClass.DAL;
using AdoNetClass.Models;
using System.Data;

namespace AdoNetClass.Services
{
    internal class StudentServices
    {
        private static SQL _sql;
        public StudentServices()
        {
            _sql = new SQL();
        }

        public void Create(Student student)
        {
            int result = _sql.ExecuteCommand($"insert into Students values('{student.Name}','{student.Surname}',{student.Age})");
            if (result > 0)
            {
                Console.WriteLine("Completed");
            }
            else
            {
                Console.WriteLine("Wrong");
            }
        }
        public void GetAll()
        {
            DataTable table = _sql.ExecuteQuery("select * from students");
            List<Student> list = new List<Student>();
            foreach (DataRow item in table.Rows)
            {
                Console.WriteLine($"{item["Name"]}    {item["Surname"]}    {item["Age"]}");
            }
        }
        public void Get(int id)
        {
            DataTable table = _sql.ExecuteQuery($"select * from students where Id={id}");

            Student student = new Student();
            foreach (DataRow item in table.Rows)
            {

                student.Id = (int)item["Id"];
                student.Name = item["Name"].ToString();
                student.Surname = item["Surname"].ToString();
                student.Age = (int)item["Age"];
            };
            Console.WriteLine($"{student.Name}  {student.Surname}  {student.Age}"); ;
        }
        public void Delete(int id)
        {
            int result = _sql.ExecuteCommand($"delete from Students where Id={id}");
            if (result > 0)
            {
                Console.WriteLine("Delted");
            }
            else
            {
                Console.WriteLine("Bele telebe zaten yoxdu");
            }
        }

        public void Update(int id, string name, string surname, int age)
        {
            int result = _sql.ExecuteCommand($"update  Students set Name='{name}',Surname='{surname}',Age={age} where Id={id}");

            if (result > 0)
            {
                Console.WriteLine("updated");
            }
            else { Console.WriteLine("Bu Id li student not have"); }
        }


    }
}
