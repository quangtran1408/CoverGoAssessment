using Newtonsoft.Json;

namespace SeleniumTests.DataObject.Amazon
{
    public class AmazonProduct
    {
        private string name { get; set; }
        private string deal { get; set; }

        public AmazonProduct() { }

        public AmazonProduct(string name, string deal)
        {
            this.name = name;
            this.deal = deal;
        }

        public string getName()
        {
            return name;
        }

        public string getDeal()
        {
            return deal;
        }

        

    }
}
