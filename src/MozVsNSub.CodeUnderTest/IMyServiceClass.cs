using System;

namespace MozVsNSub.CodeUnderTest
{
    public interface IMyServiceClass
    {
        IMyWidget GetWidget(Guid guidId);
        IMyWidget GetWidget(string name, string description, string reference);
    }
}