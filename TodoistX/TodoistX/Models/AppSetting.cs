using SQLite;

namespace TodoistX.Models
{
    class AppSetting
    {
        public static string DbFileName = "TodoistX_db.sqlite";

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string AppName { get; set; }
        public string Author { get; set; }
        public string AuthKey { get; set; }
    }
}
