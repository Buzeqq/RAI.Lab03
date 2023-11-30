using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Web.Configuration.Email;
using RAI.Lab03.s184934.Web.Data;
using RAI.Lab03.s184934.Web.Services;
using RAI.Lab03.s184934.Web.WebApi;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<UsersDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDbContext<WarehouseDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.ConfigureOptions<EmailOptionsSetup>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<UsersDbContext>();
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Water");
    options.Conventions.AuthorizeFolder("/Company");
    options.Conventions.AuthorizeFolder("/Ion");
    options.Conventions.AuthorizeFolder("/Packaging");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseWebApi();

app.MapRazorPages();

app.Run();