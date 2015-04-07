using System;
using System.Collections.Generic;
using AutoMapper;
using Warehouse.Model.Entities;
using Warehouse.Providers.Security;
using Warehouse.ViewModel.Users;

namespace Warehouse.Logic.Services.Users
{
    public class SignUpService : ISignUpService
    {
        private readonly IMappingEngine _mapper;

        public SignUpService(IMappingEngine mapper)
        {
            _mapper = mapper;
        }

        public void CreateUser(SignUpViewModel viewModel)
        {
            var newUser = _mapper.Map<SignUpViewModel, UserProfile>(viewModel);

            var data = new Dictionary<string, object>
            {
                {"FirstName", newUser.FirstName},
                {"LastName", newUser.LastName},
                {"Email", newUser.Email}
            };

            MySqlWebSecurity.CreateUserAndAccount(viewModel.UserName, viewModel.Password, data);

            System.Web.Security.Roles.AddUserToRole(viewModel.UserName,
                viewModel.IsAdmin ? Constants.Roles.Administrator : Constants.Roles.StandartUser);
        }

        public bool IsUserExist(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException("username");
            return MySqlWebSecurity.UserExists(username);
        }

        public bool IsUserEmailInUse(string email, bool isAdmin)
        {
            throw new NotImplementedException();
        }
    }
}