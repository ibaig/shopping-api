namespace Shopping.Api.Domain.ProductSorter
{
    public enum ProductSorterType
    {
        /// <summary>
        /// Low to High Price
        /// </summary>
        Low,
        /// <summary>
        /// High to Low Price
        /// </summary>
        High,
        /// <summary>
        /// A - Z sort on the Name
        /// </summary>
        Ascending,
        /// <summary>
        /// Z - A sort on the Name
        /// </summary>
        Descending,
        /// <summary>
        /// this will call the "shopperHistory" resource to get a list of customers orders and needs to return based on popularity
        /// </summary>
        Recommended
    }
}
