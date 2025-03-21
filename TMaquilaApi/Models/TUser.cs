
using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace TMaquilaApi.Models
{
    [Table("TUser")]
    public class TUser: BaseModel
    {
        [PrimaryKey("id", false)]
        [JsonProperty("id")] 
        public Guid Id { get; set; }
        [Column("username")]
        public string username { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}