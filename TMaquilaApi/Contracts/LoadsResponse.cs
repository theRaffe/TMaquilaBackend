using TMaquilaApi.Models;

namespace TMaquilaApi.Contracts
{
    public class LoadsResponse
    {
        public int totalPages { get; set; }
        public List<TblLoad> Loads { get; set; } = new List<TblLoad>();

    }
}