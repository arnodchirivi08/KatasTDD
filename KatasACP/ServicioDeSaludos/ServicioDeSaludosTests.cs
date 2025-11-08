using FluentAssertions;
using Moq;

namespace Katas.ServicioDeSaludos
{
    public class ServicioDeSaludosTests
    {
        [Fact]
        public void ObtenerSaludo_CuandoEsDeManana_DevuelveBuenosDias()
        {
            var horaManana = new DateTime(2025, 10, 27, 9, 0, 0);

            var mockProveedorTiempo = new Mock<IProveedorTiempo>();

            mockProveedorTiempo.Setup(p => p.ObtenerHoraActual()).Returns(horaManana);

            var servicio = new ServicioDeSaludosAcp(mockProveedorTiempo.Object);

            string resultado = servicio.ObtenerSaludo();

            resultado.Should().Be("Buenos días");
        }

        [Fact]
        public void ObtenerSaludo_CuandoEsDeTarde_DevuelvaBuenasTardes()
        {
            var horaTarde = new DateTime(2025, 10, 27, 14, 0, 0);

            var mockProveedorTiempo = new Mock<IProveedorTiempo>();

            mockProveedorTiempo.Setup(tiempo => tiempo.ObtenerHoraActual()).Returns(horaTarde);

            var servicio = new ServicioDeSaludosAcp(mockProveedorTiempo.Object);

            string resultado = servicio.ObtenerSaludo();

            resultado.Should().Be("Buenas tardes");
        }
    }

    internal class ServicioDeSaludosAcp
    {
        private IProveedorTiempo _proveedorTiempo;

        public ServicioDeSaludosAcp(IProveedorTiempo proveedorTiempo)
        {
            _proveedorTiempo = proveedorTiempo;
        }

        internal string ObtenerSaludo()
        {
            var horaActual = _proveedorTiempo.ObtenerHoraActual();

            return horaActual.Hour < 12 ? "Buenos días" : "Buenas tardes";

        }
    }

    public interface IProveedorTiempo
    {
        DateTime ObtenerHoraActual();
    }
}
