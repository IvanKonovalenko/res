using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;


public class ProfileController:Controller 
{
    public ProfileController()
    {
        
    }
    [HttpGet]
    [Route("/profile")]
    public IActionResult Index()
    {
        return View(new ProfileViewModel());
    }

    [HttpPost]
    [Route("/profile")]
    public async Task<IActionResult> IndexSave()
    {
        //if(ModelState.IsValid)
        
        var imageData=Request.Form.Files[0];
        if (imageData!=null)
        {

            MD5 mD5hash = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(imageData.FileName);
            byte[] hashBytes=mD5hash.ComputeHash(inputBytes);

            string hash = Convert.ToHexString(hashBytes);

            var dir = "./wwwroot/images/" + hash.Substring(0, 2) + "/" + hash.Substring(0, 4);
            if(!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            string filename = dir + "/" + imageData.FileName;
            using(var stream = System.IO.File.Create(filename))
            {
                await imageData.CopyToAsync(stream);
            }
        }
        
        return View("Index", new ProfileViewModel());
    }
}