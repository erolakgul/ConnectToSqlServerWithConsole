using System.ComponentModel.DataAnnotations;

namespace ConnectToSqlServerWithConsole.Core.Entity
{
    public class LOGS
    {
        [Key]
        public Guid ID { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedTime { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime BlockedTime { get; set; }

        public DateTime ChangedDate { get; set; }
        public string ChangedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string FileID { get; set; }
        public string LogLevel { get; set; }
        public int Event_Id { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
        public string IpAddress { get; set; }
        public string MachineName { get; set; }
    }
}
