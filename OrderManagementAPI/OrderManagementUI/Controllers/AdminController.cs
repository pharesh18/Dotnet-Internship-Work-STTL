using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderManagementUI.Models;
using System.Text;

namespace OrderManagementUI.Controllers
{
    public class AdminController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5148/api/Customer");
        private readonly HttpClient _client;

        public AdminController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            List<CustomerModel> customerList = new List<CustomerModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                customerList = JsonConvert.DeserializeObject<List<CustomerModel>>(data);
            }
            return View(customerList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Admin");
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
            CustomerModel customer = new CustomerModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<CustomerModel>(data);
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(CustomerModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Admin");
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
                CustomerModel customer = new CustomerModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    customer = JsonConvert.DeserializeObject<CustomerModel>(data);
                }
                return View(customer);
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
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "?id=" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Admin");
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
            CustomerModel customer = new CustomerModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<CustomerModel>(data);
            }
            return View(customer);
        }
    }
}
