namespace HHApi.Models
{
    public interface IProduct
    {
        string Description { get; set; }
        double Id { get; set; }
        decimal Price { get; set; }
    }
}