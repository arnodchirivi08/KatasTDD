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
            reciboSuper.CalcularCostoTotal(2, 0.99m, "Cepillo").Should().Be(costoTotal);
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
            reciboSuper.CalcularCostoTotal(unidades, valorUnidad, "Cepillo").Should().Be(costoTotal);
        }

        //20 % de descuento en manzanas, precio normal 1,99 € por kilo.
        [Fact]
        public void Debe_CalcultarCostoTotal_DevolverElValorTotalDeUnKiloDeManzanasPor_1_59_Euros()
        {
            var unidad = 1;
            var valorUnidad = 1.99m;
            var costoTotal = 1.59m;
            var descripcionProducto = "Manzanas";
            var reciboSuper = new ReciboSupermercadoJ();

            reciboSuper.CalcularCostoTotal(unidad, valorUnidad, descripcionProducto).Should().Be(costoTotal);
        }
    }

    public class ReciboSupermercadoJ
    {
        public ReciboSupermercadoJ()
        {
        }

        public decimal CalcularCostoTotal(int unidades, decimal valorUnidad, string descripcionProducto)
        {

            if(descripcionProducto == "Cepillo")
            {
                var unidadesApagar = unidades - (unidades / 2);
                var totalCostoConDescuento2X1 = unidadesApagar * valorUnidad;
                return totalCostoConDescuento2X1;
            }

            if(descripcionProducto == "Manzanas")
            {
                var porcentajeDescuento = 0.2m;
                var totalConDescuento = valorUnidad * (1 - porcentajeDescuento);
                return Math.Round(totalConDescuento, 2);
            }

            return 0;
        }
    }
}
