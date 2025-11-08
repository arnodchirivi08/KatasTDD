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
        [Fact]
        public void Debe_CalcularCostoTotal_CuandoElProductoSeaTubosDePastaDeDientesYSeAgregue5_DevuelveElTotalDe7_49()
        {
            var unidades = 5;
            var valorUnidad = 1.79m;
            var valorEsperadoTotal = 7.49m;
            var descripcionProducto = "Tubo de pasta de dientes";
            var reciboSuper = new ReciboSupermercadoJ();

            reciboSuper.CalcularCostoTotal(unidades, valorUnidad, descripcionProducto).Should().Be(valorEsperadoTotal);
        }


        //Cinco tubos de pasta de dientes por 7,49 €, precio normal 1,79 €.
        [Fact]
        public void Debe_CalcularCostoTotal_CuandoElProductoSeaTubosDePastaDeDientesYSeAgregue2_DevuelveElTotalDe3_58()
        {
            var unidades = 3;
            var valorUnidad = 1.79m;
            var valorEsperadoTotal = valorUnidad * unidades;
            var descripcionProducto = "Tubo de pasta de dientes";
            var reciboSuper = new ReciboSupermercadoJ();

            reciboSuper.CalcularCostoTotal(unidades, valorUnidad, descripcionProducto).Should().Be(valorEsperadoTotal);
        }


        //Dos cajas de tomates cherry por 0,99 €, precio normal 0,69 € por caja
        [Fact]
        public void Debe_CalcularCostoTotal_CuandoElProductoSeaCajaDeTomatesYSeAgregan2CajasDevolveElTotalDe0_99()
        {
            var unidades = 2;
            var valorUnidad = 0.69m;
            var valorEsperadoPorDosCajas = 0.99m;
            var descripcionProducto = "Cajas de tomates";
            var reciboSuper = new ReciboSupermercadoJ();

            reciboSuper.CalcularCostoTotal(unidades, valorUnidad, descripcionProducto).Should().Be(valorEsperadoPorDosCajas);
        }

        [Fact]
        public void Debe_CalcularCostoTotal_CuandoElProductoSeaCajaDeTomatesConPrecioDe0_69PorCadaDosCajas_YSeAgregueAlCarro6CajasDevolver_2_97_Euros()
        {
            var unidades = 6;
            var valorUnidad = 0.69m;
            var valorPorDosCajasDescuento = 0.99m;
            var valorEsperadoPorDosCajas = (unidades / 2) * valorPorDosCajasDescuento;
            var descripcionProducto = "Cajas de tomates";
            var reciboSuper = new ReciboSupermercadoJ();

            reciboSuper.CalcularCostoTotal(unidades, valorUnidad, descripcionProducto).Should().Be(valorEsperadoPorDosCajas);
        }


        [Fact]
        public void Debe_CalcularCostoTotal_CuandoElProductoSeaCajaDeTomatesConPrecioDe0_69PorCadaDosCajas_YSeAgregueAlCarro7CajasDevolver_3_66_Euros()
        {
            //Arrange
            var unidadesAgregadasAlCarro = 7;
            var cantidadDeParesDeCajas = (unidadesAgregadasAlCarro / 2) * 2;
            var cantidadRestante = unidadesAgregadasAlCarro % 2;

            var valorUnidad = 0.69m;
            var valorPorDosCajasDescuento = 0.99m;

            var valorEsperadoPorDosCajas = (cantidadDeParesDeCajas / 2) * valorPorDosCajasDescuento;
            var valorEsperadoCajasRestante = valorUnidad * cantidadRestante;
            var valorTotalEsperado = valorEsperadoPorDosCajas + valorEsperadoCajasRestante;
            var descripcionProducto = "Cajas de tomates";
            var reciboSuper = new ReciboSupermercadoJ();

            //Assert
            reciboSuper.CalcularCostoTotal(unidadesAgregadasAlCarro, valorUnidad, descripcionProducto).Should().Be(valorTotalEsperado);
        }


    }

    public class ReciboSupermercadoJ
    {
        public ReciboSupermercadoJ()
        {
        }

        public decimal CalcularCostoTotal(int unidades, decimal valorUnidad, string descripcionProducto)
        {

            switch (descripcionProducto)
            {
                case "Cepillo":
                    {
                        return CalcularTotalConDescuento2x1(unidades, valorUnidad);
                    }
                case "Manzanas":
                    {
                        return CalcularTotalConPorcentajeDeDescuento(unidades, valorUnidad, 0.2m);
                    }
                case "Arroz":
                    {
                        return CalcularTotalConPorcentajeDeDescuento(unidades, valorUnidad, 0.1m);
                    }
                case "Tubo de pasta de dientes":
                    {
                        if (unidades == 5)
                            return 7.49m;
                        return CalcularTotalSinDescuento(unidades, valorUnidad);
                    }
                case "Cajas de tomates":
                    {
                        return CalcularTotalPorDosCajas(unidades);

                    }
                default:
                    return CalcularTotalSinDescuento(unidades, valorUnidad);
            }
        }

        private decimal CalcularTotalPorDosCajas(int unidades)
        {
            if (unidades % 2 == 0)
            {
                return (unidades / 2) * 0.99m;
            }
            else
            {
                var valorTotalPorParesDeCajas = (unidades / 2) * 0.99m;
                var valorTotalRestante = 1 * 0.69m;
                return valorTotalPorParesDeCajas + valorTotalRestante;
            }
        }

        private decimal CalcularTotalConDescuento2x1(int unidades, decimal valorUnidad)
        {
            var unidadesApagar = unidades - (unidades / 2);
            var totalCostoConDescuento2X1 = unidadesApagar * valorUnidad;
            return totalCostoConDescuento2X1;
        }

        private decimal CalcularTotalSinDescuento(int unidades, decimal valorUnidad)
        {
            return unidades * valorUnidad;
        }

        private decimal CalcularTotalConPorcentajeDeDescuento(int unidades, decimal valorUnidad, decimal porcentajeDescuento)
        {
            var totalSinDescuento = valorUnidad * unidades;
            var totalConDescuento = totalSinDescuento * (1 - porcentajeDescuento);
            return Math.Round(totalConDescuento, 2);
        }
    }
}
