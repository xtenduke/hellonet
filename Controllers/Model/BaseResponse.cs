public class BaseResponse
{
    public long Time { get {
         return (long)((DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds / 1000); 
    } }
}