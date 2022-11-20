using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_Assignment_1.Data;
using WPF_Assignment_1.Models.Entities;
using WPF_Assignment_1.Service;
using WPF_Assignment_1.Services;

namespace WPF_Assignment_1
{
    public partial class App : Application
    {
        public static IHost? app { get; private set; }

        //Det ska bara finnas en instans av MainWindow i applikationen
        public App()
        {
            app = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddScoped<MainWindow>();
                services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sofia\OneDrive\Skrivbord\CMS\Databasteknik\Assignment_1\WPF_Assignment_1\WPF_Assignment_1\Data\wpfapp_sql_db.mdf;Integrated Security=True;Connect Timeout=30"));
                services.AddScoped<ProductService>();
                services.AddScoped<CustomerService>();
                services.AddScoped<OrderService>();

            }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await app!.StartAsync();
            var MainWindow = app.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
