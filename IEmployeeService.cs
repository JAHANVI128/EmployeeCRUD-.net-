using Employee.Models;

namespace IService
{
    public interface IEmployeeService
    {
        Emp Get(long Id);
        IEnumerable<Emp> GetList();
        void Delete(long id);
        void AddOrUpdate(Emp model);

    }
}
