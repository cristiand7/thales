using Backend.Entities.DbSet;
using Backend.Entities.DTO;
using Backend.Repositories.Contract;
using Newtonsoft.Json;
using System.Net;

namespace Backend.Repositories.Implement
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string url_employes= "http://dummy.restapiexample.com/api/v1/employees";
        private readonly string url_employe= "http://dummy.restapiexample.com/api/v1/employee/";

        public async Task<ResponseBase<List<Employee>>> GetEmpleoyes()
        {
            try
            {
                 HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url_employes);
                
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = JsonConvert.DeserializeObject<ResponseBase<List<Employee>>>(responseBody);

                    result.Code = (int)HttpStatusCode.OK;
                    return result;
                }
                else return new ResponseBase<List<Employee>>() { 
                Code=404
                };
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return new ResponseBase<List<Employee>>()
                {
                    Code = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<ResponseBase<Employee>> GetEmpleoyesById(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url_employe+id);

                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK) {
                    var result = JsonConvert.DeserializeObject<ResponseBase<Employee>>(responseBody);
                    result.Code = (int)HttpStatusCode.OK;

                    return result;
                }
                return new ResponseBase<Employee>() { Code=404};

                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);

                return new ResponseBase<Employee>() {
                    Code = (int) HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
