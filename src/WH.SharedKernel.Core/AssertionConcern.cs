using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace WH.SharedKernel;

public class AssertionConcern
{
    public static void ValidateNullOrDefault<T>(T value, string message)
    {
        if (value is null || EqualityComparer<T>.Default.Equals(value, default!))
        {
            throw new DomainException(message);
        }
    }

    public static void ValidateLessThanMinimum<T>(T value, T minimum, string message)
        where T : IComparable
    {
        if (minimum.CompareTo(value) > 0)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidateLessThanEqualToMinimum<T>(T value, T minimum, string message)
        where T : IComparable
    {
        if (minimum.CompareTo(value) >= 0)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidateNullOrEmpty(string value, string message)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new DomainException(message);
        }
    }

    public static void ValidateNullOrWhiteSpace(string value, string message)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException(message);
        }
    }

    public static void ValidateMaxLength(string value, int maxLength, string message)
    {
        if (value.Length > maxLength)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidateMinLength(string value, int minLength, string message)
    {
        if (value.Length < minLength)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidateEmailAddress(string value, string message)
    {
        try
        {
            var mailAddress = new MailAddress(value);

            if (mailAddress.Address != value)
            {
                throw new DomainException(message);
            }
        }
        catch (Exception)
        {
            throw new DomainException(message);
        }
    }
}
