using Warehouse.ViewModel.Users;

namespace Warehouse.Logic.Services.Users
{
    public interface ISignUpService
    {
        void CreateUser(SignUpViewModel viewModel);
        bool IsUserExist(string username);
        bool IsUserEmailInUse(string email, bool isAdmin);
    }
}