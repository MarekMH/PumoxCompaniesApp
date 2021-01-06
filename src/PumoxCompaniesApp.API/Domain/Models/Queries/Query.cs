namespace PumoxCompaniesApp.API.Domain.Models.Queries
{
    public class Query
    {
        public int Page { get; protected set; }
        public int itemsPerPage { get; protected set; }

        public Query(int page, int itempsPerPage)
        {
            Page = page;
            this.itemsPerPage = itempsPerPage;

            if (Page <= 0)
            {
                Page = 1;
            }

            if (this.itemsPerPage <= 0)
            {
                this.itemsPerPage = 10;
            }
        }
    }
}