﻿using System;

namespace WH.SharedKernel;

public class DomainException : Exception
{
    public DomainException(string message)
        : base(message) { }
}
