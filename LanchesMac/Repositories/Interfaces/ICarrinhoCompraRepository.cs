using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public interface ICarrinhoCompraRepository
    {
        public string CarrinhoCompraId { get; set; }

        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set;}

        //public CarrinhoCompra GetCarrinho(IServiceProvider services);

        public void AdicionaAoCarrinho(Lanche lanche);

        public int RemoveDoCarrinho(Lanche lanche);

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens();

        public void LimparCarrinho();

        public decimal GetCarrinhoCompraTotal();
    }
}
