using WasteControl.Application.Commands.Users.CreateUser;
using System.Net;
using System.Net.Http.Json;
using Shouldly;
using WasteControl.Infrastructure.Security;
using Microsoft.AspNetCore.Identity;
using WasteControl.Core.Entities;
using WasteControl.Application.Commands.Users.SignIn;
using WasteControl.Auth;
using WasteControl.Application.DTO;

namespace WasteControl.Tests.Integration.Controllers
{
    public class UserControllerTest : ControllerTest, IDisposable
    {
        private readonly TestDatabase _testDatabase;
        private const string password = "P@$$w0rd";

        public UserControllerTest(OptionsProvider optionsProvider) : base(optionsProvider)
        {
            _testDatabase = new TestDatabase();
        }

        [Fact]
        public async Task post_user_should_return_created_201_status_code()
        {
            var command = new CreateUserCommand
            {
                Name = "TestowyCR_04",
                Login = "testcr_04",
                Email = "cr04@wp.pl",
                Password = "P@$$w0rd",
                Role = "user"
            };

            var response = await Client.PostAsJsonAsync("users", command);

            response.StatusCode.ShouldBe(HttpStatusCode.Created);
            response.Headers.Location.ShouldNotBeNull();
        }

        [Fact]
        public async Task post_sing_in_should_return_200_status_code_and_jwt()
        {
            var user = await CreateUserAsync();

            var command = new SignInCommand()
            {
                Email = user.Email,
                Password = password
            };
            var response = await Client.PostAsJsonAsync("users/sign-in", command);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            var jwt = await response.Content.ReadFromJsonAsync<JwtDto>();
            jwt.ShouldNotBeNull();
            jwt.AccessToken.ShouldNotBeNullOrWhiteSpace();
        }

        [Fact]
        public async Task get_users_me_should_return_ok_200_status_code_and_user()
        {
            var user = await CreateUserAsync();

            Authorize(user.Id, user.Role);

            var userDto = await Client.GetFromJsonAsync<UserDto>("users/getmetest");
            userDto.ShouldNotBeNull();
            userDto.Id.ShouldBe(user.Id.Value);
        }

        private async Task<User> CreateUserAsync()
        {
            var passwordManager = new PasswordManager();
            
            var user = new User("TestowyCR_ME", "testcr_ME", "crme@wp.pl", passwordManager.Secure(password));
            await _testDatabase.Context.Users.AddAsync(user);
            await _testDatabase.Context.SaveChangesAsync();

            return user;
        }

        public void Dispose()
        {
            _testDatabase?.Dispose();
        }
    }
}

