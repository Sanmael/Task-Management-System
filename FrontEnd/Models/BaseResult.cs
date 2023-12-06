namespace FrontEnd.Models
{
    public class BaseResult<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;


        public BaseResult()
        {
            
        }
    }
}
