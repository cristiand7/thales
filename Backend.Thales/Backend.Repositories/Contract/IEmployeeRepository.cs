using Backend.Entities.DbSet;
using Backend.Entities.DTO;

namespace Backend.Repositories.Contract
{
    public interface IEmployeeRepository
    {
        public Task<ResponseBase< List<Employee> >> GetEmpleoyes();
        public  Task<ResponseBase<Employee>> GetEmpleoyesById(int id);

    }
}
