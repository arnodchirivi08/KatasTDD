using FluentAssertions;
using Katas.Stack;

namespace Katas.ReciboDeSupermercado
{
    public class ReciboSupermercadoTest
    {
        [Fact]
        public void Debe_CalcularCostoTotal_DevolveElvalorTotalDe2UnidadesDeCepillosPorElPrecioDeUnoQueSon_0_99_Euros()
        {
            //Arrange
            var costoTotal = 0.99m;
            var reciboSuper = new ReciboSupermercadoJ();
            //Act


            //Assert
            reciboSuper.CalcularCostoTotal().Should().Be(costoTotal);
        }
    }

    internal class ReciboSupermercadoJ
    {
        public ReciboSupermercadoJ()
        {
        }

        public object CalcularCostoTotal()
        {
            throw new NotImplementedException();
        }
    }
}
