using Microsoft.EntityFrameworkCore;

namespace IntroduccionAEFCore.Entidades.Seeding
{
    public class SeedingInicial
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var samuelLJackson = new Actor()
            {
                Id = 2,
                Nombre = "Samuel L. Jackson",
                FechaNacimiento = new DateTime(1948, 12, 21),
                Fortuna = 15000
            };
            var RobertDowneyJunior = new Actor()
            {
                Id = 3,
                Nombre = "Robert Downey Jr.",
                FechaNacimiento = new DateTime(1965, 4, 4),
                Fortuna = 18000
            };

            modelBuilder.Entity<Actor>().HasData(samuelLJackson, RobertDowneyJunior);

            var avengers = new Pelicula()
            {
                Id = 2,
                Titulo = "Avengers Endgame",
                FechaEstreno = new DateTime(2019, 4, 22)
            };
            var spiderManNWH = new Pelicula()
            {
                Id = 3,
                Titulo = "Spider-Man: No Way Home",
                FechaEstreno = new DateTime(2021, 12, 13)
            };
            var spiderManSpiderVerse2 = new Pelicula()
            {
                Id = 4,
                Titulo = "Spider-Man: Across the Spider-Verse (Part One)",
                FechaEstreno = new DateTime(2022, 10, 7)
            };

            modelBuilder.Entity<Pelicula>().HasData(avengers, spiderManNWH, spiderManSpiderVerse2);

            var comentarioAvengers = new Comentario()
            {
                Id = 2,
                Recomendar = true,
                Contenido = "Muy buena!!!",
                PeliculaId = avengers.Id
            };
            var comentarioAvengers2 = new Comentario()
            {
                Id = 3,
                Recomendar = true,
                Contenido = "Dura dura",
                PeliculaId = avengers.Id
            };
            var comentarioNWH = new Comentario()
            {
                Id = 4,
                Recomendar = false,
                Contenido = "no debieron hacer eso...",
                PeliculaId = spiderManNWH.Id
            };

            modelBuilder.Entity<Comentario>().HasData(comentarioAvengers, comentarioAvengers2, comentarioNWH);

            // muchos a muchos con salto (esto es poquito avanzado)

            var tablaGeneroPelicula = "GeneroPelicula";
            var generoIdPropiedad = "GenerosId";
            var peliculaIdPropiedad = "PeliculasId";

            var cienciaFiccion = 5;
            var animacion = 6;

            modelBuilder.Entity(tablaGeneroPelicula).HasData(
                new Dictionary<string, object>
                {
                    [generoIdPropiedad] = cienciaFiccion,
                    [peliculaIdPropiedad] = avengers.Id
                },

                new Dictionary<string, object>
                {
                    [generoIdPropiedad] = cienciaFiccion,
                    [peliculaIdPropiedad] = spiderManNWH.Id
                },

                new Dictionary<string, object>
                {
                    [generoIdPropiedad] = animacion,
                    [peliculaIdPropiedad] = spiderManSpiderVerse2.Id
                }

                );

            // muchos a muchos sin salto

            var samuelLJacksonSpiderManNWH = new PeliculaActor
            {
                ActorId = samuelLJackson.Id,
                PeliculaId = spiderManNWH.Id,
                Orden = 1,
                Personaje = "Nick Fury"
            };

            var samuelLJacksonAvengers = new PeliculaActor
            {
                ActorId = samuelLJackson.Id,
                PeliculaId = avengers.Id,
                Orden = 2,
                Personaje = "Nick Fury"
            };

            var robertDowneyJuniorAvengers = new PeliculaActor
            {
                ActorId = RobertDowneyJunior.Id,
                PeliculaId = avengers.Id,
                Orden = 1,
                Personaje = "Iron Man"
            };

            modelBuilder.Entity<PeliculaActor>().
                HasData(samuelLJacksonSpiderManNWH, 
                samuelLJacksonAvengers, 
                robertDowneyJuniorAvengers);

        }
    }
}
