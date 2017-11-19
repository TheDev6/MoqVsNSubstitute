namespace MoqVsNSub.Tests
{
    using System;
    using FluentAssertions;
    using Moq;
    using MozVsNSub.CodeUnderTest;
    using Xunit;
    using NSubstitute;

    public class MyLogicClass_Tests
    {
        [Theory]
        [InlineData("Acme", .1)]
        [InlineData("Cisco", .12)]
        [InlineData("GeneralElectric", .15)]
        public void GetWidgetWithCompanyDiscount_NSub(string companyName, decimal matchingDiscount)
        {
            //arrange
            var service = Substitute.For<IMyServiceClass>();
            var widget = new MyWidget
            {
                Price = 100,
                GuidId = Guid.NewGuid(),
                Description = "Description",
                Name = "Name"
            };

            var expectedPrice = widget.Price - (widget.Price * matchingDiscount);
            service.GetWidget(guidId: Arg.Any<Guid>())
                .Returns(widget);
            service.GetWidget(
                name: Arg.Any<string>(),
                description: Arg.Any<string>(),
                reference: Arg.Any<string>())
                .Returns(widget);

            var sut = new MyLogicClass(service);

            //act
            var result = sut.GetWidgetWithCompanyDiscount(companyName);

            //assert
            result.Price.Should().Be(expectedPrice);
        }

        [Theory]
        [InlineData("Acme", .1)]
        [InlineData("Cisco", .12)]
        [InlineData("GeneralElectric", .15)]
        public void GetWidgetWithCompanyDiscount_Moq(string companyName, decimal matchingDiscount)
        {
            //arrange
            var service = new Mock<IMyServiceClass>();
            var widget = new MyWidget
            {
                Price = 100,
                GuidId = Guid.NewGuid(),
                Description = "Description",
                Name = "Name"
            };
            service.Setup(s => s.GetWidget(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()
            )).Returns(widget);
            service.Setup(s => s.GetWidget(It.IsAny<Guid>())).Returns(widget);
            var expectedPrice = widget.Price - (widget.Price * matchingDiscount);

            var sut = new MyLogicClass(service.Object);

            //act
            var result = sut.GetWidgetWithCompanyDiscount(companyName);

            //assert
            result.Price.Should().Be(expectedPrice);
        }

    }
}
