using Employee.Models;

namespace IService
{
    public interface IEmployeeService
    {
        Emp Get(long Id);
        IEnumerable<Emp> List { get; }

        void Delete(long id);
        void AddOrUpdate(Emp model);

    }
}
