using System.Transactions;

namespace resutest;

public class RegisterTests:BaseTest
{
    
    
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task BaseRegistrationTest()
    {
        using (TransactionScope transactionScope = Helper.CreateTransactionScope())
        {
            string email = Guid.NewGuid().ToString()+"@test.com";

            //validate: should not be in the DB
           auth.ValidateEmail(email).GetAwaiter().GetResult();

            // create user
            int userId = await auth.CreateUser(new UserModel(){
                Email = email,
                Password ="qwer1234"
            });

            Assert.Greater(userId, 0);

            var userdalresult = await authDal.GetUser(userId);
            Assert.That(email, Is.EqualTo(userdalresult.Email));
            Assert.NotNull(userdalresult.Salt);

            var userbyemaildalresult = await authDal.GetUser(email);
            Assert.That(email, Is.EqualTo(userbyemaildalresult.Email));

            //validate: should be in the DB
            Assert.Throws<DuplicateEmailException>(()=>auth.ValidateEmail(email).GetAwaiter().GetResult());

            Assert.That(encrypt.HashPassword("qwer1234",userbyemaildalresult.Salt), Is.EqualTo(userbyemaildalresult.Password));

        }
    }
}