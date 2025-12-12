using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
		private readonly ILoginService _loginService;
		private readonly ILogger<BasketsController> _logger;

		public BasketsController(IBasketService basketService, ILoginService loginService, ILogger<BasketsController> logger)
		{
			_basketService = basketService;
			_loginService = loginService;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> GetBasketDetail()
		{
			var values = await _basketService.GetBasket(_loginService.GetUserId);
			if (values == null)
				return NotFound();
			return Ok(values); 
		}
		[HttpPost]
		public async Task<IActionResult> SaveMyBasket([FromBody] BasketTotalDto basketTotalDto)
		{
			string userId = _loginService.GetUserId;

			if (string.IsNullOrEmpty(userId))
			{
				// Bu, kullanıcı yetkilendirilmiş olsa bile kimlik bilgisi eksikse çalışır.
				return Unauthorized("Sepet kaydı için geçerli kullanıcı kimliği (UserId) bulunamadı.");
			}

			basketTotalDto.UserId = userId;
			await _basketService.SaveBasket(basketTotalDto);
			return Ok("Sepetteki değişiklikler kaydedildi.");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteBasket()
		{
			await _basketService.DeleteBasket(_loginService.GetUserId);
			return Ok("Sepetiniz başarıyla silindi.");
		}
	}
}
