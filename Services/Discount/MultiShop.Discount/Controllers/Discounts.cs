using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Entities;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Discounts : ControllerBase
    {
        private readonly IDiscountService _discountService;

		public Discounts(IDiscountService discountService)
		{
			_discountService = discountService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllDiscountCouponAsync()
		{
			var result = await _discountService.GetAllCouponAsync();
			return Ok(result);
		}
		[HttpPost]
		public async Task<IActionResult> CreateDiscountCouponAsync([FromBody] CreateCouponDto createCouponDto)
		{
			await _discountService.CreateCouponAsync(createCouponDto);
			return Ok("Kupon başarıyla oluşturuldu");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateDiscountCouponAsync([FromBody] UpdateCouponDto updateCouponDto)
		{
			await _discountService.UpdateCouponAsync(updateCouponDto);
			return Ok("Kupon başarıyla güncellendi");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteDiscountCouponAsync(int id)
		{
			await _discountService.DeleteCouponAsync(id);
			return Ok("Kupon başarıyla silindi");
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdDiscountCouponAsync(int id)
		{
			var result = await _discountService.GetByIdCouponAsync(id);
			return Ok(result);
		}
	}
}
