using DBSD_00013782_00013940_00014016.DAL.Models;

namespace DBSD_00013782_00013940_00014016.DAL
{
    public interface IEmployeeRepository
    {
        IList<Employee> GetAll();
        void Insert(Employee emp);

        Employee GetById(int id);
        void Update(Employee emp);
        void Delete(int id);
    }
}
