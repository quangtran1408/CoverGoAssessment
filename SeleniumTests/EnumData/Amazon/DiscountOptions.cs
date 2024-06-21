
namespace SeleniumTests.EnumData.Amazon
{
    public enum DiscountOptions
    {
        All,
        [System.ComponentModel.Description("10% off or more")] Dis10PercentageMore,
        [System.ComponentModel.Description("25% off or more")] Dis25PercentageMore,
        [System.ComponentModel.Description("50% off or more")] Dis50PercentageMore,
        [System.ComponentModel.Description("70% off or more")] Dis70PercentageMore
    }
}
