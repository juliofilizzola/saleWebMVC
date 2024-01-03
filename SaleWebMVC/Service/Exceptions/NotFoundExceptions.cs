namespace SaleWebMVC.Service.Exceptions
{
    public class NotFoundException(string message) : ApplicationException(message);
}