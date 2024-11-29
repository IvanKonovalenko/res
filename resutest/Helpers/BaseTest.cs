using Microsoft.AspNetCore.Http;

public class BaseTest
{
    protected IAuthDAL authDal = new AuthDAL();
    protected IEncrypt encrypt = new Encyrpt();
    protected IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
    protected IAuth auth;
    protected IDbSession dbSession;
    public BaseTest()
    {
        dbSession=new DbSession(new DbSessionDAL(), httpContextAccessor);
        auth = new Auth(authDal,encrypt,httpContextAccessor, dbSession); 
    }
}