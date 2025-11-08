using FluentAssertions;

namespace Katas.CancionDeNavidadTest
{
    public class CancionDeNavidadTest
    {
        [Fact]
        public void Debe_ObtenerCancion_RetornarUnaListaDeDoceElementos()
        {
            var cancion = new CancionDeNavidad();

            var resultado = cancion.ObtenerCancion();

            resultado.Count.Should().Be(12);
        }

        //- [ ] Debe en la primera linea de cada estrofa tener la frase "On the [x] day of Christmas" en donde [x] sea el numero ordinal de cada dia
        [Theory]
        [InlineData(0, 0, "On the first day of Christmas")]
        [InlineData(5, 0, "On the sixth day of Christmas")]
        [InlineData(10, 0, "On the eleventh day of Christmas")]
        public void Debe_ObtenerCancion_RetornarEnLaPrimeraLineaDeCadaEstrofa_On_the_x_day_of_Christmas_EnDondeXSeaElNumeroOrdinalDeCadaDia(int indiceEstrofa, int indiceLinea, string primeraLinea)
        {
            var cancion = new CancionDeNavidad();

            var resultado = cancion.ObtenerCancion();

            resultado[indiceEstrofa][indiceLinea].Should().Be(primeraLinea);

        }

        //- [ ] Debe en la segunda linea de cada estrofa tener la frase "My true love sent to me:" 
        [Theory]
        [InlineData(0, 1)]
        [InlineData(4, 1)]
        [InlineData(9, 1)]
        public void Debe_ObtenerCancion_RetornarEnLaSegundaLineaDeCadaEstrofa_My_true_love_sent_to_me(int indiceEstrofa, int indiceLinea)
        {
            var cancion = new CancionDeNavidad();
            var segundaLineaEsperada = "My true love sent to me:";

            var resultado = cancion.ObtenerCancion();

            resultado[indiceEstrofa][indiceLinea].Should().Be(segundaLineaEsperada);
        }

        // - [ ] Debe en la tarcera linea de cada estrofa agregarse la frase que es el regalo de cada dia "[diaCardinal] [regalo]" 
        [Theory]
        [InlineData(0, "A partridge in a pear tree.")]
        [InlineData(1, "Two turtle doves and")]
        [InlineData(2, "Three french hens")]
        public void Debe_ObtenerCancion_RetornarEnLaTerceraLineaDeCadaEstrofaElRegaloDeCadaDiaConNumeroCardinal(int indiceEstrofa, string lineaEsperada)
        {
            var cancion = new CancionDeNavidad();
            var indiceNumeroLineaEvaluada = 2;

            var resultado = cancion.ObtenerCancion();

            resultado[indiceEstrofa][indiceNumeroLineaEvaluada].Should().Be(lineaEsperada);
        }

        //- [ ] Debe la primera estrofa tener tres lineas de la canción con saltos de linea 
        [Theory]
        [InlineData(0, "On the first day of Christmas")]
        [InlineData(1, "My true love sent to me:")]
        [InlineData(2, "A partridge in a pear tree.")]
        public void Deebe_ObtenerCancion_RetornarEnLaPrimeraEstrofaLasLineasEsperadas(int indiceLinea, string lineaEsperada)
        {
            var cancion = new CancionDeNavidad();
            var indiceEstrofaEvaluada = 0;

            var resultado = cancion.ObtenerCancion();

            resultado[indiceEstrofaEvaluada][indiceLinea].Should().Be(lineaEsperada);
        }


        [Theory]
        [InlineData(0, 0, "On the first day of Christmas")]
        [InlineData(0, 1, "My true love sent to me:")]
        [InlineData(0, 2, "A partridge in a pear tree.")]
        [InlineData(1, 0, "On the second day of Christmas")]
        [InlineData(1, 1, "My true love sent to me:")]
        [InlineData(1, 2, "Two turtle doves and")]
        [InlineData(1, 3, "A partridge in a pear tree.")]
        [InlineData(2, 0, "On the third day of Christmas")]
        [InlineData(2, 1, "My true love sent to me:")]
        [InlineData(2, 2, "Three french hens")]
        [InlineData(2, 3, "Two turtle doves and")]
        [InlineData(2, 4, "A partridge in a pear tree.")]
        public void Deebe_ObtenerCancion_RetornarLasTresPrimerasEstrofasConLineasEsperadas(int indiceEstrofa, int indiceLinea, string lineaEsperada)
        {
            var cancion = new CancionDeNavidad();


            var resultado = cancion.ObtenerCancion();

            resultado[indiceEstrofa][indiceLinea].Should().Be(lineaEsperada);
        }

    }

    internal class CancionDeNavidad
    {
        private List<List<string>> _estrofas { get; }
        private readonly string _primeraLinea = "On the [x] day of Christmas";
        private readonly string _segundaLinea = "My true love sent to me:";
        private readonly string[] _diasOrdinales = new string[]
        {
            "first",
            "second",
            "third",
            "fourth",
            "fifth",
            "sixth",
            "seventh",
            "eighth",
            "ninth",
            "tenth",
            "eleventh",
            "twelfth"
        };
        private readonly string[] _regalos = new string[]
        {
            "A partridge in a pear tree.",
            "Two turtle doves and", 
            "Three french hens", 
            "Four calling birds", 
            "Five golden rings", 
            "Six geese a-laying", 
            "Seven swans a-swimming", 
            "Eight maids a-milking",
            "Nine ladies dancing", 
            "Ten lords a-leaping", 
            "Eleven pipers piping", 
            "Twelve drummers drumming"  
        };

        public CancionDeNavidad()
        {
            _estrofas = new List<List<string>>();
        }

        public List<List<string>> ObtenerCancion()
        {
            for (int i=0; i <12; i++)
            {
                var estrofa = new List<string>();                

                var primeraLinea = _primeraLinea.Replace("[x]", _diasOrdinales[i]);

                estrofa.Add(primeraLinea);
                estrofa.Add(_segundaLinea);
          
                for(int j=i; j >= 0; j--)
                {
                   estrofa.Add(_regalos[j].ToString());
                }

 

                _estrofas.Add(estrofa);
            }      

            return _estrofas;
        }

        internal string ObtenerCancionCompleta()
        {
            var resultadoListadoEstrofas = ObtenerCancion();
            var estrofasComoTexto = new List<string>();

            foreach (List<string> estrofa in resultadoListadoEstrofas)
            {
                string estrofaUnida = string.Join("\n", estrofa);
                estrofasComoTexto.Add(estrofaUnida);
            }

            return string.Join("\n\n", estrofasComoTexto);
        }
    }
}
