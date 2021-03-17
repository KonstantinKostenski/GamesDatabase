using AutoMapper;
using GameDatabase.Helpers;
using GameDatabase.Interfaces;
using GameDatabase.Models;
using GamesDatabaseBusinessLogic.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameDatabase.Services
{
    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<UserApi> _users = new List<UserApi>
        {
            new UserApi { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        };

        private readonly AppSettings _appSettings;
        private  IMapper _mapper;
        private IBusinessLogicUsers _businessLogicUsers;
        private IUtilityService _utilityService;
        public IConfiguration Configuration { get; }

        public UserService(IOptions<AppSettings> appSettings, IMapper mapper, IBusinessLogicUsers businessLogicUsers, IConfiguration configuration, IUtilityService utilityService)
        {
            _appSettings = appSettings.Value;
            _mapper = mapper;
            _businessLogicUsers = businessLogicUsers;
            Configuration = configuration;
            _utilityService = utilityService;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            model.Password = _utilityService.EncodePassword(model.Password);
            var user = await _businessLogicUsers.GetUserByNameAndPassword(model.Username, model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<UserApi> GetAll()
        {
            return _users;
        }

        public UserApi GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        // helper methods

        private string generateJwtToken(UserApi user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = Configuration.GetSection("Secret").GetValue(typeof(string), "APP_SECRET");
            var key = Encoding.ASCII.GetBytes(secret.ToString());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()), new Claim("username", user.Username) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<UserApi> RegisterUserAsync(RegisterViewModel registerUser)
        {
            var user = _mapper.Map<UserApi>(registerUser);
            user.Password = _utilityService.EncodePassword(user.Password);
            var result = await _businessLogicUsers.RegisterUserAsync(user);
            await _businessLogicUsers.SaveChanges();
            return result;
        }

        
    }
}
