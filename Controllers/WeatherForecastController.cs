using Microsoft.AspNetCore.Mvc;
using MinhaApiVeiculo.Contracts.Repository;
using MinhaApiVeiculo.DTO;
using MinhaApiVeiculo.Entidade;

namespace MinhaApiVeiculo.Controllers
{
    [ApiController]
    [Route("vehicle")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _vehicleRepository.Get());
        }

        [HttpGet("{lincensePlate}")]
        public async Task<IActionResult> GetByLicensePlate(string licensePlate)
        {
            return Ok(await _vehicleRepository.GetByLicensePlate(licensePlate));
        }

        [HttpPost]
        public async Task<IActionResult> Delete (int id)
        {
            await _vehicleRepository.Delete(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(VehicleEntidade vehicle)
        {
            await _vehicleRepository.Update(vehicle);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Create (VehicleDTO vehicle )
        {
            await _vehicleRepository.Create(vehicle);
            return Ok();
        }
    }
}
