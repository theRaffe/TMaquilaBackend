
using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace TMaquilaApi.Models
{
    [Table("tbl_log")]
    public class TblLog: BaseModel
    {
        [PrimaryKey("id", false)]
        public long Id { get; set; }

        [Column("user_id")]
        [JsonProperty("user_id")] 
        public Guid UserId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("hostname")]
        public string? Hostname { get; set; }
    }
}