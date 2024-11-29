using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{
    private readonly IAuth auth;
    public LoginController(IAuth auth)
    {
        this.auth = auth;
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
                int id=await auth.Authenticate(model.Email!, model.Password!,model.RememberMe==true);
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