using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{
    private readonly IAuthBL authBl;
    public LoginController(IAuthBL authBl)
    {
        this.authBl = authBl;
    }

    [HttpGet]
    [Route("/login")]
    public IActionResult Index()
    {
        return View("Index",new LoginViewModel());
    }

    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> IndexSave(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                int id=await authBl.Authenticate(model.Email!, model.Password!,model.RememberMe==true);
                return Redirect("/");
            }
            catch(AuthorizationExeception) 
            {
               ModelState.AddModelError("Email","Email или Пароль неверные");
            }        
        }
        return View("Index",model);
    }
}