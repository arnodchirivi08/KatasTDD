using FluentAssertions;
using Microsoft.Extensions.Time.Testing;

namespace Katas.ServicioDeAgenda
{
    public class ServicioDeAgendaTests
    {
        [Fact]
        public void ProcesarTareas_DebeEjecutarTarea_CuandoSonLas9AM()
        {
            //Arrange
            var fake = new FakeTimeProvider();
            var servicio = new ServicioDeAgendaGlobal(fake);

            var horaEventoUtc = new DateTimeOffset(2025, 11, 1, 14, 0, 0, TimeSpan.Zero);

            var horaActual = new DateTimeOffset(2025, 11, 1, 13, 55, 0, TimeSpan.Zero);
            fake.SetUtcNow(horaActual);

            servicio.AgendarTareaEnUtc(horaEventoUtc);

            //ACT
            servicio.ProcesarTareasAgendadas();

            servicio.TareasEjecutadas.Should().Be(0);
            fake.Advance(TimeSpan.FromMinutes(10));

            servicio.ProcesarTareasAgendadas();

            servicio.TareasEjecutadas.Should().Be(1);

            servicio.ProcesarTareasAgendadas();

            servicio.TareasEjecutadas.Should().Be(1);
        }
    }
}
