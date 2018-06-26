using System;

namespace Validator
{
    public interface IValidation
    {
        bool IsValid(string value);
    }
}
