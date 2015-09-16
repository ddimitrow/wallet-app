using JsonServices;
using JsonServices.Web;

namespace JSONWebAPI
{
    public class Handler : JsonHandler
    {
        public Handler()
        {
            this.service.Name = "JSONWebAPI";
            this.service.Description = "JSON API for android appliation";
            InterfaceConfiguration IConfig = new InterfaceConfiguration("RestAPI", typeof(IServiceAPI), typeof(ServiceAPI));
            this.service.Interfaces.Add(IConfig);
        }

    }
}