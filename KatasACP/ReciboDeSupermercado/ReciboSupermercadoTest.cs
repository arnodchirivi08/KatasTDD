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
            reciboSuper.CalcularCostoTotal(2, 0.99m).Should().Be(costoTotal);
        }

        [Fact]
        public void Debe_CalcularCostoTotal_DevolveElvalorTotalDe3UnidadesDeCepillosPor1_98_Euros()
        {
            //Arrange
            var unidades = 3;
            var valorUnidad = 0.99m;
            var costoTotal = 1.98m;
            var reciboSuper = new ReciboSupermercadoJ();
            //Act

            //Assert
            reciboSuper.CalcularCostoTotal(unidades, valorUnidad).Should().Be(costoTotal);
        }
    }

    public class ReciboSupermercadoJ
    {
        public ReciboSupermercadoJ()
        {
        }

        public decimal CalcularCostoTotal(int unidades, decimal valorUnidad)
        {
            return 0.99m;
        }
    }
}
