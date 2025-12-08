using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
	[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;
		public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
		{
			_cargoCompanyService = cargoCompanyService;
		}

		[HttpGet]
		public IActionResult CargoCompanyList()
		{
			var result = _cargoCompanyService.TGetAll();
			return Ok(result);
		}

		[HttpPost]
		public IActionResult CreateCargoCompany(CreateCargoCompanyDto dto)
		{
			CargoCompany cargoCompany = new CargoCompany
			{
				CargoCompanyName = dto.CargoCompanyName
			};
			_cargoCompanyService.TInsert(cargoCompany);
			return Ok("Kargo şirketi başarıyla oluşturuldu.");
		}

		[HttpDelete]
		public IActionResult RemoveCargoCompany(int id)
		{
			_cargoCompanyService.TDelete(id);
			return Ok("Kargo şirketi başarıyla silindi.");
		}

		[HttpPut]
		public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto dto)
		{
			CargoCompany cargoCompany = new CargoCompany
			{
				CargoCompanyID = dto.CargoCompanyID,
				CargoCompanyName = dto.CargoCompanyName
			};
			_cargoCompanyService.TUpdate(cargoCompany);
			return Ok("Kargo şirketi başarıyla güncellendi.");
		}

		[HttpGet("{id}")]
		public IActionResult GetCargoCompanyById(int id)
		{
			var result = _cargoCompanyService.TGetById(id);
			return Ok(result);
		}
	}
}
