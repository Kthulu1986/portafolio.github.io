using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositorioProyectos
    {
        List<ProyectoDTO> obtenerProyectos();
    }

    public class RepositorioProyectos: IRepositorioProyectos
    {
        public List<ProyectoDTO> obtenerProyectos()
        {
            return new List<ProyectoDTO>() { new ProyectoDTO
            {
                Titulo = "CCU",
                Descripcion = "Proyectos ODI para migracion de datos",
                Link = "https://www.ccu.cl",
                ImageURL = "/imagenes/Oracle_Org.png"
            },
            new ProyectoDTO
            {
                Titulo = "Syscom",
                Descripcion = "Proyectos principalmente sharepoint",
                Link = "https://www.ccu.cl",
                ImageURL = "/imagenes/senda.png"
            },
            new ProyectoDTO
            {
                Titulo = "Accenture",
                Descripcion = "Proyectos varios",
                Link = "https://www.portalnet.cl",
                ImageURL = "/imagenes/google.png"
            },
            new ProyectoDTO
            {
                Titulo = "Senda",
                Descripcion = "Mantención de sistemas y soporte tecnico",
                Link = "https://www.google.cl",
                ImageURL = "/imagenes/CCU_LOGO.png"
            }
            };
        }
    }
}
