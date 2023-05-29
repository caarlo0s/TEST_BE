using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using BE_TALENTO.ConfigurationServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
                        {
                        options.AddDefaultPolicy(builder =>
                        {
                            builder
                            // .WithOrigins("http://127.0.0.1:5503/")
                            .WithOrigins("*")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .SetIsOriginAllowed(origin => true);
                        });
                    });

builder.Services.AddControllers( 
    opt =>{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig").GetValue<string>("Secret")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>{
    opt.TokenValidationParameters = new TokenValidationParameters{
        ValidateIssuerSigningKey    = true,
        IssuerSigningKey            = key,
        ValidateAudience            = false,
        ValidateIssuer              = false
    };
});

//se añade la configuración de inyección de dependencias
builder.Services.AddInjectionDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>{
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1");
                    c.RoutePrefix = string.Empty; 
                });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseCors();
//se agrega para authentication
app.UseAuthentication();

// app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
