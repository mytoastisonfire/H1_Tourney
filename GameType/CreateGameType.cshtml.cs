using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace TourneyPlaner.Pages.GameType
{
    public class CreateGameTypeModel : PageModel
    {
        [BindProperty]
        public GameTypeCreate GameTypeCreate { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            string name = GameTypeCreate.name;
            int teamsPerMatch = GameTypeCreate.teamsPerMatch;
            int pointsForDraw = GameTypeCreate.pointsForDraw;
            int pointsForWin = GameTypeCreate.pointsForWin;

            string connectionString = "Data Source=192.168.1.4;Initial Catalog=TourneyPlannerDev;User ID=TourneyAdmin;Password=Kode1234!";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"INSERT INTO GameType (Name, TeamsPerMatch, PointsForDraw, PointsForWin) VALUES ('{name}','{teamsPerMatch}', '{pointsForDraw}', '{pointsForWin}')";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return RedirectToPage("/GameType/GameType");
        }
    }
    public class GameTypeCreate
    {
        [Required]
        public string name { get; set; }
        [Required]
        public int teamsPerMatch { get; set; }
        [Required]
        public int pointsForDraw { get; set; }
        [Required]
        public int pointsForWin { get; set; }
    }
}