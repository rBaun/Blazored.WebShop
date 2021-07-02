using Blazored.WebShop.Client.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.WebShop.Application.Plugins.Persistence;
using Blazored.WebShop.Application.Plugins.Presentation;
using Blazored.WebShop.Application.Plugins.StateManagement;
using Blazored.WebShop.Application.UseCases.AdminPortal.OrderDetails;
using Blazored.WebShop.Application.UseCases.AdminPortal.OrderDetails.Interfaces;
using Blazored.WebShop.Application.UseCases.AdminPortal.OutstandingOrders;
using Blazored.WebShop.Application.UseCases.AdminPortal.OutstandingOrders.Interfaces;
using Blazored.WebShop.Application.UseCases.AdminPortal.ProcessedOrders;
using Blazored.WebShop.Application.UseCases.AdminPortal.ProcessedOrders.Interfaces;
using Blazored.WebShop.Application.UseCases.CustomerPortal.OrderConfirmation;
using Blazored.WebShop.Application.UseCases.CustomerPortal.OrderConfirmation.Interfaces;
using Blazored.WebShop.Application.UseCases.CustomerPortal.PlaceOrder;
using Blazored.WebShop.Application.UseCases.CustomerPortal.PlaceOrder.Interfaces;
using Blazored.WebShop.Application.UseCases.CustomerPortal.SearchProduct;
using Blazored.WebShop.Application.UseCases.CustomerPortal.SearchProduct.Interfaces;
using Blazored.WebShop.Application.UseCases.CustomerPortal.ShoppingCart;
using Blazored.WebShop.Application.UseCases.CustomerPortal.ShoppingCart.Interfaces;
using Blazored.WebShop.Application.UseCases.CustomerPortal.ViewProduct;
using Blazored.WebShop.Application.UseCases.CustomerPortal.ViewProduct.Interfaces;
using Blazored.WebShop.Core.Business.Services;
using Blazored.WebShop.Core.Business.Services.Interfaces;
using Blazored.WebShop.Data.Repositories;
using Blazored.WebShop.StateStore.DI;

namespace Blazored.WebShop.Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthentication("Blazored.WebShop.CookieAuth")
                .AddCookie("Blazored.WebShop.CookieAuth", config =>
                {
                    config.Cookie.Name = "Blazored.WebShop.CookieAuth";
                    config.LoginPath = "/authenticate";
                });

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();

            services.AddScoped<IShoppingCart, ShoppingCart.LocalStorage.ShoppingCart>();
            services.AddScoped<IShoppingCartStateStore, ShoppingCartStateStore>();

            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ISearchProduct, SearchProduct>();
            services.AddTransient<IViewProduct, ViewProduct>();
            services.AddTransient<IAddProductToCart, AddProductToCart>();
            services.AddTransient<IViewShoppingCart, ViewShoppingCart>();
            services.AddTransient<IRemoveProduct, RemoveProduct>();
            services.AddTransient<IUpdateQuantity, UpdateQuantity>();
            services.AddTransient<IPlaceOrder, PlaceOrder>();
            services.AddTransient<IViewOrderConfirmation, ViewOrderConfirmation>();

            services.AddTransient<IViewOrdersCompleted, ViewOrdersCompleted>();
            services.AddTransient<IProcessOrder, ProcessOrder>();
            services.AddTransient<IViewOrderDetails, ViewOrderDetails>();
            services.AddTransient<IViewOrdersInProgress, ViewOrdersInProgress>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
