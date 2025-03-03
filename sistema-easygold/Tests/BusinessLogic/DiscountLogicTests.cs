
using Xunit;

public class DiscountLogicTests
{
    public class DiscountCalculator
    {
        public decimal CalculateDiscount(decimal amount, bool isPremiumCustomer)
        {
            if (isPremiumCustomer)
            {
                return amount * 0.20m; // 20% discount for premium customers
            }
            return amount * 0.10m; // 10% discount for regular customers
        }
    }

    [Fact]
    public void PremiumCustomer_Receives20PercentDiscount()
    {
        // Arrange
        var calculator = new DiscountCalculator();
        decimal amount = 100m;
        bool isPremiumCustomer = true;

        // Act
        var discount = calculator.CalculateDiscount(amount, isPremiumCustomer);

        // Assert
        Assert.Equal(20m, discount);
    }

    [Fact]
    public void RegularCustomer_Receives10PercentDiscount()
    {
        // Arrange
        var calculator = new DiscountCalculator();
        decimal amount = 100m;
        bool isPremiumCustomer = false;

        // Act
        var discount = calculator.CalculateDiscount(amount, isPremiumCustomer);

        // Assert
        Assert.Equal(10m, discount);
    }
}
