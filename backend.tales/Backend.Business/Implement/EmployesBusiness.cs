using Backend.Business.Contract;
using Backend.Entities.DbSet;
using Backend.Entities.DTO;
using Backend.Repositories.Contract;

namespace Backend.Business.Implement
{
    public class EmployesBusiness : IEmployeeBusiness
    {

        private readonly IEmployeeRepository _repo;

        public EmployesBusiness(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<ResponseBase<List<Employee>>> GetEmpleoyes()
        {

            var result = await _repo.GetEmpleoyes();
            if (result.Code == 200)
                result.Data.ForEach(x => x.Employee_anual_salary = x.Employee_salary * 12);
            return result;


        }

        public async Task<ResponseBase<Employee>> GetEmpleoyesById(int id)
        {
            var result = await _repo.GetEmpleoyesById(id);
            if (result.Data != null)
                result.Data.Employee_anual_salary = result.Data.Employee_salary * 12;
            else result.Code = 404;
            return result;
        }
    }
}
