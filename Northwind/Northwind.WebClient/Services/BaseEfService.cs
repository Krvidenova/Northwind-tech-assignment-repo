namespace Northwind.WebClient.Services
{
    using AutoMapper;
    using Northwind.WebClient.Infrastructure.ApiClient;

    public abstract class BaseEfService
    {
        protected BaseEfService(NorthwindClient northwindClient, IMapper mapper)
        {
            this.NorthwindClient = northwindClient;
            this.Mapper = mapper;
        }

        protected NorthwindClient NorthwindClient { get; private set; }

        protected IMapper Mapper { get; private set; }
    }
}
