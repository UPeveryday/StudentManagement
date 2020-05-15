using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StudentManagement.Models;

namespace StudentManagement
{
    public class Startup
    {
        //读取配置信息的配置文件，依赖注入
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
          //  services.AddScoped<IstudentRespository, MockStudentRespository>();//依赖注入 ，每次http请求都是新实例
          //  services.AddSingleton<IstudentRespository, MockStudentRespository>();//依赖注入 单利
            services.AddTransient<IstudentRespository, MockStudentRespository>();//
            services.AddMvc().AddXmlDataContractSerializerFormatters();//包含第三方的服务和功能,添加xml格式
                                                                       // services.AddMvcCore();//不支持josnResult，仅仅包含MVC功能
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            #region 一般配置
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();//开发人员报错页面
            }
            //else if (env.IsStaging() || env.IsProduction()||env.IsEnvironment("UAT"))
            //{
            //    app.UseExceptionHandler("/Error");//如果为其他环境跳转到ERROR页面
            //}
            //获取进程名
            // var process = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            //获取mykey值
            //app.Use(async (context, next) =>
            //{
            //    context.Response.ContentType = "text/plain;charset=utf-8";//防止乱码
            //    await next();

            //});//继续向下执行，next直接向下，再反向执行，可称呼为管道

            //#region 包含 UseDefaultFiles UseStaticFiles  UseDirectoryBrowser 三个中间件
            //app.UseFileServer();
            //#endregion
            #endregion

            #region 两个中间件可以用 userfileserver 代替
            ////创建默认打开首页
            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("50abp.html");

            ////添加默认文件中间件（默认处理 index.html  index.htm  default.html default.htm）静态文件之前
            //app.UseDefaultFiles(defaultFilesOptions);
            ////静态文件中间价（默认处于静态文件夹下）
            app.UseStaticFiles();
            #endregion

            app.UseMvcWithDefaultRoute();//默认路由模板

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("default", "{controller=Home}/{action=Details}/{id?}");
            //});//控制路由

            // app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hosting Env: " + env.EnvironmentName);
            });
        }
    }
}
