using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TodoWebApiDDD.Application.Interfaces;
using TodoWebApiDDD.Application.Services;
using TodoWebApiDDD.Domain.Core.Interfaces.Repositories;
using TodoWebApiDDD.Domain.Core.Interfaces.Services;
using TodoWebApiDDD.Domain.Service.Services;
using TodoWebApiDDD.Infrastructure.CrossCutting.Adapter.Interfaces;
using TodoWebApiDDD.Infrastructure.CrossCutting.Adapter.Map;
using TodoWebApiDDD.Infrastructure.Data;
using TodoWebApiDDD.Infrastructure.Data.Interfaces;
using TodoWebApiDDD.Infrastructure.Repository;

namespace TodoWebApiDDD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IUserApplicationService, UserApplicationService>();
            services.AddTransient<IUserApplicationService, UserApplicationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserMapper, UserMapper>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ICategoryApplicationService, CategoryApplicationService>();
            services.AddTransient<ICategoryApplicationService, CategoryApplicationService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICategoryMapper, CategoryMapper>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<ITodoListApplicationService, TodoListApplicationService>();
            services.AddTransient<ITodoListApplicationService, TodoListApplicationService>();
            services.AddTransient<ITodoListService, TodoListService>();
            services.AddTransient<ITodoListMapper, TodoListMapper>();
            services.AddTransient<ITodoListRepository, TodoListRepository>();

            services.AddTransient<ITaskApplicationService, TaskApplicationService>();
            services.AddTransient<ITaskApplicationService, TaskApplicationService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITaskMapper, TaskMapper>();
            services.AddTransient<ITaskRepository, TaskRepository>();


            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("TodoWebApiDDD.API")));

            services.AddTransient<IDataService, DataService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var dataservice = serviceProvider.GetRequiredService<IDataService>();
            dataservice.InitializeDB(serviceProvider);
        }
    }
}
