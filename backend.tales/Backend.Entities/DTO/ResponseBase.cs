using System.Net;

namespace Backend.Entities.DTO
{

    public class ResponseBase<T> : ICloneable
    {  
        public ResponseBase()
        {
            Message = "";
            Code = (int)HttpStatusCode.OK;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }      

      
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int Count { get; set; }        
        public string Status { get; set; }
    }

}
