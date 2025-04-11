namespace EasyGold.API.Models
{
    public class BaseListResponse<T>
    {
        public List<T> results { get; set; } = new();
        public int total { get; set; }

        public BaseListResponse() { }

        public BaseListResponse(IEnumerable<T> items, int totalCount)
        {
            results = items.ToList();
            total = totalCount;
        }
    }
}
