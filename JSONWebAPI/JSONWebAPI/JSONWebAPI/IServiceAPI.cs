using System.Data;

namespace JSONWebAPI
{
    ///
    /// This interface declare the methods need to be implement.
    ///
    public interface IServiceAPI
    {
        void CreateNewAccount(string firstName, string lastName, string userName, string password);
        DataTable GetUserDetails(string userName);
        bool UserAuthentication(string userName, string passsword);
      // will be used for payment db
      // DataTable GetPaymentDetails();
    }
}