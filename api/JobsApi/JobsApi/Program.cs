using JobsApi.BLL.Services;
using JobsApi.DLL;
using JobsApi.DLL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CORSPolicy",
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddDbContext<JobDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IJobRepository, JobRepository>();
builder.Services.AddTransient<IJobService, JobService>();
var app = builder.Build();

app.UseCors("CORSPolicy");

app.MapGet("/jobs", async (HttpContext httpContext, int _limit = 0) =>
{
    return await httpContext.RequestServices.GetService<IJobService>().GetAllJobs(_limit);
});

app.MapGet("/jobs/{id}", async (string id, HttpContext httpContext) =>
{
    return await httpContext.RequestServices.GetService<IJobService>().GetJobById(id);
});

app.MapPost("/jobs/", async (JobsApi.DLL.Models.Job job, HttpContext httpContext) =>
{
    await httpContext.RequestServices.GetService<IJobService>().SaveJob(job);
});

app.MapPut("/jobs/{id}", async (string id, JobsApi.DLL.Models.Job job, HttpContext httpContext) =>
{
    await httpContext.RequestServices.GetService<IJobService>().UpdateJob(id, job);
});

app.MapDelete("/jobs/{id}", async (string id, HttpContext httpContext) =>
{
    await httpContext.RequestServices.GetService<IJobService>().DeleteJob(id);
});

app.Run();
