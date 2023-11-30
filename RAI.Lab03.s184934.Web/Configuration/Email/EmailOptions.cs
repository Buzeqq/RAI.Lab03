using Microsoft.Extensions.Options;

namespace RAI.Lab03.s184934.Web.Configuration.Email;

public class EmailOptionsSetup : IConfigureOptions<EmailOptions>
{
    private readonly IConfiguration _configuration;

    public EmailOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(EmailOptions options)
    {
        _configuration.GetSection("Email").Bind(options);    
    }
}

public class EmailOptions
{
    public string DisplayName { get; init; }
    public string Reply { get; init; }
    public string EmailApiKey { get; init; }
    public string EmailDomain { get; init; }
}