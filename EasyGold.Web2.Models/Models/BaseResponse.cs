namespace EasyGold.Web2.Models
{
    public class BaseResponse<T>
    {
        public T result { get; set; }
        public BaseError error  { get; set; }   


        public BaseResponse() { }

        public BaseResponse(T item)
        {
            result = item;
        }
    }
}
