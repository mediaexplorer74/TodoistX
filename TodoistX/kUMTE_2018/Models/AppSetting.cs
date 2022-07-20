using SQLite;

namespace kUMTE_2018.Models
{
    class AppSetting
    {
        public static string DbFileName = "kUMTE_db.sqlite";

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string AppName { get; set; }
        public string Author { get; set; }
        public string AuthKey { get; set; }
    }
}
