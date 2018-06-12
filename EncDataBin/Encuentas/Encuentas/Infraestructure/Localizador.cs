

namespace Encuentas.Infraestructure
{
    using ModelView;
    public class Localizador
    {
        public MainViewModel Main { get; set; }
        public Localizador()
        {
            Main = new MainViewModel();
        }
    }
}
