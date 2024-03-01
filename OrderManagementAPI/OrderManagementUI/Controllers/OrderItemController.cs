using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderManagementUI.Models;
using System.Text;

namespace OrderManagementUI.Controllers
{
    public class OrderItemController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5148/api/OrderItem");
        private readonly HttpClient _client;

        public OrderItemController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            List<OrderItemModel> orderItemList = new List<OrderItemModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                orderItemList = JsonConvert.DeserializeObject<List<OrderItemModel>>(data);
            }
            return View(orderItemList);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            List<ProductModel> productList = new List<ProductModel>();
            HttpResponseMessage response = _client.GetAsync("http://localhost:5148/api/Product").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                productList = JsonConvert.DeserializeObject<List<ProductModel>>(data);
            }

            ViewBag.OrderId = id;
            ViewBag.ProductList = productList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderItemModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    OrderModel order = new OrderModel();
                    HttpResponseMessage orderResponse = _client.GetAsync("http://localhost:5148/api/Order/" + model.OrderId).Result;

                    if (orderResponse.IsSuccessStatusCode)
                    {
                        string orderData = orderResponse.Content.ReadAsStringAsync().Result;
                        order = JsonConvert.DeserializeObject<OrderModel>(orderData);
                    }

                    order.TotalAmount = order.TotalAmount + model.UnitPrice;

                    string updateOrderData = JsonConvert.SerializeObject(order);
                    StringContent updateOrderContent = new StringContent(updateOrderData, Encoding.UTF8, "application/json");
                    HttpResponseMessage updateOrderResponse = _client.PutAsync("http://localhost:5148/api/Order", updateOrderContent).Result;


                    List<ProductModel> productList = new List<ProductModel>();
                    HttpResponseMessage productResponse = _client.GetAsync("http://localhost:5148/api/Product").Result;

                    if (productResponse.IsSuccessStatusCode)
                    {
                        string productData = productResponse.Content.ReadAsStringAsync().Result;
                        productList = JsonConvert.DeserializeObject<List<ProductModel>>(productData);
                    }

                    foreach(var singleProduct in productList)
                    {
                        if(singleProduct.ProductId == model.ProductId)
                        {
                            singleProduct.StockQuantity = singleProduct.StockQuantity - model.Quantity;
                            string productUpdateData = JsonConvert.SerializeObject(singleProduct);
                            StringContent productUpdateContent = new StringContent(productUpdateData, Encoding.UTF8, "application/json");
                            HttpResponseMessage updateProductResponse = _client.PutAsync("http://localhost:5148/api/Product", productUpdateContent).Result;
                            break;
                        }
                    }

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
            OrderItemModel orderItem = new OrderItemModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                orderItem = JsonConvert.DeserializeObject<OrderItemModel>(data);
            }
            return View(orderItem);
        }

        [HttpPost]
        public IActionResult Edit(OrderItemModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "OrderItem");
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
                OrderItemModel orderItem = new OrderItemModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    orderItem = JsonConvert.DeserializeObject<OrderItemModel>(data);
                }
                return View(orderItem);
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
                    return RedirectToAction("Index", "OrderItem");
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
            OrderItemModel orderItem = new OrderItemModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                orderItem = JsonConvert.DeserializeObject<OrderItemModel>(data);
            }
            return View(orderItem);
        }
    }
}
