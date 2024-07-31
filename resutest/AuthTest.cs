using System.Transactions;

public class AuthTest : BaseTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task AuthRegistrationTest()
    {
        using (TransactionScope transactionScope = Helper.CreateTransactionScope())
        {
            string email= Guid.NewGuid().ToString()+"@test.com";

            // create user
            int userId=await authBL.CreateUser(new UserModel(){
                Email=email,
                Password="qwer1234"
            });
            Assert.Throws<AuthorizationExeception>(delegate 
            { 
                authBL.Authenticate("waffas", "111",false).GetAwaiter().GetResult(); 
            });

            Assert.Throws<AuthorizationExeception>(delegate 
            {
                authBL.Authenticate(email, "111",false).GetAwaiter().GetResult();
            });

            Assert.Throws<AuthorizationExeception>(delegate 
            {
                authBL.Authenticate("waffas", "qwer1234",false).GetAwaiter().GetResult();
            });

            await authBL.Authenticate(email, "qwer1234",false);

        }
    }
}