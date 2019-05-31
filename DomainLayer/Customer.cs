namespace DomainLayer
{
    public class Customer
    {
        public Customer(string _customerName, string _customerAddress, string _customerEmail, string _customerPhone, string _customerZipCity)
        {
            CustomerName = _customerName;
            CustomerAddress = _customerAddress;
            CustomerEmail = _customerEmail;
            CustomerPhone = _customerPhone;
            CustomerZipCity = _customerZipCity;
        }

        public Customer() { }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }
       
        public string CustomerEmail { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerZipCity { get; set; }
    }
}