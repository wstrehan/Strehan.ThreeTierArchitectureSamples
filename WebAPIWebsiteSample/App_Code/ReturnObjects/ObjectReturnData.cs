public class ObjectReturnData<T> : ReturnData
{
    public string Id { get; set; }
    public T Value { get; set; }
}