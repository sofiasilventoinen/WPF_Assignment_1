using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Assignment_1.Models;
using WPF_Assignment_1.Service;
using WPF_Assignment_1.Services;

namespace WPF_Assignment_1
{
    public partial class MainWindow : Window
    {
        
        private readonly ProductService _productService;
        private readonly CustomerService _customerService;
        private readonly OrderService _orderService;


        public MainWindow(ProductService productservice, CustomerService customerService, OrderService orderService)
        {
            InitializeComponent();
            _customerService = customerService;
            _orderService = orderService;
            _productService = productservice;
            PopulateCustomerService().ConfigureAwait(false);
            
        }
        //Lägger till produkt i databas
        public async void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                var productRequest = new ProductRequest
                {
                    
                    Name = tb_name.Text,
                    Description = tb_description.Text,
                    Price = decimal.Parse(tb_price.Text)
                };

                var result = await _productService.CreateAsync(productRequest);
                if (result is OkResult)
                    //tömmer fältet
                cb_products.SelectedIndex = -1;
                tb_name.Text = "";
                tb_description.Text = "";
                tb_price.Text = "";

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
            //till comboboxen
            public async Task PopulateCustomerService()
            {
                var collection = new ObservableCollection<KeyValuePair<string, int>>();
                foreach (var item in await _customerService.GetAllAsync())
                    collection.Add(new KeyValuePair<string, int>(item.Name, item.Id));
                cb_customers.ItemsSource = collection;

                PopulateProductService().ConfigureAwait(false);
            }

            public async Task PopulateProductService()
            {
                var collection = new ObservableCollection<KeyValuePair<string, int>>();
                foreach (var item in await _productService.GetAllAsync())
                    collection.Add(new KeyValuePair<string, int>(item.Name, item.Id));
                cb_products.ItemsSource = collection;
            }

        //Ska skapa en order av kund och produkt. När jag kör programmet märker jag dock att order inte skapas och lyckas inte förstå vad jag missat.
        public async void btn_Save_Order_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var customer = (KeyValuePair<int, string>)cb_customers.SelectedItem;
                var customerId = customer.Key;
                var orderRequest = new OrderRequest
                { 
                    CustomerId= customerId,
                };

            var result = await _orderService.CreateOrderAsync(orderRequest);

                if (result is OkResult)
                {
                    cb_customers.SelectedItem = null!;
                    cb_products.SelectedItem = null!;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
        }
    }
    }

