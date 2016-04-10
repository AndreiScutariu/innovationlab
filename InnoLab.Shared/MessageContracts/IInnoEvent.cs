using System;

namespace MessageContracts
{
    public interface IInnoEvent
    {
        string What { get; set; }

        DateTime When { get; set; }
    }
}
