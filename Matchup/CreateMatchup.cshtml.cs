using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace TourneyPlaner.Pages.Matchup
{
    public class CreateMatchupModel : PageModel
    {
        [BindProperty]
        public MatchupCreate MatchupCreate { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            DateTime startDateTime = MatchupCreate.startDateTime;
            int rounds = MatchupCreate.rounds;
            int tournamentId = MatchupCreate.tournamentId;
            int nextMatchupId = MatchupCreate.nextMatchupId;

            string connectionString = "Data Source=192.168.1.4;Initial Catalog=TourneyPlannerDev;User ID=TourneyAdmin;Password=Kode1234!";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"INSERT INTO Matchup (StartDateTime, Rounds, TournamentId, NextMatchupId) VALUES ('{startDateTime}','{rounds}', '{tournamentId}', '{nextMatchupId}')";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return RedirectToPage("/Matchup/Matchup");
        }
    }
    public class MatchupCreate
    {
        [Required]
        public DateTime startDateTime { get; set; }
        [Required]
        public int rounds { get; set; }
        [Required]
        public int tournamentId { get; set; }
        [Required]
        public int nextMatchupId { get; set; }
    }
}