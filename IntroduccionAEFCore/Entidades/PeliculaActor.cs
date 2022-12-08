namespace IntroduccionAEFCore.Entidades
{
    public class PeliculaActor
    {
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; } = null!;
        public int ActorId { get; set; }
        public Actor Actor { get; set; } = null!;
        public string Personaje { get; set; } = null!;
        public int Orden { get; set; }
    }
}
