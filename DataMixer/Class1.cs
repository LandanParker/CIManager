using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using DataMixer.Managers;


namespace DataMixer
{

    public class Class1
    {

        public void DoThing()
        {

            string testName = "my name";
            string testEmail = "my emailemail.com";
            
            IAuthContainerModel model = new JWTContainerModel()
            {
                SecretKey = Guid.NewGuid().ToString(),
                Claims = ModelSetter.SetClaims(new TestModel
                {
                    TestPropA = "some prop",
                    TestPropB = "some other prop"
                })
            };

            IAuthService authService = new JWTService(model.SecretKey);

            string token = authService.GenerateToken(model);
            if (!authService.IsTokenValid(token))
            {
                throw new UnauthorizedAccessException();
            }
            else
            {
                List<Claim> claims = authService.GetTokenClaims(token).ToList();
                //Console.WriteLine(string.Join("\n", claims.Select(e=>$"{e.Type} {e.Value}")));
                var obj = ModelSetter.GetModelFromClaims<TestModel>(claims);
                Console.WriteLine(obj);
            }

        }
        
    }

}