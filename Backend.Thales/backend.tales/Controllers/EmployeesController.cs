using Backend.Business.Contract;
using Backend.Entities.DbSet;
using Backend.Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Thales.Controllers
{
    [Route("api/v1/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeeBusiness _business;

        public EmployeesController(IEmployeeBusiness business)
        {
            _business = business;
        }

        [HttpGet]        
        public async Task<ResponseBase<List<Employee>>> GetEmployes()
        {
            return await _business.GetEmpleoyes();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseBase<Employee>> GetEmployById(int id) { 
           return await  _business.GetEmpleoyesById(id); 
        }

    }
}
