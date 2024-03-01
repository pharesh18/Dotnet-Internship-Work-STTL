using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FruitsAPIController : ControllerBase
	{
		private readonly List<string> fruits = new List<string>()
		{
			"Apple",
			"Banana",
			"Mango",
			"Cherry",
			"Grapes"
		};

		[HttpGet]
		public List<string> getAllFruits()
		{
			return fruits;
		}

		[HttpGet("{id}")]
		public string getFruitOnIndex(int id)
		{
			try
			{
			return fruits.ElementAt(id);

			}catch(Exception ex)
			{
				return "" + ex.Message;
			}
		}
	}
}
