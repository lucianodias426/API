﻿using Dapper;
using MinhaApiVeiculo.Contracts.Repository;
using MinhaApiVeiculo.DTO;
using MinhaApiVeiculo.Entidade;
using MinhaApiVeiculo.Infraestrutura;

namespace MinhaApiVeiculo.Repository
{
    public class VehicleRepository : Connection, IVehicleRepository
    {
        public class VehicleRepository : ConnectionMovEasy, IVehicleRepository
        {
            public async Task Create(VehicleDTO vehicle)
            {
                string sql = @" INSERT INTO vehicle (LicensePlate, Year, Capacity, Name)
                                          VALUE (@licensePlate, @year, @capacity, @name)";
                await Execute(sql, vehicle);
            }

            public async Task Delete(int id)
            {
                string sql = "DELETE FROM vehicle WHERE Id = @id";
                await Execute(sql, new { id });
            }

            public async Task<IEnumerable<VehicleEntity>> Get()
            {
                string sql = "SELECT * FROM vehicle";
                return await GetConnection().QueryAsync<VehicleEntity>(sql);
            }

            public async Task<VehicleEntity> GetByLicensePlate(string licensePlate)
            {
                string sql = "SELECT * FROM vehicle WHERE LicensePlate = UPPER(@licensePlate)";
                return await GetConnection().QueryFirstAsync<VehicleEntity>(sql, new { licensePlate });
            }

            public async Task Update(VehicleEntity vehicle)
            {
                string sql = @"UPDATE vehicle
                              SET Name = @Name,
                                  LicensePlate = @licenseplate,
                                  Year = @year,
                                  Capacity = @capacity";
                await Execute(sql, vehicle);
            }

        }
    }
}

