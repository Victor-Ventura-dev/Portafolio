using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositorioProyectos
    {
        List<ProyectoDTO> ObtenerProyectos();
    }
    public class RepositorioProyectos:IRepositorioProyectos
    {
      
        public List<ProyectoDTO> ObtenerProyectos()
        {
            return new List<ProyectoDTO>
            {
                new ProyectoDTO()
                {
                    Titulo ="Grupo Concentra",
                    Descripcion ="Web app ERP garantías de vehículos desarrollado en Blazor",
                    Link ="https://amazon.com",
                    ImagenURL="/Images/dotnet.png"
                },

                new ProyectoDTO()
                {
                    Titulo ="New Tork Times",
                    Descripcion ="Web app noticias  desarrollado en React",
                    Link ="https://nytimes.com",
                    ImagenURL="/Images/dotnet.png"
                },
                new ProyectoDTO()
                {
                    Titulo ="Reddit",
                    Descripcion ="Web app red social desarrollado en Blazor",
                    Link ="https://reddit.com",
                    ImagenURL="/Images/dotnet.png"
                },
                 new ProyectoDTO()
                {
                    Titulo ="Steam",
                    Descripcion ="Web app videojuegos desarrollado en Blazor",
                    Link ="https://steam.com",
                    ImagenURL="/Images/dotnet.png"
                },
            };

        }
    }
}
