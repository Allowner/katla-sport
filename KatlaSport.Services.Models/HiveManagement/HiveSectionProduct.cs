namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents a product in a hive section.
    /// </summary>
    public class HiveSectionProduct
    {
        /// <summary>
        /// Gets or sets a section product identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a product ID.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets a product quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a store hive section id.
        /// </summary>
        public int HiveSectionId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a product is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a product is delivered.
        /// </summary>
        public bool IsDelivered { get; set; }
    }
}
