using StaffManagement1.DataAccess;
using StaffManagement1.Models;
using Microsoft.EntityFrameworkCore;
using StaffManagement1.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using StaffManagement1.Data;
using StaffManagement1.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthStaffContextConnection");builder.Services.AddDbContext<AuthStaffContext>(options =>
    options.UseSqlServer(connectionString));builder.Services.AddDefaultIdentity<AuthUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AuthStaffContext>();var connection = "Data Source=WIN-15NJCBDAUM2;Initial Catalog=StaffDB;Integrated Security=True;";
builder.Services.AddMvc(option=>option.EnableEndpointRouting=false);
builder.Services.AddScoped<IStaffRepository, SqlServerStaffRepository>();
builder.Services.AddDbContextPool<AppDBContext>(option => option.UseSqlServer(connection));

var app = builder.Build();

app.UseStaticFiles();
app.UseMvcWithDefaultRoute();
app.UseAuthentication();
app.Run();
