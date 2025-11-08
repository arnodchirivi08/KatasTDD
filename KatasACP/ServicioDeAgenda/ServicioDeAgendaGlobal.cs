using Microsoft.Extensions.Time.Testing;

namespace Katas.ServicioDeAgenda
{
    internal class ServicioDeAgendaGlobal
    {
        private readonly TimeProvider _timeProvider;
        private readonly List<DateTimeOffset> _tareasPendientesUtc = new();
        public int TareasEjecutadas { get; private set; } = 0;

        public ServicioDeAgendaGlobal(TimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }



        internal void AgendarTareaEnUtc(DateTimeOffset horaEventoUtc)
        {
            if(horaEventoUtc > _timeProvider.GetUtcNow())
            {
                _tareasPendientesUtc.Add(horaEventoUtc);
            }
        }

        internal void ProcesarTareasAgendadas()
        {
            var ahoraUtc = _timeProvider.GetUtcNow();

            int tareasProcesadas = _tareasPendientesUtc.RemoveAll(tareaUtc => tareaUtc <= ahoraUtc);

            if(tareasProcesadas > 0)
            {
                TareasEjecutadas += tareasProcesadas;
                Console.WriteLine($"Se procesaron {tareasProcesadas} tareas.");

            }
        }
    }
}