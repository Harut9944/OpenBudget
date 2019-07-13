using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OpenBudget.Application.Infrastructure.Persistence;
using FluentValidation.AspNetCore;
using OpenBudget.WebApi.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using MediatR;

namespace OpenBudget.WebApi
{
  public class Startup
  {
    private readonly IConfiguration configuration;

    public Startup(IConfiguration configuration)
    {
      this.configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddAutoMapper(typeof(IRepository<>).Assembly);

      services.AddMongoDBServices(this.configuration);

      services.AddRepositories();

      services.AddMediatR(typeof(IRepository<>).Assembly);

      services.AddMvc()
        .AddFluentValidation(config =>
          config.RegisterValidatorsFromAssembly(typeof(IRepository<>).Assembly));
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();
    }
  }
}
