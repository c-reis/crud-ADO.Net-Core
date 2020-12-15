using crud_cadastro.Model;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace crud_cadastro.Data
{
    public class PessoaData
    {
        private string ConexaoString { get; set; }
        private NpgsqlConnection Connection { get; set; }

        public PessoaData(IConfiguration configuration)
        {
            this.ConexaoString = configuration.GetConnectionString("DefaultConnection");
            this.Connection = new NpgsqlConnection(ConexaoString);
        }

        public void Create(PessoasModel pessoa)
        {
            var cmd = new NpgsqlCommand("INSERT INTO pessoas(pessoas_id, nome, endereco, cidade) VALUES (@vPessoas_id, @vNome, @vEndereco, @vCidade);", Connection);

            cmd.Parameters.AddWithValue("vPessoas_id", pessoa.Pessoas_id);
            cmd.Parameters.AddWithValue("vNome", pessoa.Nome);
            cmd.Parameters.AddWithValue("vEndereco", pessoa.Endereco);
            cmd.Parameters.AddWithValue("vCidade", pessoa.Cidade);

            Connection.Open();
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void Update(PessoasModel pessoa)
        {
            var cmd = new NpgsqlCommand("UPDATE pessoas SET nome = @vNome, endereco = @vEndereco, cidade = @vCidade WHERE pessoas_id = @vPessoas_id", Connection);

            cmd.Parameters.AddWithValue("vNome", pessoa.Nome);
            cmd.Parameters.AddWithValue("vEndereco", pessoa.Endereco);
            cmd.Parameters.AddWithValue("vCidade", pessoa.Cidade);
            cmd.Parameters.AddWithValue("vPessoas_id", pessoa.Pessoas_id);

            Connection.Open();
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void Delete(Guid pessoas_id)
        {
            var cmd = new NpgsqlCommand("DELETE FROM pessoas WHERE pessoas_id = @vPessoas_id", Connection);

            cmd.Parameters.AddWithValue("vPessoas_id", pessoas_id);

            Connection.Open();
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public List<PessoasModel> Search()
        {
            List<PessoasModel> busca = new List<PessoasModel>();

            var cmd = new NpgsqlCommand(@"SELECT pessoas_id, nome, endereco, cidade FROM pessoas", Connection);

            Connection.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                busca.Add(new PessoasModel()
                {
                    Pessoas_id = reader.GetGuid("pessoas_id"),
                    Nome = reader.GetString("nome"),
                    Endereco = reader.GetString("cidade")
                });
            }
            Connection.Close();
            return busca;
        }

        public PessoasModel SearchbyId(Guid pessoas_id)
        {
            PessoasModel busca = null;
            
            var cmd = new NpgsqlCommand(@"SELECT pessoas_id, nome, endereco, cidade FROM pessoas WHERE pessoas_id = @vPessoas_id", Connection);
            cmd.Parameters.AddWithValue("vPessoas_id", pessoas_id);

            Connection.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                busca = new PessoasModel()
                {
                    Pessoas_id = reader.GetGuid("pessoas_id"),
                    Nome = reader.GetString("nome"),
                    Endereco = reader.GetString("endereco"),
                    Cidade = reader.GetString("cidade")
                };
            }
            Connection.Close();

            return busca;
        }
    }

}
