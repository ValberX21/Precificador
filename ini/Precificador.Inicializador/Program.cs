namespace Precificador.Inicializador
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new ColecaoInit().Inicializar();
            new GrupoInit().Inicializar();
            new UnidadeMedidaInit().Inicializar();
        }
    }
}