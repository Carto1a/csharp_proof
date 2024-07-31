using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using ProofIdentity.Application.Services;
using ProofIdentity.Infrastructure.Services;

namespace ProofIdentity.WebApi.Injections;
public static class ServicesInjection
{
    public static IServiceCollection RegisterServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        if (configuration["JWT:Secret"] == null)
            throw new ArgumentNullException(
                "JWT:Secret not found in appsettings.Local.json");

        if (configuration["JWT:Secret"].Length < 32)
            throw new ArgumentException(
                "JWT:Secret must be 32 Length");

        if (configuration["JWT:ValidAudience"] == null)
            throw new ArgumentNullException(
                "JWT:ValidAudience not found in appsettings.Local.json");

        if (configuration["JWT:ValidIssuer"] == null)
            throw new ArgumentNullException(
                "JWT:ValidIssuer not found in appsettings.Local.json");

        var jwtSecret = configuration["JWT:Secret"]!;
        var jwtValidIssuer = configuration["JWT:ValidIssuer"]!;
        var jwtValidAudience = configuration["JWT:ValidAudience"]!;
        var timeToExpire = TimeSpan.FromHours(3);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = jwtValidAudience,
                ValidIssuer = jwtValidIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSecret)),
                ClockSkew = TimeSpan.Zero
            };
        });

        return services
            .AddScoped<ILoginService, IdentityLoginService>()
            .AddSingleton<IAuthenService>(
                new JwtAuthenService(
                    jwtSecret,
                    jwtValidIssuer,
                    jwtValidAudience,
                    timeToExpire))
        ;
    }
}