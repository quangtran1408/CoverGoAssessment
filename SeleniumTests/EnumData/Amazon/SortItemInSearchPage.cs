

namespace SeleniumTests.EnumData.Amazon
{
    public enum SortItemInSearchPage
    {
        Featured,
        [System.ComponentModel.Description("Price: Low to high")] LowToHigh,
        [System.ComponentModel.Description("Price: High to low")] HighToLow,
        [System.ComponentModel.Description("Avg. Customer review")] AvgCustomerReview,
        [System.ComponentModel.Description("Newest arrivals")] NewestArrivals


    }
}
