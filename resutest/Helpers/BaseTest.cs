using Microsoft.AspNetCore.Http;

public class BaseTest
{
    protected IAuthDAL authDal = new AuthDAL();
    protected IEncrypt encrypt = new Encyrpt();
    protected IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
    protected IAuthBL authBL;
    protected IDbSession dbSession;
    public BaseTest()
    {
        dbSession=new DbSession(new DbSessionDAL(), httpContextAccessor);
        authBL = new AuthBL(authDal,encrypt,httpContextAccessor, dbSession); 
    }
}