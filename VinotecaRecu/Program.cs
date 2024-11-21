using VinotecaRecu.Data.Interfaces;
using VinotecaRecu.Services.Interfaces;
using VinotecaRecu.Services;
using VinotecaRecu.Data.Repositories;
using VinotecaRecu.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
 {
 setupAction.AddSecurityDefinition("AgendaApiBearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
 {
     Type = SecuritySchemeType.Http,
     Scheme = "Bearer",
     Description = "Ac� pegar el token generado al loguearse."
 });
 setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "AgendaApiBearerAuth" } //Tiene que coincidir con el id seteado arriba en la definici�n
                }, new List<string>() }
    });

 });
builder.Services.AddAuthentication("Bearer") //"Bearer" es el tipo de auntenticaci�n que tenemos que elegir despu�s en PostMan para pasarle el token
   .AddJwtBearer(options => //Ac� definimos la configuraci�n de la autenticaci�n. le decimos qu� cosas queremos comprobar. La fecha de expiraci�n se valida por defecto.
   {
       options.TokenValidationParameters = new()
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateIssuerSigningKey = true,
           ValidIssuer = builder.Configuration["Authentication:Issuer"],
           ValidAudience = builder.Configuration["Authentication:Audience"],
           IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
       };
   }
);

builder.Services.AddDbContext<VinotecaRecuContext>(dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:DBConnectionString"]));

builder.Services.AddScoped<IWineRepository, WineRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWineService, WineService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICataRepository, CataRepository>();
builder.Services.AddScoped<CataService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
