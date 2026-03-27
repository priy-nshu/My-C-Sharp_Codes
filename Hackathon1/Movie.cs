using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    internal class Movie
    {
        static int nextId = 1000;
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string DirectorName { get; set; }
        public string ProducerName { get; set; }
        public string Story { get; set; }
        public string Genre { get; set; }

        public string Language { get; set; }
        public double Duration { get; set; }

        private static readonly string[] ValidLanguages =
            { "English", "Hindi", "Tamil", "Telugu", "Kannada", "Malayalam" };



        public Movie(string movieName, string directorName, string producerName, string story, string genre,
                    string language, double duration)
        {
            bool langValid = false;
            foreach (var lang in ValidLanguages)
                if (lang.Equals(language, StringComparison.OrdinalIgnoreCase)) { langValid = true; break; }

            if (!langValid)
                throw new InvalidLanguageException();

            if (duration <= 0)
                throw new InvalidDurationException();

            MovieName = movieName;
            DirectorName = directorName;
            ProducerName = producerName;
            Story = story;
            Genre = genre;
            Duration = duration;

            MovieId = nextId++;
        }

        public void DisplayMovieDetails()
        {
            Console.WriteLine("----Movie Details----");
            Console.WriteLine($"Movie Id   : {MovieId}");
            Console.WriteLine($"Movie Name :{MovieName}");
            Console.WriteLine($"Director   :{DirectorName}");
            Console.WriteLine($"Producer   :{ProducerName}");
            Console.WriteLine($"Story      :{Story}");
            Console.WriteLine($"Genre      :{Genre}");
            Console.WriteLine($"Duration   :{Duration}");

        }
    }
}
