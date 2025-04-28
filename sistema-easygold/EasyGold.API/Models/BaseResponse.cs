namespace EasyGold.API.Models
{
    public class BaseResponse<T>
    {
        public T result { get; set; }

        public BaseResponse() { }

        public BaseResponse(T item)
        {
            result = item;
        }
    }
}
