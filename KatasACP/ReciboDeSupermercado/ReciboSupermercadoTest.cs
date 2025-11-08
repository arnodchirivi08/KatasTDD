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

        [Fact]
        public void Debe_CalcularCostoTotal_CuandoElProductoSonCepillosConPrecioDe0_99YSeAgreganAlCarro5Cepillos_De2x1_DevuelveElTotalConDescuentoDe2_97()
        {
            //Arrange
            var unidades = 5;
            var valorUnidad = 0.99m;
            var costoTotal = 2.97m;
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

        //20 % de descuento en manzanas, precio normal 1,99 € por kilo.
        [Fact]
        public void Debe_CalcularCostoTotal_CuandoElProductoSea2BolsasDeManzanasConPrecioDe1_99CadaBolsaYUnDescuentoDel20Porciento_DevuelveElTotalConDescuentoDe3_18()
        {
            var unidad = 2;
            var valorUnidad = 1.99m;
            var costoTotal = 3.18m;
            var descripcionProducto = "Manzanas";
            var reciboSuper = new ReciboSupermercadoJ();

            reciboSuper.CalcularCostoTotal(unidad, valorUnidad, descripcionProducto).Should().Be(costoTotal);
        }



        //Preciso en enunciado
        //10 % de descuento en arroz, precio normal 2,49 € por bolsa.
        [Fact]
      
        public void Debe_CalcularCostoTotal_CuandoElProductoEsArrozConPrecioDe2_49YDescuentoDel10Porciento_DevuelveElTotalConDescuentoDe2_24()
        {
            var unidad = 1;
            var valorUnidad = 2.49m;
            var valorDescuento = 0.10m;
            var valorSinDescuento = unidad * valorUnidad;
            var costoTotal = Math.Round(valorSinDescuento * (1 - valorDescuento), 2);
            var descripcionProducto = "Arroz";
            var reciboSuper = new ReciboSupermercadoJ();

            reciboSuper.CalcularCostoTotal(unidad, valorUnidad, descripcionProducto).Should().Be(costoTotal);
        }

        [Fact]

        public void Debe_CalcularCostoTotal_CuandoElProductoSonDosBolsasDeArrozConPrecioDe2_49CadaUnoYDescuentoDel10Porciento_DevuelveElTotalConDescuentoDe4_48()
        {
            var unidad = 2;
            var valorUnidad = 2.49m;
            var valorDescuento = 0.10m;
            var valorSinDescuento = unidad * valorUnidad;
            var costoTotal = Math.Round(valorSinDescuento * (1 - valorDescuento), 2);
            var descripcionProducto = "Arroz";
            var reciboSuper = new ReciboSupermercadoJ();

            reciboSuper.CalcularCostoTotal(unidad, valorUnidad, descripcionProducto).Should().Be(costoTotal);
        }


        //Cinco tubos de pasta de dientes por 7,49 €, precio normal 1,79 €.
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
                var totalSinDescuento = valorUnidad * unidades;
                var totalConDescuento = totalSinDescuento * (1 - porcentajeDescuento);
                return Math.Round(totalConDescuento, 2);
            }

            if(descripcionProducto == "Arroz")
            {
                var porcentajeDescuento = 0.1m;
                var totalSinDescuento = unidades * valorUnidad;
                var totalConDescuento = totalSinDescuento * (1 - porcentajeDescuento);
                return Math.Round(totalConDescuento, 2);
            }

            return 0;
        }
    }
}
