namespace Northwind.WebAPI.Services
{
    using AutoMapper;
    using Northwind.Data;

    public abstract class BaseEfService
    {
        protected BaseEfService(NorthwindDbContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        protected NorthwindDbContext Context { get; private set; }

        protected IMapper Mapper { get; private set; }
    }
}
