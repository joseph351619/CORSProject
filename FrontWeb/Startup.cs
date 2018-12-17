using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FrontWeb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => 
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.WithOrigins("http://localhost:3000")     //設定允許跨域的來源，有多個的話可以用 , 隔開。若要同意所有跨域來源都能呼叫的話，可以把 WithOrigins() 改為 AllowAnyOrigin()。
                          .AllowAnyHeader()                         //允許任何的 Request Header。若要限制 Header，可以改用 WithHeaders，有多個的話可以用 , 隔開。
                          .AllowAnyMethod()                         //允許任何的 HTTP Method。若要限制 Method，可以改用 WithMethods，有多個的話可以用 , 隔開。
                          .AllowCredentials();                      //預設瀏覽器不會發送 CORS 的憑證(如：Cookies)，如果 JavaScript 使用 withCredentials = true 把 CORS 的憑證帶入，ASP.NET Core 這邊也要允取，才可以正常使用。
                });  
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseMvcWithDefaultRoute();

        }
    }
}
