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
            int userId=await auth.CreateUser(new UserModel(){
                Email=email,
                Password="qwer1234"
            });
            Assert.Throws<AuthorizationExeception>(delegate 
            { 
                auth.Authenticate("waffas", "111",false).GetAwaiter().GetResult(); 
            });

            Assert.Throws<AuthorizationExeception>(delegate 
            {
                auth.Authenticate(email, "111",false).GetAwaiter().GetResult();
            });

            Assert.Throws<AuthorizationExeception>(delegate 
            {
                auth.Authenticate("waffas", "qwer1234",false).GetAwaiter().GetResult();
            });

            await auth.Authenticate(email, "qwer1234",false);

        }
    }
}