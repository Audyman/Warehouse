using System.Web.Mvc;
using Warehouse.Logic.Services.Users;
using Warehouse.Providers.Security;
using Warehouse.ViewModel.Users;
using Warehouse.WebApp.AppCode;
using Warehouse.WebApp.AppCode.Base;

namespace Warehouse.WebApp.Controllers
{
    public class SignUpController : BaseController
    {
        private readonly ISignUpService _signUpService;

        public SignUpController(ISignUpService signUpService)
        {
            _signUpService = signUpService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new SignUpViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateNewUser(SignUpViewModel viewModel)
        {
            if (!ModelState.IsValid || !viewModel.IsAgreementChecked) return View("Index", viewModel);

            _signUpService.CreateUser(viewModel);
            MySqlWebSecurity.Login(viewModel.UserName, viewModel.Password);

            return RedirectToAction(NameHelper.Home.Index, NameHelper.Home.Controller);
        }
    }
}