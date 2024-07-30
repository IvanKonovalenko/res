using Microsoft.AspNetCore.Http;

public class BaseTest
{
    protected IAuthDAL authDal = new AuthDAL();
    protected IEncrypt encrypt = new Encyrpt();
    protected IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
    protected IAuthBL authBL;
    public BaseTest()
    {
        authBL = new AuthBL(authDal,encrypt,httpContextAccessor); 
    }
}