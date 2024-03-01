using Microsoft.AspNetCore.Mvc;
using OrderManagementUI.Models;
using Newtonsoft.Json;
using System.Text;


namespace OrderManagementUI.Controllers
{
    public class ProductController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5148/api/Product");
        private readonly HttpClient _client;

        public ProductController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            List<ProductModel> productList = new List<ProductModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                productList = JsonConvert.DeserializeObject<List<ProductModel>>(data);
            }
            return View(productList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Product");
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
            ProductModel product = new ProductModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductModel>(data);
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Product");
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
                ProductModel product = new ProductModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<ProductModel>(data);
                }
                return View(product);
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
                    return RedirectToAction("Index", "Product");
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
            ProductModel product = new ProductModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductModel>(data);
            }
            return View(product);
        }
    }
}
