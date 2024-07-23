using Microsoft.AspNetCore.Mvc;

public class RegisterController:Controller
{
    private readonly IAuthBL authBl;

    public RegisterController(IAuthBL authBl)
    {
        this.authBl = authBl;
    }

    [HttpGet]
    [Route("/register")]
    public IActionResult Index()
    {
        return View("Index",new RegisterViewModel());
    }

    [HttpPost]
    [Route("/register")]
    public async Task<IActionResult> IndexSave(RegisterViewModel model)
    {
        if(ModelState.IsValid)
        {
            await authBl.CreateUser(AuthMapper.MapRegisterViewModelToUserModel(model));
            return Redirect("/");
        }
        return View("Index",model);
    }
}