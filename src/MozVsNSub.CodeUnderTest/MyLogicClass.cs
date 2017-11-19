namespace MozVsNSub.CodeUnderTest
{
    using System;

    public class MyLogicClass
    {
        private readonly IMyServiceClass serviceClass;
        public MyLogicClass(IMyServiceClass serviceClass)
        {
            this.serviceClass = serviceClass;
        }

        public IMyWidget GetWidgetWithCompanyDiscount(string companyName)
        {
            decimal discount;
            IMyWidget widget;
            switch (companyName)
            {
                case "Acme":
                    discount = (decimal).1;
                    widget = this.serviceClass.GetWidget(Guid.NewGuid());
                    break;
                case "Cisco":
                    discount = (decimal).12;
                    widget = this.serviceClass.GetWidget(name: "CiscoWidgetName", description: "widgetDescription", reference: "CiscoRef");
                    break;
                case "GeneralElectric":
                    discount = (decimal).15;
                    widget = this.serviceClass.GetWidget(name: "GEWidgetName", description: "GEWidgetDescription", reference: "GERef");
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Failed to resolve discount for {companyName}");
            }

            widget.Price = this.CalculateDiscount(price: widget.Price, discount: discount);
            return widget;
        }

        private decimal CalculateDiscount(decimal price, decimal discount)
        {
            var result = price - (price * discount);
            return result;
        }
    }
}
