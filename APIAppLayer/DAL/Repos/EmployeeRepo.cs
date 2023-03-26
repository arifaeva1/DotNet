using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class EmployeeRepo
    {
        static EmpContext db;
        //its a library of employeee .employess dta can set and get from here
        static EmployeeRepo()
        {
            db = new EmpContext();
        }
        //retun emp list
        public static List<Employee> Get() { 
      return db.Employees.ToList();
     /*List<Employee> emps = new List<Employee>();
            for (int i = 1; i <= 12; i++)
            {
                emps.Add(new Employee() { Id = i, Name = "e-" + i });



            }
            return emps;   */
        
        }
        //pass emp by id 1 emp

        public static Employee Get(int id)
        {
            return db.Employees.Find(id);

        }
        //can add new emp
        public static bool Create(Employee emp) { 
        db.Employees.Add(emp);
            //  return number of affected rows count 
            //if insert thn retuen 1 ortherwise 0
            return db.SaveChanges() > 0;
        
        }
        //update the emp info
        public static bool Update(Employee emp)
        {
         
            var exempp= Get(emp.Id);
            db.Entry(exempp).CurrentValues.SetValues(emp);
         
            return db.SaveChanges() > 0;
        }
       public static bool Delete(int id )
        {
            var exemp= Get (id);
          

            db.Employees.Remove(exemp);
            return db.SaveChanges() > 0;

        }
        
    }

}