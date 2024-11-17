using AdoNetClass.DAL;
using AdoNetClass.Models;
using AdoNetClass.Services;

namespace AdoNetClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SQL sql = new SQL();
            Student student = new Student()
            {
                Name = "Allahverdi",
                Surname = "Sultanov",
                Age = 18
            };


            StudentServices services = new StudentServices();
            services.Create(student);

            services.GetAll();
            services.Get(1);
            services.Update(6, "Averdy", "Sultanov", 18);

        }
    }
}
