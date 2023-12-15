 using MinhaApiVeiculo.DTO;
 using MinhaApiVeiculo.Entidade;


namespace MinhaApiVeiculo.Contracts.Repository
{
    public interface IVehicleRepository
    {
        Task Add(VehicleDTO vehicle);

        Task Update(VeiculoEntidade vehicle);

        Task Delete(int id);

        Task<VehicleEntidade> GetById(int id);

        Task<IEnumerable<VehicleDTOGet();
    }
}
