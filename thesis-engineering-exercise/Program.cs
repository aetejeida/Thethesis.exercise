using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using thesis_exercise.data;
using thesis_exercise.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwagger();
builder.Services.AddApplicationServices();

builder.Services.AddDbContext<ThesisExerciseContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddCors();
builder.Services.AddMvc();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c => 
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Thesis Exercise API V1");
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseErrorHandler();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader()
    );

app.Run();
