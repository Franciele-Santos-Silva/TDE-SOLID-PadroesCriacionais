namespace Singleton
{
    public class ConfiguracaoSistema
    {
        private static ConfiguracaoSistema? instancia;

        public string NomeSistema { get; private set; }
        public string Versao { get; private set; }

        private ConfiguracaoSistema()
        {
            NomeSistema = "Sistema de Notificações";
            Versao = "1.0";
        }

        public static ConfiguracaoSistema GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new ConfiguracaoSistema();
            }
            return instancia;
        }
    }
}