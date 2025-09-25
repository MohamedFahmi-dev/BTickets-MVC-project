using BTickets.Data.Enum;
using BTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace BTickets.Data
{
    public  class Seeding()
    {
     private readonly AppDbContext context;

        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Cinema>()
                .HasData(
                    new Cinema()
                    {
                        Id = 1,
                        Name = "Cinema 1",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                        Description = "This is the description of the first cinema"
                    },
                    new Cinema()
                    {
                        Id = 2,
                        Name = "Cinema 2",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                        Description = "This is the description of the first cinema"
                    },
                    new Cinema()
                    {
                        Id = 3,
                        Name = "Cinema 3",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                        Description = "This is the description of the first cinema"
                    },
                    new Cinema()
                    {
                        Id = 4,
                        Name = "Cinema 4",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                        Description = "This is the description of the first cinema"
                    },
                    new Cinema()
                    {
                        Id = 5,
                        Name = "Cinema 5",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                        Description = "This is the description of the first cinema"
                    });

            builder.Entity<Actor>()
                .HasData(
                    new Actor()
                    {
                        Id = 1,
                        FullName = "Actor 1",
                        Bio = "This is the Bio of the first actor",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"
                    },
                    new Actor()
                    {
                        Id = 2,
                        FullName = "Actor 2",
                        Bio = "This is the Bio of the second actor",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                    },
                    new Actor()
                    {
                        Id = 3,
                        FullName = "Actor 3",
                        Bio = "This is the Bio of the third actor",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                    },
                    new Actor()
                    {
                        Id = 4,
                        FullName = "Actor 4",
                        Bio = "This is the Bio of the fourth actor",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                    },
                    new Actor()
                    {
                        Id = 5,
                        FullName = "Actor 5",
                        Bio = "This is the Bio of the fifth actor",
                        ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                    });

            builder.Entity<Producer>()
                .HasData(
                    new Producer()
                    {
                        Id = 1,
                        FullName = "Producer 1",
                        Bio = "This is the Bio of the first producer",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"
                    },
                    new Producer()
                    {
                        Id = 2,
                        FullName = "Producer 2",
                        Bio = "This is the Bio of the second producer",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                    },
                    new Producer()
                    {
                        Id = 3,
                        FullName = "Producer 3",
                        Bio = "This is the Bio of the third producer",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                    },
                    new Producer()
                    {
                        Id = 4,
                        FullName = "Producer 4",
                        Bio = "This is the Bio of the fourth producer",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                    },
                    new Producer()
                    {
                        Id = 5,
                        FullName = "Producer 5",
                        Bio = "This is the Bio of the fifth producer",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                    });

            builder.Entity<Movie>()
                .HasData(
                    new Movie()
                    {
                        Id = 1,
                        Name = "Life",
                        Description = "This is the Life movie description",
                        Price = 39.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                        StartDate = new DateTime(2024, 1, 1),
                        EndDate = new DateTime(2024, 6, 1),
                        CinemaId = 3,
                        ProducerId = 3,
                        movieCategory = MovieCategory.Documentary
                    },
                    new Movie()
                    {
                        Id = 2,
                        Name = "The Shawshank Redemption",
                        Description = "This is the Shawshank Redemption description",
                        Price = 29.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                        StartDate = new DateTime(2024, 2, 1),
                        EndDate = new DateTime(2024, 2, 10),
                        CinemaId = 1,
                        ProducerId = 1,
                        movieCategory = MovieCategory.Action
                    },
                    new Movie()
                    {
                        Id = 3,
                        Name = "Ghost",
                        Description = "This is the Ghost movie description",
                        Price = 39.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                        StartDate = new DateTime(2024, 3, 1),
                        EndDate = new DateTime(2024, 3, 15),
                        CinemaId = 4,
                        ProducerId = 4,
                        movieCategory = MovieCategory.Horror
                    },
                    new Movie()
                    {
                        Id = 4,
                        Name = "Race",
                        Description = "This is the Race movie description",
                        Price = 39.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                        StartDate = new DateTime(2024, 4, 1),
                        EndDate = new DateTime(2024, 4, 10),
                        CinemaId = 1,
                        ProducerId = 2,
                        movieCategory = MovieCategory.Documentary
                    },
                    new Movie()
                    {
                        Id = 5,
                        Name = "Scoob",
                        Description = "This is the Scoob movie description",
                        Price = 39.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                        StartDate = new DateTime(2024, 5, 1),
                        EndDate = new DateTime(2024, 5, 15),
                        CinemaId = 1,
                        ProducerId = 3,
                        movieCategory = MovieCategory.Cartoon
                    },
                    new Movie()
                    {
                        Id = 6,
                        Name = "Cold Soles",
                        Description = "This is the Cold Soles movie description",
                        Price = 39.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                        StartDate = new DateTime(2024, 6, 1),
                        EndDate = new DateTime(2024, 6, 30),
                        CinemaId = 1,
                        ProducerId = 5,
                        movieCategory = MovieCategory.Drama
                    },
                    new Movie()
                    {
                        Id = 7,
                        Name = "The Godfather",
                        Description = "This is the The Godfather movie description",
                        Price = 150.00,
                        ImageURL = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg",
                        StartDate = DateTime.Now.AddDays(-30),
                        EndDate = DateTime.Now.AddDays(30),
                        CinemaId = 1,
                        ProducerId = 1,
                        movieCategory = MovieCategory.Drama
                    },
                    new Movie()
                    {
                        Id = 8,
                        Name = "Transformers One",
                        Description = "This is the Transformers One movie description",
                        Price = 75.00,
                        ImageURL = "https://m.media-amazon.com/images/M/MV5BNzAwOTU5ODktN2ZlOC00MjdiLWJjYTgtNjJlYmM4ZGVlNzJkXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_.jpg",
                        StartDate = DateTime.Now.AddDays(-15),
                        EndDate = DateTime.Now.AddDays(45),
                        CinemaId = 1,
                        ProducerId = 2,
                        movieCategory = MovieCategory.Action
                    },
                    new Movie()
                    {
                        Id = 9,
                        Name = "SpongeBob",
                        Description = "This is the SpongeBob movie description",
                        Price = 56.00,
                        ImageURL = "https://m.media-amazon.com/images/M/MV5BNzg4MjM2NDQ4MV5BMl5BanBnXkFtZTgwMzk3MTgyNzE@._V1_.jpg",
                        StartDate = DateTime.Now.AddDays(-10),
                        EndDate = DateTime.Now.AddDays(60),
                        CinemaId = 1,
                        ProducerId = 3,
                        movieCategory = MovieCategory.Cartoon
                    });

            builder.Entity<Actors_Movies>()
                .HasData(
                    new Actors_Movies()
                    {
                        ActorId = 1,
                        movieId = 1
                    },
                    new Actors_Movies()
                    {
                        ActorId = 3,
                        movieId = 1
                    },
                    new Actors_Movies()
                    {
                        ActorId = 1,
                        movieId = 2
                    },
                    new Actors_Movies()
                    {
                        ActorId = 4,
                        movieId = 2
                    },
                    new Actors_Movies()
                    {
                        ActorId = 1,
                        movieId = 3
                    },
                    new Actors_Movies()
                    {
                        ActorId = 2,
                        movieId = 3
                    },
                    new Actors_Movies()
                    {
                        ActorId = 5,
                        movieId = 3
                    },
                    new Actors_Movies()
                    {
                        ActorId = 2,
                        movieId = 4
                    },
                    new Actors_Movies()
                    {
                        ActorId = 3,
                        movieId = 4
                    },
                    new Actors_Movies()
                    {
                        ActorId = 4,
                        movieId = 4
                    },
                    new Actors_Movies()
                    {
                        ActorId = 2,
                        movieId = 5
                    },
                    new Actors_Movies()
                    {
                        ActorId = 3,
                        movieId = 5
                    },
                    new Actors_Movies()
                    {
                        ActorId = 4,
                        movieId = 5
                    },
                    new Actors_Movies()
                    {
                        ActorId = 5,
                        movieId = 5
                    },
                    new Actors_Movies()
                    {
                        ActorId = 3,
                        movieId = 6
                    },
                    new Actors_Movies()
                    {
                        ActorId = 4,
                        movieId = 6
                    },
                    new Actors_Movies()
                    {
                        ActorId = 5,
                        movieId = 6
                    });
        }
    }



    }

 