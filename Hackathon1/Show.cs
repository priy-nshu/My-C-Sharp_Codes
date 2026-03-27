using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    class Show
    {
        private static int nextID = 1000;
        public int ShowID { get; set; }
        public int MovieID { get; set; }
        public int TheatreID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PlatinumSeatRate { get; set; }
        public decimal GoldSeatRate { get; set; }
        public decimal SilverSeatRate { get; set; }

        public Show(int movieID, int theatreID, DateTime startDate, DateTime endDate, decimal platinumRate, decimal goldRate, decimal silverRate)
        {
            this.ShowID = nextID++;

            this.MovieID = movieID;
            this.TheatreID = theatreID;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.PlatinumSeatRate = platinumRate;
            this.GoldSeatRate = goldRate;
            this.SilverSeatRate = silverRate;
        }
        public void DisplayShowDetails()
        {
            Console.WriteLine($"Show ID: {ShowID} ,MovieID: {MovieID} ,Theatre ID: {TheatreID}");
            Console.WriteLine($"Start Date: {StartDate} ,End Date: {EndDate}");
            Console.WriteLine($"Rate -> Platinum: {PlatinumSeatRate} ,Gold: {GoldSeatRate} ,Silver: {SilverSeatRate}");
        }
    }
}
