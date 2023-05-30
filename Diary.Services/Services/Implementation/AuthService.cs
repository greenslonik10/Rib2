using AutoMapper;
using Diary.Entity.Models;
using Diary.Repository;
using Diary.Services.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Diary.Services.Abstract;
using Diary.Shared.Exceptions;
using Diary.Shared.ResultCodes;

namespace Diary.Services.Implementation;

public class AuthService : IAuthService
{
    #region Fields
    private readonly IRepository<Student> usersRepository;
    private readonly UserManager<Student> userManager;
    private readonly SignInManager<Student> signInManager;
    private readonly IMapper mapper;
    private readonly string identityUri;

    #endregion
    public AuthService(
        IRepository<Student> usersRepository, UserManager<Student> userManager, SignInManager<Student> signInManager,
        IMapper mapper, IConfiguration configuration)
    {
        this.usersRepository = usersRepository;
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.mapper = mapper;
        identityUri = configuration.GetValue<string>("IdentityServer:Uri");
    }
    public async Task<StudentModel> RegisterUser(RegisterStudentModel model)
    {
        //var existingUser = await userManager.FindByEmailAsync(model.Login);
        var existingUser = usersRepository.GetAll(f => f.Login == model.Login).FirstOrDefault();
        if (existingUser != null)
        {
            throw new Exception("User already exists");
        }

        var user = new Student()
        {
            Login = model.Login,
            UserName = model.Login, // обязательно
            Name = model.Name ?? "",
            PasswordHash = model.PasswordHash,
            ClassID = model.ClassID,
            SchoolID = model.SchoolID,
            EmailConfirmed = true //to make it easier
        };

        var result = await userManager.CreateAsync(user, model.PasswordHash);
        if (!result.Succeeded)
        {
            throw new LogicException(ResultCode.IDENTITY_SERVER_ERROR);
        }

        var createdUser = await userManager.FindByEmailAsync(model.Login);
        return mapper.Map<StudentModel>(createdUser);
    }

    public async Task<IdentityModel.Client.TokenResponse> LoginUser(LoginStudentModel model)
    {
        var user = await userManager.FindByEmailAsync(model.Login);
        if (user == null)
        {
            throw new LogicException(ResultCode.USER_NOT_FOUND);
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        if (!result.Succeeded)
        {
            throw new LogicException(ResultCode.EMAIL_OR_PASSWORD_IS_INCORRECT);
        }

        var client = new HttpClient();
        var disco = await client.GetDiscoveryDocumentAsync(identityUri);
        if (disco.IsError)
        {
            throw new Exception(disco.Error);
        }

        var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = model.ClientId,
            ClientSecret = model.ClientSecret,
            UserName = model.Login,
            Password = model.Password,
            Scope = "api offline_access"
        });

        if (tokenResponse.IsError)
        {
            throw new LogicException(ResultCode.IDENTITY_SERVER_ERROR);
        }

        return tokenResponse;
    }
}