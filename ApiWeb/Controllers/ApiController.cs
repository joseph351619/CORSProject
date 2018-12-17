using Microsoft.AspNetCore.Mvc;

namespace ApiWeb
{
    public class ApiController:Controller
    {
        public string ReturnMessage()
        {
            return "Success";
        }
    }
}