using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.HiveManagement
{
    public interface IHiveSectionProductService
    {
        /// <summary>
        /// Gets a list of hive section products.
        /// </summary>
        /// <returns>A <see cref="Task{List{HiveSectionProduct}}"/>.</returns>
        Task<List<HiveSectionProduct>> GetHiveSectionProductsAsync();

        /// <summary>
        /// Gets a product.
        /// </summary>
        /// <param name="id">A hive section product identifier.</param>
        /// <returns>A <see cref="Task{HiveSectionProduct}"/>.</returns>
        Task<HiveSectionProduct> GetHiveSectionProductAsync(int id);

        /// <summary>
        /// Gets a list of hive sections for specified hive section.
        /// </summary>
        /// <param name="hiveSectionId">A hive section identifier.</param>
        /// <returns>A <see cref="Task{List{HiveSectionProduct}}"/>.</returns>
        Task<List<HiveSectionProduct>> GetHiveSectionProductsAsync(int hiveSectionId);

        /// <summary>
        /// Creates a new hive section product.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateHiveSectionProductRequest"/>.</param>
        /// <returns>A <see cref="Task{HiveSection}"/>.</returns>
        Task<HiveSectionProduct> CreateHiveSectionProductAsync(UpdateHiveSectionProductRequest createRequest);

        /// <summary>
        /// Updates an existed hive section product.
        /// </summary>
        /// <param name="productId">A hive section product identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateHiveSectionProductRequest"/>.</param>
        /// <returns>A <see cref="Task{HiveSectionProduct}"/>.</returns>
        Task<HiveSectionProduct> UpdateHiveSectionProductAsync(int productId, UpdateHiveSectionProductRequest updateRequest);

        /// <summary>
        /// Deletes an existed hive section product.
        /// </summary>
        /// <param name="productId">A hive section product identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteHiveSectionProductAsync(int productId);

        /// <summary>
        /// Sets deleted status for a hive section product.
        /// </summary>
        /// <param name="productId">A hive section product identifier.</param>
        /// <param name="deletedStatus">Status.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task SetStatusAsync(int productId, bool deletedStatus);

        /// <summary>
        /// Sets delivered status for a hive section product.
        /// </summary>
        /// <param name="productId">A hive section product identifier.</param>
        /// <param name="deliveredStatus">Status.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task SetDeliverStatusAsync(int productId, bool deliveredStatus);
    }
}
