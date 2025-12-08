using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

		public CargoOperationsController(ICargoOperationService cargoOperationService)
		{
			_cargoOperationService = cargoOperationService;
		}

		[HttpGet]
		public IActionResult CargoOperationList()
		{
			var result = _cargoOperationService.TGetAll();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetCargoOperationById(int id)
		{
			var result = _cargoOperationService.TGetById(id);
			return Ok(result);
		}

		[HttpPost]
		public IActionResult CreateCargoOperation(CreateCargoOperationDto dto)
		{
			CargoOperation cargoOperation = new CargoOperation
			{
				Barcode = dto.Barcode,
				Description = dto.Description,
				OperationDate = dto.OperationDate
			};
			_cargoOperationService.TInsert(cargoOperation);
			return Ok("Kargo operasyonu başarıyla eklendi.");
		}

		[HttpDelete]
		public IActionResult RemoveCargoOperation(int id)
		{
			_cargoOperationService.TDelete(id);
			return Ok("Kargo operasyonu başarıyla silindi.");
		}

		[HttpPut]
		public IActionResult UpdateCargoOperation(UpdateCargoOperationDto dto)
		{
			CargoOperation cargoOperation = new CargoOperation
			{
				CargoOperationId = dto.CargoOperationId,
				Barcode = dto.Barcode,
				Description = dto.Description,
				OperationDate = dto.OperationDate
			};
			_cargoOperationService.TUpdate(cargoOperation);
			return Ok("Kargo operasyonu başarıyla güncellendi.");
		}
	}
}
