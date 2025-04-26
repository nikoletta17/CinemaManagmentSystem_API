using System.Reflection.Emit;
using CinemaManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema_ManagementSystem.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
               new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", Director = "Christopher Nolan", DurationMinutes = 148, ReleaseYear = 2010, AgeRestriction = "16+", Description = "Dream within a dream" },
               new Movie { Id = 2, Title = "Titanic", Genre = "Drama", Director = "James Cameron", DurationMinutes = 195, ReleaseYear = 1997, AgeRestriction = "12+", Description = "Famous love story" },
               new Movie { Id = 3, Title = "The Matrix", Genre = "Action", Director = "Wachowski Sisters", DurationMinutes = 136, ReleaseYear = 1999, AgeRestriction = "16+", Description = "Virtual reality fight" },
               new Movie { Id = 4, Title = "Avatar", Genre = "Fantasy", Director = "James Cameron", DurationMinutes = 162, ReleaseYear = 2009, AgeRestriction = "12+", Description = "Alien world adventure" },
               new Movie { Id = 5, Title = "Interstellar", Genre = "Sci-Fi", Director = "Christopher Nolan", DurationMinutes = 169, ReleaseYear = 2014, AgeRestriction = "12+", Description = "Space travel" },
               new Movie { Id = 6, Title = "Joker", Genre = "Drama", Director = "Todd Phillips", DurationMinutes = 122, ReleaseYear = 2019, AgeRestriction = "18+", Description = "Villain origin" },
               new Movie { Id = 7, Title = "Gladiator", Genre = "Action", Director = "Ridley Scott", DurationMinutes = 155, ReleaseYear = 2000, AgeRestriction = "16+", Description = "Roman arena battles" },
               new Movie { Id = 8, Title = "Frozen", Genre = "Animation", Director = "Chris Buck", DurationMinutes = 102, ReleaseYear = 2013, AgeRestriction = "0+", Description = "Magical kingdom" },
               new Movie { Id = 9, Title = "Shrek", Genre = "Animation", Director = "Andrew Adamson", DurationMinutes = 90, ReleaseYear = 2001, AgeRestriction = "0+", Description = "Funny fairy tale" },
               new Movie { Id = 10, Title = "Harry Potter", Genre = "Fantasy", Director = "Chris Columbus", DurationMinutes = 152, ReleaseYear = 2001, AgeRestriction = "12+", Description = "Wizard school" },
               new Movie { Id = 11, Title = "Avengers", Genre = "Action", Director = "Joss Whedon", DurationMinutes = 143, ReleaseYear = 2012, AgeRestriction = "12+", Description = "Superheroes unite" },
               new Movie { Id = 12, Title = "Spider-Man", Genre = "Action", Director = "Sam Raimi", DurationMinutes = 121, ReleaseYear = 2002, AgeRestriction = "12+", Description = "Friendly neighborhood hero" }
           );

            modelBuilder.Entity<Hall>().HasData(
               new Hall { Id = 1, HallNumber = 1, SeatsCount = 100, HallType = "Standard" },
               new Hall { Id = 2, HallNumber = 2, SeatsCount = 120, HallType = "Standard" },
               new Hall { Id = 3, HallNumber = 3, SeatsCount = 80, HallType = "VIP" },
               new Hall { Id = 4, HallNumber = 4, SeatsCount = 60, HallType = "Standard" },
               new Hall { Id = 5, HallNumber = 5, SeatsCount = 50, HallType = "VIP" },
               new Hall { Id = 6, HallNumber = 6, SeatsCount = 90, HallType = "Standard" },
               new Hall { Id = 7, HallNumber = 7, SeatsCount = 150, HallType = "Standard" },
               new Hall { Id = 8, HallNumber = 8, SeatsCount = 100, HallType = "VIP" },
               new Hall { Id = 9, HallNumber = 9, SeatsCount = 110, HallType = "Standard" },
               new Hall { Id = 10, HallNumber = 10, SeatsCount = 70, HallType = "VIP" },
               new Hall { Id = 11, HallNumber = 11, SeatsCount = 130, HallType = "Standard" },
               new Hall { Id = 12, HallNumber = 12, SeatsCount = 140, HallType = "Standard" }
           );
            modelBuilder.Entity<Sale>().HasData(
                new Sale { Id = 1, TicketsCount = 2, TotalAmount = 200, PurchaseDate = new DateTime(2025, 3, 22, 9, 15, 0), DiscountId = 1, UserId = 1 },
                new Sale { Id = 2, TicketsCount = 1, TotalAmount = 100, PurchaseDate = new DateTime(2025, 3, 23, 10, 0, 0), DiscountId = null, UserId = 2 },
                new Sale { Id = 3, TicketsCount = 3, TotalAmount = 270, PurchaseDate = new DateTime(2025, 3, 24, 11, 45, 0), DiscountId = 2, UserId = null },
                new Sale { Id = 4, TicketsCount = 2, TotalAmount = 160, PurchaseDate = new DateTime(2025, 3, 25, 12, 30, 0), DiscountId = null, UserId = 3 },
                new Sale { Id = 5, TicketsCount = 1, TotalAmount = 90, PurchaseDate = new DateTime(2025, 3, 26, 13, 15, 0), DiscountId = null, UserId = 1 },
                new Sale { Id = 6, TicketsCount = 4, TotalAmount = 400, PurchaseDate = new DateTime(2025, 3, 27, 14, 0, 0), DiscountId = 3, UserId = 4 },
                new Sale { Id = 7, TicketsCount = 2, TotalAmount = 180, PurchaseDate = new DateTime(2025, 3, 28, 15, 45, 0), DiscountId = 2, UserId = null },
                new Sale { Id = 8, TicketsCount = 1, TotalAmount = 80, PurchaseDate = new DateTime(2025, 3, 29, 16, 30, 0), DiscountId = null, UserId = 5 },
                new Sale { Id = 9, TicketsCount = 3, TotalAmount = 270, PurchaseDate = new DateTime(2025, 3, 30, 17, 15, 0), DiscountId = 1, UserId = 2 },
                new Sale { Id = 10, TicketsCount = 2, TotalAmount = 200, PurchaseDate = new DateTime(2025, 3, 31, 18, 0, 0), DiscountId = null, UserId = null },
                new Sale { Id = 11, TicketsCount = 5, TotalAmount = 450, PurchaseDate = new DateTime(2025, 4, 1, 19, 45, 0), DiscountId = 3, UserId = 4 },
                new Sale { Id = 12, TicketsCount = 1, TotalAmount = 100, PurchaseDate = new DateTime(2025, 4, 2, 20, 30, 0), DiscountId = null, UserId = 1 }
            );

            modelBuilder.Entity<Session>().HasData(
             new Session { Id = 1, DateTime = new DateTime(2025, 4, 12, 14, 0, 0), TicketPrice = 100, Status = "Активний", MovieId = 1, HallId = 1 },
             new Session { Id = 2, DateTime = new DateTime(2025, 4, 13, 16, 0, 0), TicketPrice = 120, Status = "Активний", MovieId = 2, HallId = 2 },
             new Session { Id = 3, DateTime = new DateTime(2025, 4, 14, 18, 30, 0), TicketPrice = 150, Status = "Активний", MovieId = 3, HallId = 3 },
             new Session { Id = 4, DateTime = new DateTime(2025, 4, 15, 20, 0, 0), TicketPrice = 130, Status = "Скасований", MovieId = 4, HallId = 4 },
             new Session { Id = 5, DateTime = new DateTime(2025, 4, 16, 13, 0, 0), TicketPrice = 110, Status = "Активний", MovieId = 5, HallId = 5 },
             new Session { Id = 6, DateTime = new DateTime(2025, 4, 17, 15, 0, 0), TicketPrice = 90, Status = "Активний", MovieId = 6, HallId = 1 },
             new Session { Id = 7, DateTime = new DateTime(2025, 4, 18, 17, 30, 0), TicketPrice = 140, Status = "Активний", MovieId = 7, HallId = 2 },
             new Session { Id = 8, DateTime = new DateTime(2025, 4, 19, 19, 0, 0), TicketPrice = 200, Status = "Скасований", MovieId = 8, HallId = 3 },
             new Session { Id = 9, DateTime = new DateTime(2025, 4, 20, 12, 0, 0), TicketPrice = 160, Status = "Активний", MovieId = 9, HallId = 4 },
             new Session { Id = 10, DateTime = new DateTime(2025, 4, 21, 14, 30, 0), TicketPrice = 100, Status = "Активний", MovieId = 10, HallId = 5 },
             new Session { Id = 11, DateTime = new DateTime(2025, 4, 22, 16, 0, 0), TicketPrice = 170, Status = "Активний", MovieId = 11, HallId = 1 },
             new Session { Id = 12, DateTime = new DateTime(2025, 4, 23, 18, 0, 0), TicketPrice = 180, Status = "Активний", MovieId = 12, HallId = 2 }
         );

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id = 1, SeatNumber = 1, Price = 100, Status = "Придбаний", SessionId = 1 },
                new Ticket { Id = 2, SeatNumber = 2, Price = 100, Status = "Заброньований", SessionId = 1 },
                new Ticket { Id = 3, SeatNumber = 3, Price = 120, Status = "Повернутий", SessionId = 2 },
                new Ticket { Id = 4, SeatNumber = 4, Price = 120, Status = "Придбаний", SessionId = 2 },
                new Ticket { Id = 5, SeatNumber = 5, Price = 150, Status = "Придбаний", SessionId = 3 },
                new Ticket { Id = 6, SeatNumber = 6, Price = 150, Status = "Заброньований", SessionId = 3 },
                new Ticket { Id = 7, SeatNumber = 7, Price = 130, Status = "Придбаний", SessionId = 4 },
                new Ticket { Id = 8, SeatNumber = 8, Price = 110, Status = "Повернутий", SessionId = 5 },
                new Ticket { Id = 9, SeatNumber = 9, Price = 90, Status = "Придбаний", SessionId = 6 },
                new Ticket { Id = 10, SeatNumber = 10, Price = 140, Status = "Заброньований", SessionId = 7 },
                new Ticket { Id = 11, SeatNumber = 11, Price = 200, Status = "Придбаний", SessionId = 8 },
                new Ticket { Id = 12, SeatNumber = 12, Price = 160, Status = "Придбаний", SessionId = 9 }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Іван Петренко", Email = "ivan@gmail.com", UserType = "Client", Bonuses = 30 },
                new User { Id = 2, Name = "Олена Коваленко", Email = "olena@gmail.com", UserType = "Client" },
                new User { Id = 3, Name = "Сергій Бондар", UserType = "Client", Bonuses = 10 },
                new User { Id = 4, Name = "Марія Іванова", Email = "maria@gmail.com", UserType = "Admin" },
                new User { Id = 5, Name = "Петро Василенко", UserType = "Client" },
                new User { Id = 6, Name = "Юлія Діденко", Email = "yulia@gmail.com", UserType = "Client", Bonuses = 50 },
                new User { Id = 7, Name = "Артем Кравченко", UserType = "Client", Bonuses = 5 },
                new User { Id = 8, Name = "Оксана Сидоренко", Email = "oksana@gmail.com", UserType = "Client" },
                new User { Id = 9, Name = "Дмитро Гончар", UserType = "Client" },
                new User { Id = 10, Name = "Катерина Ткаченко", Email = "katya@gmail.com", UserType = "Admin", Bonuses = 100 },
                new User { Id = 11, Name = "Владислав Лисенко", Email = "vlad@gmail.com", UserType = "Client" },
                new User { Id = 12, Name = "Наталія Павленко", UserType = "Client", Bonuses = 20 }
            );

            modelBuilder.Entity<Discount>().HasData(
               new Discount { Id = 1, Description = "Знижка для студентів", Percentage = 10 },
               new Discount { Id = 2, Description = "Знижка для пенсіонерів", Percentage = 15 },
               new Discount { Id = 3, Description = "Акція вихідного дня", Percentage = 5 },
               new Discount { Id = 4, Description = "Літня знижка", Percentage = 7 },
               new Discount { Id = 5, Description = "Знижка до Дня народження", Percentage = 20 },
               new Discount { Id = 6, Description = "Новачок у кінотеатрі", Percentage = 8 },
               new Discount { Id = 7, Description = "Знижка для постійних клієнтів", Percentage = 12 },
               new Discount { Id = 8, Description = "Знижка до 8 березня", Percentage = 9 },
               new Discount { Id = 9, Description = "Знижка до Чорної п'ятниці", Percentage = 25 },
               new Discount { Id = 10, Description = "Знижка на ранкові сеанси", Percentage = 6 },
               new Discount { Id = 11, Description = "Знижка на вечірні сеанси", Percentage = 4 },
               new Discount { Id = 12, Description = "Спеціальна пропозиція", Percentage = 13 }
           );

        }
    }
}