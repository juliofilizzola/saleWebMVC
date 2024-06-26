using Microsoft.EntityFrameworkCore;
using SaleWebMVC.Controllers;
using SaleWebMVC.Data;
using SaleWebMVC.Service;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContextPool<SaleWebMvcContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("SaleWebMVCContext");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Service Scoped
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<SaleRecordService>();
builder.Services.AddScoped<DepartmentsController>();
builder.Services.AddScoped<SellerController>();
builder.Services.AddScoped<SaleRecordController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
new SeedingService().Seed(app);
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();