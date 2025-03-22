

namespace TMaquilaApi.Models
{
    public class NewLoadRequest
    {
        public long? Id { get; set; }

        public string vendorName { get; set; } = string.Empty;

        public string type { get; set; } = string.Empty;

        public string legDate { get; set; } = string.Empty;

        public int deleted { get; set; }

        public Guid createdBy { get; set; }

    }
}