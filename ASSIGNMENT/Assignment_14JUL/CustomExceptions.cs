using System;

public class LoginFailedException : Exception
{
    public LoginFailedException()
        : base("Login Failed! Maximum attempts reached.")
    {
    }
}

public class InvalidPriceException : Exception
{
    public InvalidPriceException()
        : base("Price must be greater than 0.")
    {
    }
}

public class InvalidQuantityException : Exception
{
    public InvalidQuantityException()
        : base("Quantity must be greater than 0.")
    {
    }
}

public class DuplicateItemException : Exception
{
    public DuplicateItemException()
        : base("Item ID already exists.")
    {
    }
}

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException()
        : base("Item not found.")
    {
    }
}

public class InsufficientStockException : Exception
{
    public InsufficientStockException()
        : base("Insufficient Stock.")
    {
    }
}