using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

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
            var errorModel=await authBl.Validate(model.Email??"");
            if(errorModel!=null)
            {
                ModelState.TryAddModelError("Email",errorModel.ErrorMessage!);
            }
        }
        if(ModelState.IsValid)
        {
            await authBl.CreateUser(AuthMapper.MapRegisterViewModelToUserModel(model));
            return Redirect("/");
        }
        return View("Index",model);
    }
}