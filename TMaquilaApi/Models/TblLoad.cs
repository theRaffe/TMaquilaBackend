
using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace TMaquilaApi.Models
{
    [Table("tbl_loads")]
    public class TblLoad : BaseModel
    {
        [PrimaryKey("id", false)]
        public long Id { get; set; }

        [Column("vendor_name")]
        public string VendorName { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("leg_date")]
        public DateTime LegDate { get; set; }

        [Column("deleted")]
        public int Deleted { get; set; }

        [Column("created_by")]
        [JsonProperty("created_by")]
        public Guid CreatedBy { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}