namespace MozVsNSub.CodeUnderTest
{
    using System;

    public class MyServiceClass : IMyServiceClass
    {
        public IMyWidget GetWidget(Guid guidId)
        {
            return new MyWidget
            {
                GuidId = Guid.NewGuid(),
                Name = "SomeWidget",
                Description = "Widget known as SomeWidget",
                Price = (decimal)23.23
            };
        }

        public IMyWidget GetWidget(string name, string description, string reference)
        {
            return new MyWidget
            {
                GuidId = Guid.NewGuid(),
                Name = name,
                Description = description,
                Price = (decimal)34.23,
                Reference = Guid.NewGuid().ToString("N")
            };
        }
    }
}
