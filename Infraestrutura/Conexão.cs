﻿using Dapper;
using MySql.Data.MySqlClient;


namespace MinhaApiVeiculo.Interface
{
    public class Conexão
    {
        protected string connectionString = "Server=localhost;Database=moveasy;User=root;Password=root;";

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        protected async Task<int> Execute(string sql, object obj)
        {
            using (MySqlConnection con = GetConnection())
            {
                return await con.ExecuteAsync(sql, obj);
            }
        }
    }
}
