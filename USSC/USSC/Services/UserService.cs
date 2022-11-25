using AutoMapper;
using USSC.Dto;
using USSC.Entities;
using USSC.Helpers;

namespace USSC.Services;

// create Entity and db

public class UserService : IUserService
{
    private readonly IEfRepository<UsersEntity> _userRepository;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public UserService(IEfRepository<UsersEntity> userRepository, IConfiguration configuration, IMapper mapper)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _mapper = mapper;
    }

    // сделать хэш и проверку на хэш, а не просто строка
    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _userRepository
            .GetAll()
            .FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

        if (user == null)
        {
            // todo: need to add logger
            return null;
        }

        var token = _configuration.GenerateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    public async Task<AuthenticateResponse> Register(UserModel userModel)
    {
        var user = _mapper.Map<UsersEntity>(userModel);

        var addedUser = await _userRepository.Add(user);

        var response = Authenticate(new AuthenticateRequest
        {
            Email = user.Email,
            Password = user.Password
        });
            
        return response;
    }
        
    public IEnumerable<UsersEntity> GetAll()
    {
        return _userRepository.GetAll();
    }

    public UsersEntity GetById(Guid id)
    {
        return _userRepository.GetById(id);
    }
}