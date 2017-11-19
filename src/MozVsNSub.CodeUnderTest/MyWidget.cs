namespace MozVsNSub.CodeUnderTest
{
    using System;

    public class MyWidget : IMyWidget
    {
        public Guid GuidId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public decimal Price { get; set; }
    }
}
