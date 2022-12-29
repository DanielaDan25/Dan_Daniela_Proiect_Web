using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Dan_Daniela_Proiect_Web.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages((options =>
{
    options.Conventions.AuthorizeFolder("/Shoes");
    options.Conventions.AllowAnonymousToPage("/Shoes/Index");
    options.Conventions.AllowAnonymousToPage("/Shoes/Details");
    options.Conventions.AuthorizeFolder("/Clienti", "AdminPolicy");
}));
builder.Services.AddDbContext<Dan_Daniela_Proiect_WebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Dan_Daniela_Proiect_WebContext") ?? throw new InvalidOperationException("Connection string 'Dan_Daniela_Proiect_WebContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("Dan_Daniela_Proiect_WebContext") ?? throw new InvalidOperationException("Connection string 'Dan_Daniela_Proiect_WebContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<LibraryIdentityContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
