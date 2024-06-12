using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Core.Entities;

namespace TestyJednostkowe.Testy
{
    public class AuthControllerTests
    {
        private readonly AuthController _controller;
        private readonly Mock<IConfiguration> _mockConfiguration;

        public AuthControllerTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockConfiguration.Setup(config => config["Jwt:Key"]).Returns("YourSecreesofnesnfoisenfoisenofisefeagfatKey");
            _mockConfiguration.Setup(config => config["Jwt:Issuer"]).Returns("YourIssuer");

            _controller = new AuthController(_mockConfiguration.Object);
        }

        [Fact]
        public void Login_ReturnsUnauthorized_ForInvalidCredentials()
        {
            var userLogin = new UserLogin
            {
                Username = "invaliduser",
                Password = "invalidpassword"
            };

            var result = _controller.Login(userLogin);

            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public void Login_ReturnsToken_ForValidCredentials()
        {
            var userLogin = new UserLogin
            {
                Username = "testuser",
                Password = "password"
            };

            var result = _controller.Login(userLogin) as OkObjectResult;

            Assert.NotNull(result);
            var token = result.Value.GetType().GetProperty("Token").GetValue(result.Value, null);
            Assert.IsType<string>(token);

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token as string);

            Assert.Equal("testuser", jwtToken.Subject);
            Assert.Equal("YourIssuer", jwtToken.Issuer);
            Assert.Equal("YourIssuer", jwtToken.Audiences.First());
        }
    }
}