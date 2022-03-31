using Api.Extensions;
using Api.Helpers;
using Api.Middleware;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<StoreContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
));


builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddSwaggerDocumentation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
 
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddCors(opt=>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod().AllowAnyMethod().WithOrigins("https://localhost:4200");
    });
});


var app = builder.Build();

// seeds the json data to the database if the database is the empty 
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StoreContext>();
    await Seed.SeedAsync(db);
}
app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.

//ha    
app.UseStatusCodePagesWithReExecute("/errors/{0}"); 
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.UserSwaggerDocumentaion();
app.MapControllers();

app.Run();
