namespace IntroduccionAEFCore.DTOs
{
    public class PeliculaCreacionDTO
    {
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
        public List<int> Generos { get; set; } = new List<int>();
        public List<PeliculaActorCreacionDTO> PeliculasActores { get; set; } 
                = new List<PeliculaActorCreacionDTO>();
    }
}
