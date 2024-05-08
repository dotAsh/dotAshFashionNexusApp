using System.Net;

namespace dotAshFashionNexus.API.Response
{
    public class APIResponse
    {
		public APIResponse(){
			ErrorMessages = new List<string>();
		}
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
       public List<string> ErrorMessages { get; set; }

        public Object Result {  get; set; }
    }
}
