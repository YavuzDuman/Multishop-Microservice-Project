using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
		private readonly ICargoDetailService _CargoDetailService;
		public CargoDetailsController(ICargoDetailService CargoDetailService)
		{
			_CargoDetailService = CargoDetailService;
		}

		[HttpGet]
		public IActionResult CargoDetailList()
		{
			var result = _CargoDetailService.TGetAll();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetCargoDetailById(int id)
		{
			var result = _CargoDetailService.TGetById(id);
			return Ok(result);
		}

		[HttpPost]
		public IActionResult CreateCargoDetail(CreateCargoDetailDto dto)
		{
			CargoDetail CargoDetail = new CargoDetail
			{
				Barcode = dto.Barcode,
				CargoCompanyId = dto.CargoCompanyId,
				ReceiverCustomerId = dto.ReceiverCustomer,
				SenderCustomerId = dto.SenderCustomerId

			};
			_CargoDetailService.TInsert(CargoDetail);
			return Ok("Kargo detayları başarıyla oluşturuldu.");
		}

		[HttpDelete]
		public IActionResult RemoveCargoDetail(int id)
		{
			_CargoDetailService.TDelete(id);
			return Ok("Kargo detayları başarıyla silindi.");
		}

		[HttpPut]
		public IActionResult UpdateCargoDetail(UpdateCargoDetailDto dto)
		{
			CargoDetail CargoDetail = new CargoDetail
			{
				CargoDetailId = dto.CargoDetailId,
				Barcode = dto.Barcode,
				CargoCompanyId = dto.CargoCompanyId,
				ReceiverCustomerId = dto.ReceiverCustomer,
				SenderCustomerId = dto.SenderCustomerId
			};
			_CargoDetailService.TUpdate(CargoDetail);
			return Ok("Kargo detayları başarıyla güncellendi.");
		}
	}
}
