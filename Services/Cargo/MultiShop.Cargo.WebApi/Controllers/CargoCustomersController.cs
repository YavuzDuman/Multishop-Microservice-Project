using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

		public CargoCustomersController(ICargoCustomerService cargoCustomerService)
		{
			_cargoCustomerService = cargoCustomerService;
		}
		[HttpGet]
		public IActionResult CargoCustomerList()
		{
			var result = _cargoCustomerService.TGetAll();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetCargoCustomerById(int id)
		{
			var result = _cargoCustomerService.TGetById(id);
			return Ok(result);
		}

		[HttpPost]
		public IActionResult CreateCargoCustomer(CreateCargoCustomerDto dto)
		{
			CargoCustomer cargoCustomer = new CargoCustomer
			{
				Name = dto.Name,
				Surname = dto.Surname,
				Phone = dto.Phone,
				Email = dto.Email,
				District = dto.District,
				City = dto.City,
				Address = dto.Address
			};
			_cargoCustomerService.TInsert(cargoCustomer);
			return Ok("Kargo müşterisi başarıyla oluşturuldu.");
		}

		[HttpDelete]
		public IActionResult RemoveCargoCustomer(int id)
		{
			_cargoCustomerService.TDelete(id);
			return Ok("Kargo müşterisi başarıyla silindi.");
		}

		[HttpPut]
		public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto dto)
		{
			CargoCustomer cargoCustomer = new CargoCustomer
			{
				CargoCustomerID = dto.CargoCustomerID,
				Name = dto.Name,
				Surname = dto.Surname,
				Phone = dto.Phone,
				Email = dto.Email,
				District = dto.District,
				City = dto.City,
				Address = dto.Address
			};
			_cargoCustomerService.TUpdate(cargoCustomer);
			return Ok("Kargo müşterisi başarıyla güncellendi.");
		}

	}
}
