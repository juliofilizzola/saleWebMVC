namespace SaleWebMVC.Service.Exceptions;

public class DbConcurrencyException(string message) : ApplicationException(message) {}