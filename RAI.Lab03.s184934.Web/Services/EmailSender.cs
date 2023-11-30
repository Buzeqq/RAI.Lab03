using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using RAI.Lab03.s184934.Web.Configuration.Email;
using RestSharp;
using RestSharp.Authenticators;

namespace RAI.Lab03.s184934.Web.Services;

public class EmailSender : IEmailSender
{
    private readonly EmailOptions _options;

    public EmailSender(IOptions<EmailOptions> options)
    {
        _options = options.Value;
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var client = new RestClient(new RestClientOptions
        {
            Authenticator = new HttpBasicAuthenticator("api",
                _options.EmailApiKey),
            BaseUrl = new Uri("https://api.mailgun.net/v3")
        });
        var request = new RestRequest();
        request.AddParameter("domain", _options.EmailDomain, ParameterType.UrlSegment);
        request.AddParameter("from", $"{_options.DisplayName} <{_options.Reply}>");
        request.AddParameter("to", email);
        request.AddParameter("subject", subject);
        request.AddParameter("html", htmlMessage);
        request.Method = Method.Post;
        
        var result = await client.ExecuteAsync(request);
        result.ThrowIfError();
    }
}