using System.ServiceModel;

namespace SoapServers
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        public string RegisterUser(User user);
    }
}
