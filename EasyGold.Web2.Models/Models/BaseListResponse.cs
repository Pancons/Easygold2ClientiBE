namespace EasyGold.Web2.Models
{
    public class BaseListResponse<T>
    {
        public List<T> results { get; set; } = new();
        public int total { get; set; }
        public BaseError error  { get; set; }   

        public BaseListResponse() { }

        public BaseListResponse(IEnumerable<T> items, int totalCount)
        {
            results = items.ToList();
            total = totalCount;
        }
    }
}
