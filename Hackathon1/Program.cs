using Hackathon1;
using System;
using System.Collections.Generic;
using System.Linq;

MovieDataStore dataStore = new MovieDataStore();
LoginDetails loggedInUser = null;


bool running = true;
while (running)
{
    if (loggedInUser == null)
    {
        Console.WriteLine("\na. Create Login");
        Console.WriteLine("b. Sign In");
        Console.WriteLine("j. Exit");
        Console.Write("Enter your choice? ");
        string choice = Console.ReadLine();
        Console.WriteLine();

        switch (choice.ToLower())
        {
            case "a": CreateLogin(); break;
            case "b": SignIn(); break;
            case "j": running = false; break;
            default: Console.WriteLine("Invalid choice."); break;
        }
    }
    else
    {
        bool isAdmin = loggedInUser.LoginType.Equals("Admin", StringComparison.OrdinalIgnoreCase);

        if (isAdmin)
        {
            Console.WriteLine("\nc. Create/Update/Delete Theatre");
            Console.WriteLine("d. Create/Update/Delete Movie");
            Console.WriteLine("e. Create/Update/Delete Show");
            Console.WriteLine("f. Display Theatres");
            Console.WriteLine("g. Display Shows");
            Console.WriteLine("i. Display Bookings");
            Console.WriteLine("j. Sign Out");
        }
        else
        {
            Console.WriteLine("\nf. Display Theatres");
            Console.WriteLine("g. Display Shows");
            Console.WriteLine("h. Book/Update/Delete Ticket");
            Console.WriteLine("i. Display Bookings");
            Console.WriteLine("j. Sign Out");
        }

        Console.Write("Enter your choice? ");
        string choice = Console.ReadLine();
        Console.WriteLine();

        switch (choice.ToLower())
        {
            case "c":
                if (isAdmin) ManageTheatre();
                else Console.WriteLine("Access denied. Admin only.");
                break;
            case "d":
                if (isAdmin) ManageMovie();
                else Console.WriteLine("Access denied. Admin only.");
                break;
            case "e":
                if (isAdmin) ManageShow();
                else Console.WriteLine("Access denied. Admin only.");
                break;
            case "f": dataStore.DisplayAllTheatres(); break;
            case "g": dataStore.DisplayAllShows(); break;
            case "h":
                if (!isAdmin) ManageBooking();
                else Console.WriteLine("Access denied. Customer only.");
                break;
            case "i": DisplayBookings(isAdmin); break;
            case "j":
                loggedInUser = null;
                Console.WriteLine("Signed out successfully.");
                break;
            default: Console.WriteLine("Invalid choice."); break;
        }
    }
}

Console.WriteLine("Goodbye!");



void CreateLogin()
{
    Console.WriteLine("\n1. Customer\n2. Admin");
    Console.Write("Select type: ");
    string type = Console.ReadLine();
    Console.WriteLine();

    if (type == "1")
    {
        Console.Write("Customer Name: "); string name = Console.ReadLine();
        Console.Write("City         : "); string city = Console.ReadLine();

        var customer = new Customer(name, city);
        customer.CustomerID = dataStore.Customers.Count == 0
            ? 1000
            : dataStore.Customers.Max(c => c.CustomerID) + 1;

        var login = new LoginDetails(customer.CustomerID.ToString(), "Customer");
        login.LoginID = customer.CustomerID.ToString();

        dataStore.AddCustomers(customer);
        dataStore.AddLogin(login);

        Console.WriteLine($"\nLogin created! Login ID: {login.LoginID} | Password: {login.Password}");
        login.DisplayLoginDetails();
    }
    else if (type == "2")
    {
        var login = new LoginDetails("MOVIEADMIN", "Admin");
        dataStore.AddLogin(login);
        Console.WriteLine($"\nAdmin Login ID: {login.LoginID} | Password: {login.Password}");
        login.DisplayLoginDetails();
    }
    else
    {
        Console.WriteLine("Invalid selection.");
    }
}



void SignIn()
{
    Console.Write("Enter Login ID : "); string loginId = Console.ReadLine();
    Console.Write("Enter Password : "); string password = Console.ReadLine();

    var match = dataStore.Logins.FirstOrDefault(l =>
        l.LoginID.Equals(loginId, StringComparison.OrdinalIgnoreCase) &&
        l.Password.Equals(password, StringComparison.OrdinalIgnoreCase));

    if (match != null)
    {
        loggedInUser = match;
        Console.WriteLine($"\nWelcome! Signed in as {match.LoginType} (ID: {match.LoginID})");
    }
    else
    {
        Console.WriteLine("\nInvalid Credentials.");
    }
}



void ManageTheatre()
{
    Console.WriteLine("\n1. Create Theatre\n2. Update Theatre\n3. Delete Theatre");
    Console.Write("Choice: "); string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Write("Theatre Name : "); string name = Console.ReadLine();

        bool duplicate = dataStore.Theatres.Any(t =>
            t.TheatreName.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (duplicate)
        {
            Console.WriteLine("Duplicate Theatre Name not allowed.");
            return;
        }

        Console.Write("No. of Seats : "); int.TryParse(Console.ReadLine(), out int seats);
        var theatre = new Theatre(name, seats);
        dataStore.AddTheatre(theatre);
        Console.WriteLine($"Theatre added! ID: {theatre.TheatreID}");
    }
    else if (choice == "2")
    {
        dataStore.DisplayAllTheatres();
        Console.Write("Enter Theatre ID to update: "); int.TryParse(Console.ReadLine(), out int id);
        var t = dataStore.Theatres.FirstOrDefault(x => x.TheatreID == id);
        if (t == null) { Console.WriteLine("Theatre not found."); return; }

        Console.Write("New Theatre Name : "); t.TheatreName = Console.ReadLine();
        Console.Write("New No. of Seats : "); int.TryParse(Console.ReadLine(), out int seats);
        t.NumberOfSeats = seats;
        Console.WriteLine("Theatre updated.");
    }
    else if (choice == "3")
    {
        dataStore.DisplayAllTheatres();
        Console.Write("Enter Theatre ID to delete: "); int.TryParse(Console.ReadLine(), out int id);
        var t = dataStore.Theatres.FirstOrDefault(x => x.TheatreID == id);
        if (t == null) { Console.WriteLine("Theatre not found."); return; }
        dataStore.Theatres.Remove(t);
        Console.WriteLine("Theatre deleted.");
    }
}



void ManageMovie()
{
    Console.WriteLine("\n1. Create Movie\n2. Update Movie\n3. Delete Movie");
    Console.Write("Choice: "); string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Write("Movie Name    : "); string name = Console.ReadLine();
        Console.Write("Director Name : "); string director = Console.ReadLine();
        Console.Write("Producer Name : "); string producer = Console.ReadLine();
        Console.Write("Story         : "); string story = Console.ReadLine();
        Console.Write("Genre         : "); string genre = Console.ReadLine();
        Console.Write("Language      : "); string language = Console.ReadLine();
        Console.Write("Duration (hrs): "); double.TryParse(Console.ReadLine(), out double duration);

        try
        {
            var movie = new Movie(name, director, producer, story, genre, language, duration);
            dataStore.AddMovie(movie);
            Console.WriteLine($"Movie added! ID: {movie.MovieId}");
        }
        catch (InvalidLanguageException ex) { Console.WriteLine($"[Error] {ex.Message}"); }
        catch (InvalidDurationException ex) { Console.WriteLine($"[Error] {ex.Message}"); }
    }
    else if (choice == "2")
    {
        dataStore.DisplayAllMovies();
        Console.Write("Enter Movie ID to update: "); int.TryParse(Console.ReadLine(), out int id);
        var m = dataStore.SearchMovie(id);
        if (m == null) { Console.WriteLine("Movie not found."); return; }

        Console.Write("New Duration: ");
        double.TryParse(Console.ReadLine(), out double dur);
        m.Duration = dur;
        Console.WriteLine("Movie updated.");
    }
    else if (choice == "3")
    {
        dataStore.DisplayAllMovies();
        Console.Write("Enter Movie ID to delete: "); int.TryParse(Console.ReadLine(), out int id);
        dataStore.DeleteMovie(id);
        Console.WriteLine("Movie deleted.");
    }
}




void ManageShow()
{
    Console.WriteLine("\n1. Create Show\n2. Update Show\n3. Delete Show");
    Console.Write("Choice: "); string choice = Console.ReadLine();

    if (choice == "1")
    {
        dataStore.DisplayAllTheatres();
        Console.Write("Enter Theatre ID: "); int.TryParse(Console.ReadLine(), out int theatreId);

        dataStore.DisplayAllMovies();
        Console.Write("Enter Movie ID  : "); int.TryParse(Console.ReadLine(), out int movieId);

        int existingShows = dataStore.Shows.Count(s =>
            s.TheatreID == theatreId && s.MovieID == movieId);
        if (existingShows >= 4)
        {
            Console.WriteLine("Maximum 4 shows allowed for the same Theatre and Movie.");
            return;
        }

        Console.Write("Start Date (yyyy-MM-dd): "); DateTime.TryParse(Console.ReadLine(), out DateTime start);
        Console.Write("End Date   (yyyy-MM-dd): "); DateTime.TryParse(Console.ReadLine(), out DateTime end);
        Console.Write("Platinum Rate          : "); decimal.TryParse(Console.ReadLine(), out decimal platinum);
        Console.Write("Gold Rate              : "); decimal.TryParse(Console.ReadLine(), out decimal gold);
        Console.Write("Silver Rate            : "); decimal.TryParse(Console.ReadLine(), out decimal silver);

        var show = new Show(movieId, theatreId, start, end, platinum, gold, silver);
        dataStore.AddShows(show);
        Console.WriteLine($"Show added! ID: {show.ShowID}");
    }
    else if (choice == "2")
    {
        dataStore.DisplayAllShows();
        Console.Write("Enter Show ID to update: "); int.TryParse(Console.ReadLine(), out int id);
        var s = dataStore.Shows.FirstOrDefault(x => x.ShowID == id);
        if (s == null) { Console.WriteLine("Show not found."); return; }

        Console.Write("New Platinum Rate: ");
        decimal.TryParse(Console.ReadLine(), out decimal p);
        Console.Write("New Gold Rate    : ");
        decimal.TryParse(Console.ReadLine(), out decimal g);
        Console.Write("New Silver Rate  : ");
        decimal.TryParse(Console.ReadLine(), out decimal sv);

        s.PlatinumSeatRate = p;
        s.GoldSeatRate = g;
        s.SilverSeatRate = sv;
        Console.WriteLine("Show updated.");
    }
    else if (choice == "3")
    {
        dataStore.DisplayAllShows();
        Console.Write("Enter Show ID to delete: "); int.TryParse(Console.ReadLine(), out int id);
        var s = dataStore.Shows.FirstOrDefault(x => x.ShowID == id);
        if (s == null) { Console.WriteLine("Show not found."); return; }
        dataStore.Shows.Remove(s);
        Console.WriteLine("Show deleted.");
    }
}



void ManageBooking()
{
    Console.WriteLine("\n1. Book Ticket\n2. Delete Ticket");
    Console.Write("Choice: "); string choice = Console.ReadLine();

    if (choice == "1")
    {
        dataStore.DisplayAllTheatres();
        Console.Write("Select Theatre ID: "); int.TryParse(Console.ReadLine(), out int theatreId);

        var theatreShows = dataStore.Shows.Where(s => s.TheatreID == theatreId).ToList();
        if (theatreShows.Count == 0) { Console.WriteLine("No shows for this theatre."); return; }
        foreach (var sh in theatreShows) sh.DisplayShowDetails();

        Console.Write("Select Show ID: "); int.TryParse(Console.ReadLine(), out int showId);
        var show = theatreShows.FirstOrDefault(s => s.ShowID == showId);
        if (show == null) { Console.WriteLine("Show not found."); return; }

        var theatre = dataStore.Theatres.FirstOrDefault(t => t.TheatreID == theatreId);
        int totalBooked = dataStore.Bookings.Where(b => b.ShowID == showId).Sum(b => b.NumberOfSeats);

        Console.Write("Customer Name                   : "); string custName = Console.ReadLine();
        Console.Write("Email                           : "); string email = Console.ReadLine();
        Console.Write("Seat Type (Platinum/Gold/Silver): "); string seatType = Console.ReadLine();
        Console.Write("Number of Seats (1-4)           : "); int.TryParse(Console.ReadLine(), out int numSeats);

        if (theatre != null && (totalBooked + numSeats) > theatre.NumberOfSeats)
        {
            Console.WriteLine($"Cannot book. Theatre capacity ({theatre.NumberOfSeats}) would be exceeded.");
            return;
        }

        try
        {
            var booking = new Booking(showId, custName, numSeats, seatType, email);
            dataStore.AddBookings(booking);
            Console.WriteLine($"\nBooking confirmed! ID: {booking.BookingID}");
            Console.WriteLine($"Amount : {booking.Amount:C}");
            Console.WriteLine($"Status : {booking.BookingStatus}");
        }
        catch (ArgumentException ex) { Console.WriteLine($"[Error] {ex.Message}"); }
    }
    else if (choice == "2")
    {
        DisplayBookings(false);
        Console.Write("Enter Booking ID to delete: "); int.TryParse(Console.ReadLine(), out int id);
        var b = dataStore.Bookings.FirstOrDefault(x => x.BookingID == id);
        if (b == null) { Console.WriteLine("Booking not found."); return; }
        dataStore.Bookings.Remove(b);
        Console.WriteLine("Booking deleted.");
    }
}



void DisplayBookings(bool isAdmin)
{
    if (isAdmin)
    {
        dataStore.DisplayAllBookings();
    }
    else
    {
        var myBookings = dataStore.Bookings
            .Where(b => b.CustomerName.Equals(
                dataStore.Customers.FirstOrDefault(c =>
                    c.CustomerID.ToString() == loggedInUser.LoginID)?.CustomerName,
                StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (myBookings.Count == 0) Console.WriteLine("No bookings found.");
        else foreach (var b in myBookings) b.DisplayBookingDetails();
    }
}