using Backend.Entities.DbSet;
using Backend.Entities.DTO;

namespace Backend.Business.Contract
{
    public interface IEmployeeBusiness
    {   public Task<ResponseBase<List<Employee>>> GetEmpleoyes();
        public Task<ResponseBase<Employee>> GetEmpleoyesById(int id);
    }
}
