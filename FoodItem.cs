namespace FoodBankLibrary
{
    // Object that holds information about the food.
    public class FoodItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }

        // Function for food
        public FoodItem(string name, string category, int quantity, DateTime expirationDate)
        {
            Name = name;

            Category = category;

            Quantity = quantity;

            ExpirationDate = expirationDate;
        }
        public override string ToString()
        {
            // Output
            return $"Name: {Name}, Category: {Category}, Quantity: {Quantity}, Expiration Date: {ExpirationDate.ToShortDateString()}";
        }
    }
}