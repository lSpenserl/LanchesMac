using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //define uma sessão
            //Operador elvis(?) verifica se o campo a esquerda é nulo, caso não seja nulo adiciono a propriedade da direita.
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Obtem ou gera o Id do carrinho
            //coalescência nula ?? verifica o item da esquerda, caso não seja nulo retorna o da direita. 
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //obtem um serviço do tipo do nosso contexto, diferente dos outros , esse sem construtor
            var context = services.GetService<AppDbContext>();

            //Atribui o valor na session
            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context) { CarrinhoCompraId = carrinhoId };
        }

        public void AdicionaAoCarrinho(Lanche lanche)
        {
            var CarrinhoCompraItem = _context.CarrinoCompraItens.SingleOrDefault(
                                    s => s.Lanches.LancheId == lanche.LancheId
                                    && s.CarrinhoCompraId == CarrinhoCompraId);

            if (CarrinhoCompraItem == null)
            {
                CarrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanches = lanche,
                    Quantidade = 1
                };
                _context.CarrinoCompraItens.Add(CarrinhoCompraItem);
            }
            else
            {
                CarrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }

        public int RemoveDoCarrinho(Lanche lanche)
        {
            var CarrinhoCompraItem = _context.CarrinoCompraItens.SingleOrDefault(
                        s => s.Lanches.LancheId == lanche.LancheId
                        && s.CarrinhoCompraId == CarrinhoCompraId);

            var QuantidadeLocal = 0;

            if (CarrinhoCompraItem != null)
            {
                if (CarrinhoCompraItem.Quantidade > 1)
                {
                    CarrinhoCompraItem.Quantidade--;
                    QuantidadeLocal = CarrinhoCompraItem.Quantidade;
                }
                else
                {
                    _context.CarrinoCompraItens.Remove(CarrinhoCompraItem);
                }
            }
            _context.SaveChanges();
            return QuantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItens ?? (CarrinhoCompraItens =
                                            _context.CarrinoCompraItens
                                            .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                                            .Include(s => s.Lanches)
                                            .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinoCompraItens
                                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId);
            _context.CarrinoCompraItens.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinoCompraItens
                        .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                        .Select(c => c.Lanches.Preco * c.Quantidade)
                        .Sum();
            return total;
        }



    }
}
