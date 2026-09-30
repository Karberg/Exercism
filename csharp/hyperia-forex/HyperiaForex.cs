using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    // TODO: implement equality operators
    public static bool operator ==(CurrencyAmount left, CurrencyAmount right)
    {
        EnsureSameCurrency(left, right);

        if (left.amount == right.amount)
        {
            return true;
        }
        else return false;
    }

    public static bool operator !=(CurrencyAmount left, CurrencyAmount right)
    {
        EnsureSameCurrency(left, right);

        if (left.amount != right.amount)
        {
            return true;
        }
        return false;
    }

    // TODO: implement comparison operators
    public static bool operator >(CurrencyAmount left, CurrencyAmount right)
    {
        EnsureSameCurrency(left, right);

        if (left.amount > right.amount)
        {
            return true;
        }
        return false;
    }
    public static bool operator <(CurrencyAmount left, CurrencyAmount right)
    {
        EnsureSameCurrency(left, right);

        if (left.amount < right.amount)
        {
            return true;
        }
        return false;
    }

    // TODO: implement arithmetic operators
    public static CurrencyAmount operator +(CurrencyAmount left, CurrencyAmount right)
    {
        EnsureSameCurrency(left, right);

        return new CurrencyAmount(left.amount + right.amount, left.currency);
    }
    public static CurrencyAmount operator -(CurrencyAmount left, CurrencyAmount right)
    {
        EnsureSameCurrency(left, right);

        return new CurrencyAmount(left.amount - right.amount, left.currency);
    }
    public static CurrencyAmount operator *(CurrencyAmount left, CurrencyAmount right)
    {
        EnsureSameCurrency(left, right);

        return new CurrencyAmount(left.amount * right.amount, left.currency);
    }
    public static CurrencyAmount operator /(CurrencyAmount left, CurrencyAmount right)
    {
        EnsureSameCurrency(left, right);

        return new CurrencyAmount(left.amount / right.amount, left.currency);
    }

    // TODO: implement type conversion operators
    public static explicit operator double(CurrencyAmount value)
    {
        return (double)value.amount;
    }
    public static implicit operator decimal(CurrencyAmount value)
    {
        return value.amount;
    }

    // Helpers
    private static void EnsureSameCurrency(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency)
            throw new ArgumentException();
    }
}
