using Medi_Connect.Data;
using Medi_Connect.Models;
using Medi_Connect.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<MyUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();



builder.Services.AddAuthorization(options =>
{
	//options.AddPolicy("BusinessHoursOnly", policy => 
	//policy.RequireAssertion(context => DateTime.Now.Hour >= 8 && DateTime.Now.Hour <= 24));

	options.AddPolicy("AdminPolicy", policy =>
	policy.RequireClaim(ClaimTypes.Email, "adminmc@mediconnect.com"));

//    options.AddPolicy("AdminPolicy", policy =>
//policy.RequireClaim(ClaimTypes.Email, "admc@mediconnect.com"));


    options.AddPolicy("DoctorPolicy", policy =>
    policy.RequireClaim(ClaimTypes.Email, "doctormc@mediconnect.com"));

 //   options.AddPolicy("DoctorPolicy", policy =>
	//policy.RequireClaim(ClaimTypes.Email, "docmc@mediconnect.com"));


    options.AddPolicy("LaboratorianPolicy", policy =>
    policy.RequireClaim(ClaimTypes.Email, "laboratorianmc@mediconnect.com"));

  //  options.AddPolicy("LaboratorianPolicy", policy =>
  //policy.RequireClaim(ClaimTypes.Email, "labmc@mediconnect.com"));


});


builder.Services.AddScoped<IDoctorRepository, DoctorRepository>(provider =>
	new DoctorRepository(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;"));

builder.Services.AddScoped<ILaboratorianRepository, LaboratorianRepository>(provider =>
    new LaboratorianRepository(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;"));

builder.Services.AddScoped<ILabResultRepository, LabResultRepository>(provider =>
    new LabResultRepository(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;"));

builder.Services.AddScoped<ILabTestRepository, LabTestRepository>(provider =>
    new LabTestRepository(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;"));

builder.Services.AddScoped<IPatientRepository, PatientRepository>(provider =>
    new PatientRepository(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;"));

builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>(provider =>
    new PrescriptionRepository(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;"));

builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();
app.UseAuthorization();
app.UseSession();


app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
