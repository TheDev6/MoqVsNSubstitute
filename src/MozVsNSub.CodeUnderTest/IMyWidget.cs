using System;

namespace MozVsNSub.CodeUnderTest
{
    public interface IMyWidget
    {
        Guid GuidId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
    }
}