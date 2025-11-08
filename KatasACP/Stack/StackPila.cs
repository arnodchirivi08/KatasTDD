using FluentAssertions;

namespace Katas.Stack
{
    public class StackPilaTest
    {
        private readonly int _tamanioPila = 5;
        private readonly Pila<string> _pila;

        public StackPilaTest()
        {
            _pila = new Pila<string>(_tamanioPila);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(3)]
        //Debe crear el array con el tipo y tamaño brindado en la prueba.
        public void Debe_LaPropiedadTamanio_TenerLaCantidadDeEspacioesDeLaPilaAConstruir(int tamanioPila)
        {
            //Arrange
     
            //Act
            var pila = new Pila<string>(tamanioPila);

            //Assert
            int resultado = pila.Tamanio;
            resultado.Should().Be(tamanioPila);
        }



        // Debe el metodo Peek (mirar)** - Comprueba la parte superior de la pila sin hacer popping
        [Fact]
        public void Debe_ElMetodoObtenerElemento_DevolverElUltimoElementoAgregadoALaPila()
        {
            //Arrange

            //Act
            _pila.AgregarElemento("Manzana");
            _pila.AgregarElemento("Naranja");
            _pila.AgregarElemento("Piña");


            //Assert
            var resultado = _pila.ObtenerElemento();
            resultado.Should().Be("Piña");
        }


        //Debe el metodo Push** - Añadir un elemento a la parte superior de la pila
        [Fact]
        public void Debe_ElMetodoPush_AñadirUnElementoEnLaParteSuperiorDeLaPila()
        {
            //Arrange

            //Act
            _pila.AgregarElemento("Manzana");
            _pila.AgregarElemento("Naranja");

            //Assert
            var resultado = _pila.ObtenerElemento();
            resultado.Should().Be("Naranja");
        }

        //[ ] Debe el metodo Pop** - Quitar un elemento de la parte superior de la pila, devolviéndolo
        [Fact]
        public void Debe_ElMetodoEliminarUltimoElemento_QuitarElElementoEnLaParteSuperiorDeLaPilaYDevolverlo()
        {
            //Arrange

            //Act
            _pila.AgregarElemento("Manzana");
            _pila.AgregarElemento("Naranja");
            _pila.AgregarElemento("Piña");


            //Assert
            var resultado = _pila.EliminarUltimoElemento();
            var valorIndice = _pila.ObtenerElemento();

            resultado.Should().Be("Piña");
            valorIndice.Should().Be("Naranja");
        }

        //[]  Debe el metodo obtenerTamanio retornar el numero de elementos de la pila**
        [Fact]
        public void Debe_ElMetodoObtenerCantidadRetornarseElTamanioDeLaPila()
        {
            //Arrange

            //Act
            _pila.AgregarElemento("Manzana");
            _pila.AgregarElemento("Naranja");

            //Assert
            _pila.ObtenerCantidad().Should().Be(2);
        }

        //[]  Debe la propiedad esVacio retornar true si esta vacio la pila
        [Fact]
        public void Debe_EsVacio_RetornarTrueCuandoEsteVaciaLaPila()
        {
            //Arrange

            //Act

            //Assert
            _pila.EsVacio.Should().BeTrue();
        }

        [Fact]
        public void Debe_EsVacio_RetornarFalseCuandoEsteVaciaLaPila()
        {
            //Arrange

            //Act
            _pila.AgregarElemento("Manzana");

            //Assert
            _pila.EsVacio.Should().BeFalse();
        }
    }

    public class Pila<T>
    {
        private readonly T[] _elementos;
        private int _contador = -1;
        public int Tamanio => _elementos.Length;
        public bool EsVacio => _contador ==-1;

        public Pila(int tamanioPila)
        {
            _elementos = new T[tamanioPila];
        }

        public void AgregarElemento(T elemento)
        {
            _contador++;
            _elementos[_contador] = elemento;
        }

        public T ObtenerElemento()
        {
            return _elementos[_contador];
        }

        public T EliminarUltimoElemento()
        {
        
            var elemento = ObtenerElemento();
            _elementos[_contador] = default(T)!;
            _contador--;
            return elemento;
        }

        public int ObtenerCantidad()
        {
            return _contador +1;
        }
    }
}
