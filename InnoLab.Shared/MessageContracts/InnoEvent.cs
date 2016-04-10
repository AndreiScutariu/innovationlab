using System;

namespace MessageContracts
{
    public class InnoEvent : IInnoEvent
    {
        public string What { get; set; }

        public DateTime When { get; set; }
    }
}