using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.KataFizzBuzz
{

    public class FizzBuzzTest
    {

    


        [Theory]
        [InlineData(3, "Fizz")]
        [InlineData(6, "Fizz")]
        //[InlineData(99, "Fizz")]
        public void Debe_ObtenerFizzBuzz_DevolverFizzEnMultiploDe3(int indice, string esperado)
        {
            var fizzBuz = new FizzBuzzWhizzBang();

            var resultado = fizzBuz.ObtenerFizzBuzzWhizzBang();

            resultado[indice - 1].Should().Be(esperado);
        }

        [Theory]
        [InlineData(5, "Buzz")]
        [InlineData(10, "Buzz")]
        //[InlineData(55, "Buzz")]
        public void Debe_ObtenerFizzBuzz_DevolverBuzzEnMultiploDe5(int indice, string esperado)
        {
            var fizzBuz = new FizzBuzzWhizzBang();

            var resultado = fizzBuz.ObtenerFizzBuzzWhizzBang();

            resultado[indice - 1].Should().Be(esperado);
        }


        [Theory]
        [InlineData(15, "FizzBuzz")]
        [InlineData(30, "FizzBuzz")]
        [InlineData(45, "FizzBuzz")]
        public void Debe_ObtenerFizzBuzz_DevolverFizzBuzzEnMultiploDeTresYCinco(int indice, string esperado)
        {
            var fizzBuz = new FizzBuzzWhizzBang();

            var resultado = fizzBuz.ObtenerFizzBuzzWhizzBang();

            resultado[indice - 1].Should().Be(esperado);
        }

        [Theory]
        [InlineData(7, "Whizz")]
        [InlineData(49, "Whizz")]
        [InlineData(98, "Whizz")]
        public void Debe_ObtenerFizzBuzzWhizz_DevolverWhizzEnNumerosMultiplosDeSiete(int indice, string esperado)
        {
            var fizzBuzWhizz = new FizzBuzzWhizzBang();

            var resultado = fizzBuzWhizz.ObtenerFizzBuzzWhizzBang();

            resultado[indice - 1].Should().Be(esperado);
        }


        [Theory]
        [InlineData(11, "Bang")]
        [InlineData(22, "Bang")]
        //[InlineData(33, "Bang")]
        public void Debe_ObtenerFizzBuzzWhizz_DevolverBangEnNumerosMultiplosDeOnce(int indice, string esperado)
        {
            var fizzBuzWhizz = new FizzBuzzWhizzBang();

            var resultado = fizzBuzWhizz.ObtenerFizzBuzzWhizzBang();

            resultado[indice - 1].Should().Be(esperado);
        }


        [Theory]
        [InlineData(21, "FizzWhizz")]
        [InlineData(42, "FizzWhizz")]
        [InlineData(63, "FizzWhizz")]
        public void Debe_ObtenerFizzBuzzWhizz_DevolverFizzWhizzEnNumerosMultiplosDeTresYSiete(int indice, string esperado)
        {
            var fizzBuzWhizz = new FizzBuzzWhizzBang();

            var resultado = fizzBuzWhizz.ObtenerFizzBuzzWhizzBang();

            resultado[indice - 1].Should().Be(esperado);
        }

        [Theory]
        [InlineData(33, "FizzBang")]
        [InlineData(99, "FizzBang")]
        public void Debe_ObtenerFizzBuzzWhizz_DevolverFizzBangEnNumerosMultiplosDeTresYOnce(int indice, string esperado)
        {
            var fizzBuzWhizz = new FizzBuzzWhizzBang();

            var resultado = fizzBuzWhizz.ObtenerFizzBuzzWhizzBang();

            resultado[indice - 1].Should().Be(esperado);
        }

        [Fact]
        public void Debe_ObtenerFizzBuzzWhizzBang_TenerEnLaUltimaPosicionDelResultadoLaPalabra_FizzBuzzWhizzBang()
        {
            var esperado = "FizzBuzzWhizzBang";
            var fizzBuzzWhizzBang = new FizzBuzzWhizzBang();

            var resultado = fizzBuzzWhizzBang.ObtenerFizzBuzzWhizzBang();

            var indiceFinal = resultado.Count() - 1;
            Console.WriteLine(indiceFinal);

            resultado[indiceFinal].Should().Be(esperado);
        }


    }





    internal class FizzBuzzWhizzBang
    {

        internal List<object> ObtenerFizzBuzzWhizzBang()
        {
            var resultado = new List<object>();
            for (int i = 1; ; i++)
            {
                string texto = ObtenerTextoFizzBuzzWhizzBang(i);
                resultado.Add(string.IsNullOrEmpty(texto) ? i : texto);
                if(texto == "FizzBuzzWhizzBang")
                {
                    break;
                }
            }

            return resultado;
        }


 

        private static readonly Dictionary<int, string> reglas = new Dictionary<int, string>
        {
             { 3, "Fizz" },
             { 5, "Buzz" },
             { 7, "Whizz"},
             { 11, "Bang" }
        };
        private string ObtenerTextoFizzBuzzWhizzBang(int indice)
        {          

            string texto = "";
            foreach (var item in reglas)
            {
                if (indice % item.Key == 0)
                {
                    texto += item.Value;
                }
            }
            return texto;
        }
    }
}



