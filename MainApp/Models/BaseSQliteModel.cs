using SQLite;

namespace MainApp.Models
{
    public class BaseSQliteModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } 
    }
}