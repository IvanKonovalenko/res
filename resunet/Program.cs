var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAuth,Auth>();
builder.Services.AddSingleton<IAuthDAL,AuthDAL>();
builder.Services.AddSingleton<IEncrypt,Encyrpt>();
builder.Services.AddScoped<ICurrentUser,CurrentUser>();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddSingleton<IDbSessionDAL, DbSessionDAL>();
builder.Services.AddScoped<IDbSession, DbSession>();
builder.Services.AddMvc();


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

app.UseRouting();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();

