using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    internal class MovieDataStore
    {
        public List<Movie> Movies { get; set; }
        public List<Theatre> Theatres { get; set; }
        public List<Customer> Customers { get; set; }
        public List<LoginDetails> Logins { get; set; }
        public List<Show> Shows { get; set; }
        public List<Booking> Bookings { get; set; }

        private const string MoviesFile = "Movies.csv";
        private const string TheatresFile = "Theatres.csv";
        private const string CustomersFile = "Customers.csv";
        private const string LoginsFile = "Login.csv";
        private const string ShowsFile = "Shows.csv";
        private const string BookingsFile = "Bookings.csv";

        public MovieDataStore()
        {
            Movies = new List<Movie>();
            Theatres = new List<Theatre>();
            Customers = new List<Customer>();
            Logins = new List<LoginDetails>();
            Shows = new List<Show>();
            Bookings = new List<Booking>();

            FetchMovies();
            FetchTheatres();
            FetchCustomers();
            FetchLogins();
            FetchShows();
            FetchBookings();
        }
        public void FetchMovies()
        {
            if (!File.Exists("Movies.csv")) return;
            foreach (var line in File.ReadAllLines("Movies.csv"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var p = line.Split(',');
                if (p.Length < 9) continue;
<<<<<<< HEAD
                var movie = new Movie(p[1], p[2], p[3], p[4], p[5], p[6], double.Parse(p[7]));
=======
                var movie = new Movie(p[1], p[2], p[3], p[4], p[5],p[6], double.Parse(p[7]));
>>>>>>> ca973e6edfc4a47fab7f244dfc44b86289a76d21
                movie.MovieId = int.Parse(p[0]);
                Movies.Add(movie);
            }
        }
        public void FetchShows()
        {
            if (!File.Exists(ShowsFile)) return;
            foreach (var line in File.ReadAllLines(ShowsFile))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var p = line.Split(',');
                if (p.Length < 8) continue;
                var show = new Show(int.Parse(p[1]), int.Parse(p[2]),
                                    DateTime.Parse(p[3]), DateTime.Parse(p[4]),
                                    decimal.Parse(p[5]), decimal.Parse(p[6]), decimal.Parse(p[7]));
                show.ShowID = int.Parse(p[0]);
                Shows.Add(show);
            }
        }

        public void FetchTheatres()
        {
            if (!File.Exists("Theatres.csv")) return;
            foreach (var line in File.ReadAllLines("Theatres.csv"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var p = line.Split(',');
                if (p.Length < 3) continue;
                var theatre = new Theatre(p[1], int.Parse(p[2]));
                theatre.TheatreID = int.Parse(p[0]);
                Theatres.Add(theatre);
            }
        }

        public void FetchCustomers()
        {
            if (!File.Exists("Customers.csv")) return;
            foreach (var line in File.ReadAllLines("Customers.csv"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var p = line.Split(',');
                if (p.Length < 3) continue;
                var customer = new Customer(p[1], p[2]);
                customer.CustomerID = int.Parse(p[0]);
                Customers.Add(customer);
            }
        }

        public void FetchLogins()
        {
            if (!File.Exists("Login.csv")) return;
            foreach (var line in File.ReadAllLines("Login.csv"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var p = line.Split(',');
                if (p.Length < 3) continue;
                var login = new LoginDetails(p[1], p[2]);
                login.LoginID = p[0];
                Logins.Add(login);
            }
        }

        public void FetchBookings()
        {
            if (!File.Exists("Bookings.csv")) return;
            foreach (var line in File.ReadAllLines("Bookings.csv"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var p = line.Split(',');
                if (p.Length < 9) continue;
                var seatNumbers = new List<int>();
                foreach (var s in p[8].Trim().Split(';'))
                    if (int.TryParse(s, out int sn)) seatNumbers.Add(sn);

<<<<<<< HEAD
                var booking = new Booking(int.Parse(p[1]), p[2], int.Parse(p[3]), p[4], p[5]);
=======
                var booking = new Booking(int.Parse(p[1]),p[2],int.Parse(p[3]),p[4],p[5]);
>>>>>>> ca973e6edfc4a47fab7f244dfc44b86289a76d21
                Bookings.Add(booking);
            }
        }

        //-----------------------------------ADD-----------------------------------------

        public void AddMovie(Movie obj)
        {
            if (obj == null) throw new NullReferenceException("Movie details cannot be null");
            Movies.Add(obj);
            File.AppendAllText(MoviesFile,
                $"{obj.MovieId},{obj.MovieName},{obj.DirectorName},{obj.ProducerName},{obj.Story},{obj.Genre},{obj.Language},{obj.Duration}\n");
        }

        public void AddTheatre(Theatre obj)
        {
            if (obj == null) throw new NullReferenceException("Theatre details cannot be null");
            Theatres.Add(obj);
            File.AppendAllText(TheatresFile,
                $"{obj.TheatreID},{obj.TheatreName},{obj.NumberOfSeats}\n");
        }

        public void AddCustomers(Customer obj)
        {
            if (obj == null) throw new NullReferenceException("Customer details cannot be null");
            Customers.Add(obj);
            File.AppendAllText(CustomersFile,
                $"{obj.CustomerID},{obj.CustomerName},{obj.City}\n");
        }

        public void AddLogin(LoginDetails obj)
        {
            if (obj == null) throw new NullReferenceException("Login details cannot be null");
            Logins.Add(obj);
            File.AppendAllText(LoginsFile,
                $"{obj.LoginID},{obj.Password},{obj.LoginType}\n");
        }

        public void AddShows(Show obj)
        {
            if (obj == null) throw new NullReferenceException("Show details cannot be null");
            Shows.Add(obj);
            File.AppendAllText(ShowsFile,
                $"{obj.ShowID},{obj.MovieID},{obj.TheatreID},{obj.StartDate:yyyy-MM-dd},{obj.EndDate:yyyy-MM-dd},{obj.PlatinumSeatRate},{obj.GoldSeatRate},{obj.SilverSeatRate}\n");
        }

        public void AddBookings(Booking obj)
        {
            if (obj == null) throw new NullReferenceException("Booking details cannot be null");
            Bookings.Add(obj);
            File.AppendAllText(BookingsFile,
                $"{obj.BookingID},{obj.ShowID},{obj.CustomerName},{obj.NumberOfSeats},{obj.SeatType},{obj.Email},{obj.BookingStatus},{obj.Amount},{string.Join(";", obj.SeatNumbers)},{obj.BookingDate:yyyy-MM-dd HH:mm}\n");
        }


        //--------------------------------UPDATE---------------------------------------------

        public void UpdateMovie(int movieId, Movie updated)
        {
            var m = Movies.Find(x => x.MovieId == movieId);
            if (m == null) { Console.WriteLine("Movie not found."); return; }
            Movies.Remove(m);
            Movies.Add(updated);
            RewriteMoviesFile();
        }

        public void UpdateTheatre(int theatreId, Theatre updated)
        {
            var t = Theatres.Find(x => x.TheatreID == theatreId);
            if (t == null) { Console.WriteLine("Theatre not found."); return; }
            Theatres.Remove(t);
            Theatres.Add(updated);
            RewriteTheatresFile();
        }

        public void UpdateCustomer(int customerId, Customer updated)
        {
            var c = Customers.Find(x => x.CustomerID == customerId);
            if (c == null) { Console.WriteLine("Customer not found."); return; }
            Customers.Remove(c);
            Customers.Add(updated);
            RewriteCustomersFile();
        }

        // ------------------------------------- DELETE ----------------------------------------------------

        public void DeleteMovie(int movieId)
        {
            var m = Movies.Find(x => x.MovieId == movieId);
            if (m == null) { Console.WriteLine("Movie not found."); return; }
            Movies.Remove(m);
            RewriteMoviesFile();
        }

        public void DeleteTheatre(int theatreId)
        {
            var t = Theatres.Find(x => x.TheatreID == theatreId);
            if (t == null) { Console.WriteLine("Theatre not found."); return; }
            Theatres.Remove(t);
            RewriteTheatresFile();
        }

        public void DeleteCustomer(int customerId)
        {
            var c = Customers.Find(x => x.CustomerID == customerId);
            if (c == null) { Console.WriteLine("Customer not found."); return; }
            Customers.Remove(c);
            RewriteCustomersFile();
        }

        // ------------------------------------ SEARCH ---------------------------------------

        public Movie SearchMovie(int movieId) => Movies.Find(x => x.MovieId == movieId);
        public Theatre SearchTheatre(int theatreId) => Theatres.Find(x => x.TheatreID == theatreId);
        public Customer SearchCustomer(int custId) => Customers.Find(x => x.CustomerID == custId);
        public Show SearchShow(int showId) => Shows.Find(x => x.ShowID == showId);
        public Booking SearchBooking(int bookingId) => Bookings.Find(x => x.BookingID == bookingId);


        // ------------------------------ DISPLAY ------------------------------------------

        public void DisplayAllMovies()
        {
            if (Movies.Count == 0) { Console.WriteLine("No movies found.\n"); return; }
            foreach (var m in Movies) m.DisplayMovieDetails();
        }

        public void DisplayAllTheatres()
        {
            if (Theatres.Count == 0) { Console.WriteLine("No theatres found.\n"); return; }
            foreach (var t in Theatres) t.DisplayTheatreDetails();
        }

        public void DisplayAllCustomers()
        {
            if (Customers.Count == 0) { Console.WriteLine("No customers found.\n"); return; }
            foreach (var c in Customers) c.DisplayCustomerDetails();
        }

        public void DisplayAllShows()
        {
            if (Shows.Count == 0) { Console.WriteLine("No shows found.\n"); return; }
            foreach (var s in Shows) s.DisplayShowDetails();
        }

        public void DisplayAllBookings()
        {
            if (Bookings.Count == 0) { Console.WriteLine("No bookings found.\n"); return; }
            foreach (var b in Bookings) b.DisplayBookingDetails();
        }

        //--------------------------------------CHANGE----------------------------------------------
        private void RewriteTheatresFile()
        {
            using var sw = new StreamWriter(TheatresFile, false);
            foreach (var t in Theatres)
                sw.WriteLine($"{t.TheatreID},{t.TheatreName},{t.NumberOfSeats}");
        }

        private void RewriteCustomersFile()
        {
            using var sw = new StreamWriter(CustomersFile, false);
            foreach (var c in Customers)
                sw.WriteLine($"{c.CustomerID},{c.CustomerName},{c.City}");
        }
        private void RewriteMoviesFile()
        {
            using var sw = new StreamWriter(MoviesFile, false);
            foreach (var m in Movies)
                sw.WriteLine($"{m.MovieId},{m.MovieName},{m.DirectorName},{m.ProducerName}," +
                             $"{m.Story},{m.Genre},{m.Duration}");
        }
    }
}
