using ProjetoAula02.Controllers;
using ProjetoAula02.Entities;

namespace ProjetoAula02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var productController = new ProductController();
            productController.AddProduct(); //realizando o cadastro
            productController.ListProducts(); //realizando a consula
        }
    }
}