using AutoMapper;
using GrupparbeteAuktion.Core.Interfaces;
using GrupparbeteAuktion.Domain.DTOs;
using GrupparbeteAuktion.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace GrupparbeteAuktion.Core.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        public void RegisterUser(UserDTO userDto)
        {
            var user = _mapper.Map<Users>(userDto);

            // Kontrollera om användarnamn redan finns
            if (_context.Users.Any(u => u.UserName == user.UserName))
                throw new Exception("Username already exists");

            // Hasha lösenordet innan det sparas
            user.Password = HashPassword(user.Password);

            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void UpdateUser(int id, UserDTO userDto)
        {
            var user = _mapper.Map<Users>(userDto);
            user.UserID = id;

            var existingUser = _context.Users.FirstOrDefault(u => u.UserID == user.UserID);
            if (existingUser == null)
            throw new Exception("User not found");

            // updaterar user details
            existingUser.UserName = user.UserName;
            existingUser.Password = HashPassword(user.Password); // uppdaterar password om använt

            _context.SaveChanges();
        }

        public string AuthenticateUser(UserDTO userDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == userDto.Username);

            if (user == null || !VerifyPassword(userDto.Password, user.Password))
            {
                throw new Exception("Invalid credentials.");
            }

            return GenerateJwtToken(user);
        }

        public Users GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserID == id);
        }

        private string HashPassword(string password)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        private bool VerifyPassword(string password, string passwordHash)
        {
            var hashedPassword = HashPassword(password);
            return hashedPassword == passwordHash;
        }

        private string GenerateJwtToken(Users user)
        {
            var secretKey = _configuration["Jwt:Key"]; // Hämta från appsettings.json
            var issuer = _configuration["Jwt:Issuer"]; // Hämta från appsettings.json
            var audience = _configuration["Jwt:Audience"]; // Hämta från appsettings.json

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };  

            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
