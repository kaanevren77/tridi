using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Tridi.Business.Interfaces;
using Tridi.Business.Services;
using Tridi.Data.Entities;
using Tridi.Data.Respository;
using Tridi.Data.Respository.Base;
using Tridi.Data.Respository.UnitOfWork;
using Tridi.Mapping;
using Tridi.Middlewaves;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRespositoryBase<>), typeof(RespositoryBase<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IUserRespository, UserRespository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMessageRespository, MessageRespository>();
builder.Services.AddScoped<IMessageService, MessageService>();

builder.Services.AddDbContext<TridiContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(TridiContext)).GetName().Name);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// global exception handler
app.UserCustomException();

app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=App}/{action=Index}/{id?}");

app.Run();
