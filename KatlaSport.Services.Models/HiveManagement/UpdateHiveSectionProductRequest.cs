namespace KatlaSport.Services.HiveManagement
{
    public class UpdateHiveSectionProductRequest
    {
        /// <summary>
        /// Gets or sets a product ID.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets a store hive section id.
        /// </summary>
        public int HiveSectionId { get; set; }

        /// <summary>
        /// Gets or sets product amount.
        /// </summary>
        public int Quantity { get; set; }
    }
}
