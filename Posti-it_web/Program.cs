using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Posti_it_web.Logic.Authentication;
using Posti_it_web.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PostItDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("PostItDB")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication()
            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler> ("BasicAuthentication", null);
builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("BasicAuthentication", new AuthorizationPolicyBuilder("BasicAuthentication").RequireAuthenticatedUser().Build());
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder => builder
    .AllowAnyMethod()
    .AllowAnyOrigin()
    .AllowAnyHeader()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.UseCors("CorsPolicy");
app.MapControllers();

app.Run();
