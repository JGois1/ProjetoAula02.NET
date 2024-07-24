using Dapper;
using ProjetoAula02.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula02.Repositories
{
    /// <summary>
    /// Classe de repositório de banco de dados para produto.
    /// </summary>
    public class ProductRepository
    {
        //atributos
        private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDAula02;Integrated Security=True;";

        /// <summary>
        /// Método para inserir um produto na tabela do banco de dados.
        /// </summary>
        /// <param name="product">Objeto contendo os dados do produto.</param>
        public void Create(Product product)
        {
            //abrindo conexão com o banco de dados
            var connection = new SqlConnection(_connectionString);

            //escrevendo comando sql
            var sql = @"INSERT INTO PRODUCT (ID, NAME, PRICE, QUANTITY) 
                        VALUES (@Id, @Name, @Price, @Quantity)";

            //inserir um produto na tabela do banco de dados
            connection.Execute(sql, product);

            //fechando a conexão
            connection.Close();
        }

        public List<Product> ReadAll()
        {
            //abrindo conexao com o banco de dados 
            var connection = new SqlConnection(_connectionString);

            //escrevendo o comando sql
            var sql = @"
                   SELECT
                        ID, NAME, PRICE, QUANTITY
                    FROM
                        PRODUCT
                    ORDER BY
                        NAME
                    ";

            //executar uma instrução sql para consular produtos no banco de dados
            var result = connection.Query<Product>(sql);

            //fechar a conexao 
            connection.Close();

            //retornando a lista de produtos obitida
            return result.ToList();
        }
    }
}



