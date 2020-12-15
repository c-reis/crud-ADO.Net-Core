using crud_cadastro.Model;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace crud_cadastro.Data
{
    public class ProdutoData
    {
        private string ConexaoString { get; set; }
        private NpgsqlConnection Connection { get; set; }

        public ProdutoData(IConfiguration configuration)
        {
            this.ConexaoString = configuration.GetConnectionString("DefaultConnection");
            this.Connection = new NpgsqlConnection(ConexaoString);
        }

        public void Create (ProdutosModel produtos)
        {
            var cmd = new NpgsqlCommand("INSERT INTO produtos(produtos_id, descricao, preco, quantidade) VALUES (@vProdutos_id, @vDescricao, @vPreco, @vQuantidade)", Connection);

            cmd.Parameters.AddWithValue("vProdutos_id", produtos.Produtos_id);
            cmd.Parameters.AddWithValue("vDescricao", produtos.Descricao);
            cmd.Parameters.AddWithValue("vPreco", produtos.Preco);
            cmd.Parameters.AddWithValue("vQuantidade", produtos.Quantidade);

            Connection.Open();
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void Update (ProdutosModel produtos)
        {
            var cmd = new NpgsqlCommand("UPDATE produtos SET descricao = @vDescricao, preco = @vPreco, quantidade = @vQuantidade WHERE produtos_id = @vProdutos_id", Connection);

            cmd.Parameters.AddWithValue("vDescricao", produtos.Descricao);
            cmd.Parameters.AddWithValue("vPreco", produtos.Preco);
            cmd.Parameters.AddWithValue("vQuantidade", produtos.Quantidade);
            cmd.Parameters.AddWithValue("vProdutos_id", produtos.Produtos_id);

            Connection.Open();
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void Delete (Guid produto_id)
        {
            var cmd = new NpgsqlCommand("DELETE FROM produtos WHERE produtos_id = @vProdutos_id", Connection);

            cmd.Parameters.AddWithValue("vProdutos_id", produto_id);

            Connection.Open();
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public List<ProdutosModel> Seach()
        {
            List<ProdutosModel> busca = new List<ProdutosModel>();

            var cmd = new NpgsqlCommand(@"SELECT produto_id, descricao, preco, quantidade FROM produtos", Connection);

            Connection.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                busca.Add(new ProdutosModel()
                {
                    Produtos_id = reader.GetGuid("produto_id"),
                    Descricao = reader.GetString("descricao"),
                    Preco = reader.GetDouble("preco"),
                    Quantidade = reader.GetInt32("quantidade")
                });
            }
            Connection.Close();
            return busca;
        }

        public ProdutosModel SearchById(Guid produto_id)
        {
            ProdutosModel busca = null;

            var cmd = new NpgsqlCommand(@"SELECT produtos_id, descricao, preco, quantidade FROM produtos WHERE produtos_id = @vProdutos_id", Connection);
            cmd.Parameters.AddWithValue("vProdutos_id", produto_id);

            Connection.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                busca = new ProdutosModel()
                {
                    Produtos_id = reader.GetGuid("produtos_id"),
                    Descricao = reader.GetString("descricao"),
                    Preco = reader.GetDouble("preco"),
                    Quantidade = reader.GetInt32("quantidade")
                };
            }
            Connection.Close();

            return busca;
        }
    }
}
