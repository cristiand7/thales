using Backend.Business.Contract;
using Backend.Business.Implement;
using Backend.Repositories.Contract;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Backend.Test
{
    public class EmployeeBusinessTest
    {
        private IEmployeeBusiness _business;
        private readonly Mock<IEmployeeRepository> _repoMock = new Mock<IEmployeeRepository>();
        

        [SetUp]
        public void Setup()
        {
            _business = new EmployesBusiness(_repoMock.Object);
        }

        [Test]
        public async Task TestGetEmpleyee()
        {
            _repoMock.Setup(x => x.GetEmpleoyes()).Returns(Task.FromResult(new Entities.DTO.ResponseBase<System.Collections.Generic.List<Entities.DbSet.Employee>>() { 
            Code=200,
            Data= new System.Collections.Generic.List<Entities.DbSet.Employee> { 
                new Entities.DbSet.Employee(){ 
                    Id=1,
                    Employee_name="test",                    
                    Employee_salary=1000
                },
                 new Entities.DbSet.Employee(){
                    Id=2,
                    Employee_name="test",
                    Employee_salary=2000
                }
            }
            }));

            var result= await _business.GetEmpleoyes();

            Assert.AreEqual(2, result.Data.Count);
        }
    }
}