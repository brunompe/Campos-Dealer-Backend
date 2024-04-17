namespace Campos_Dealer_Backend.Models
{
    public class ServiceResponse<T>
    {
        public T? Dados { get; set; }

        public string Message { get; set; } = string.Empty;

        public bool Success { get; set; } = true;
    }
}
