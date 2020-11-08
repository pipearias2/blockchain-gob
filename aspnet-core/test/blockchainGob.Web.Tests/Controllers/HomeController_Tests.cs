using System.Threading.Tasks;
using blockchainGob.Models.TokenAuth;
using blockchainGob.Web.Controllers;
using Shouldly;
using Xunit;

namespace blockchainGob.Web.Tests.Controllers
{
    public class HomeController_Tests: blockchainGobWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}