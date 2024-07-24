using ProjetoAula02.Entities;
using ProjetoAula02.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula02.Controllers
{
    /// <summary>
    /// Controlador para realizar os fluxos de entrada de dados de produtos.
    /// </summary>
    public class ProductController
    {
        /// <summary>
        /// Método para realizar o cadastro de um produto.
        /// </summary>
        public void AddProduct()
        {
            Console.WriteLine("\nCADASTRO DE PRODUTO:");

            var product = new Product();
            product.Id = Guid.NewGuid();

            Console.Write("NOME DO PRODUTO....: ");
            product.Name = Console.ReadLine();

            Console.Write("PREÇO..............: ");
            product.Price = decimal.Parse(Console.ReadLine());

            Console.Write("QUANTIDADE.........: ");
            product.Quantity = int.Parse(Console.ReadLine());

            //Gravar os dados do produto em banco de dados
            var productRepository = new ProductRepository();
            productRepository.Create(product);

            Console.WriteLine("\nPRODUTO CADASTRADO COM SUCESSO!");
        }

        /// <summary>
        /// Método para exibir todos os produtos contidos no banco de dados
        /// </summary>
        public void ListProducts()
        {
            Console.WriteLine("\nCONSULTA DE PRODUTOS:\n");

            //realizando a consulta de produtos no banco de dados
            var productRepository = new ProductRepository();
            var products = productRepository.ReadAll();

            //foreach -> percorrer todos os itens da lista
            foreach (var product in products)
            {
                Console.WriteLine("ID.......: " + product.Id);
                Console.WriteLine("NAME.....: " + product.Name);
                Console.WriteLine("PRICE....: " + product.Price);
                Console.WriteLine("QUANTITY.: " + product.Quantity);
                Console.WriteLine("...");
            }
        }
    }
}



