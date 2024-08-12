using doit.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddProjectServices(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Doit API V1");   
    });
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");

app.UseAuthentication(); // Ensure authentication middleware is added before authorization
app.UseAuthorization();  // Ensure authorization middleware is added after authentication

app.MapControllers();

app.Run();