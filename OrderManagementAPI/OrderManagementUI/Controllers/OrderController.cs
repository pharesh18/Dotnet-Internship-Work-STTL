using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderManagementUI.Models;
using System.Text;

namespace OrderManagementUI.Controllers
{
    public class OrderController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5148/api/Order");
        private readonly HttpClient _client;

        public OrderController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            List<OrderModel> orderList = new List<OrderModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                orderList = JsonConvert.DeserializeObject<List<OrderModel>>(data);
            }


            List<CustomerModel> customerDetailsList = new List<CustomerModel>();
            foreach (var order in orderList)
            {
                HttpResponseMessage customerResponse = _client.GetAsync("http://localhost:5148/api/Customer/" + order.CustomerId).Result;

                if (customerResponse.IsSuccessStatusCode)
                {
                    string customerData = customerResponse.Content.ReadAsStringAsync().Result;
                    CustomerModel customer = JsonConvert.DeserializeObject<CustomerModel>(customerData);
                    customerDetailsList.Add(customer);
                }
            }

            // Store customer details list in View Bag
            ViewBag.CustomerDetails = customerDetailsList;
            return View(orderList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<CustomerModel> customerList = new List<CustomerModel>();
            HttpResponseMessage response = _client.GetAsync("http://localhost:5148/api/Customer").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                customerList = JsonConvert.DeserializeObject<List<CustomerModel>>(data);
            }

            ViewBag.CustomerDetails = customerList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    TempData["error"] = "Something Went Wrong, Please try again!!";
                    return RedirectToAction("Error", "Home");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            OrderModel order = new OrderModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<OrderModel>(data);
            }


            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(OrderModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    TempData["error"] = "Something Went Wrong, Please try again!!";
                    return RedirectToAction("Error", "Home");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                OrderModel order = new OrderModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    order = JsonConvert.DeserializeObject<OrderModel>(data);
                }


                CustomerModel customerDetails = new CustomerModel();
                HttpResponseMessage customerResponse = _client.GetAsync("http://localhost:5148/api/Customer/" + order.CustomerId).Result;

                if (customerResponse.IsSuccessStatusCode)
                {
                    string customerData = customerResponse.Content.ReadAsStringAsync().Result;
                    CustomerModel customer = JsonConvert.DeserializeObject<CustomerModel>(customerData);
                    customerDetails = customer;
                }

                // Store customer details list in View Bag
                ViewBag.CustomerDetails = customerDetails;

                return View(order);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    TempData["error"] = "Something Went Wrong, Please try again!!";
                    return RedirectToAction("Error", "Home");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            OrderModel order = new OrderModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<OrderModel>(data);
            }


            CustomerModel customerDetails = new CustomerModel();
            HttpResponseMessage customerResponse = _client.GetAsync("http://localhost:5148/api/Customer/" + order.CustomerId).Result;

            if (customerResponse.IsSuccessStatusCode)
            {
                string customerData = customerResponse.Content.ReadAsStringAsync().Result;
                CustomerModel customer = JsonConvert.DeserializeObject<CustomerModel>(customerData);
                customerDetails = customer;
            }

            // Store customer details list in View Bag
            ViewBag.CustomerDetails = customerDetails;

            return View(order);
        }
    }
}
