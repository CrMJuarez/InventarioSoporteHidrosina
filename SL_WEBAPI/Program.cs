var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()||app.Environment.IsProduction())
{
    
    app.UseSwagger();
    app.UseSwaggerUI(c =>

        c.SwaggerEndpoint("v1/swagger.json", "SL_WEBAPI v1"));
   
}




app.UseAuthorization();

app.MapControllers();

app.Run();
