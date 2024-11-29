using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

public class RegisterController:Controller
{
    private readonly IAuth auth;

    public RegisterController(IAuth auth)
    {
        this.auth = auth;
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
            try
            {
                await auth.Register(AuthMapper.MapRegisterViewModelToUserModel(model));
                return Redirect("/");
            }
            catch (DuplicateEmailException)
            {
                ModelState.TryAddModelError("Email","Email уже существует");
            }
            
        }
        return View("Index",model);
    }
}