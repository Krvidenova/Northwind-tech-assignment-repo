namespace Northwind.WebAPI.Tests.Mocks
{
    using AutoMapper;
    using Northwind.WebAPI.Mapping;

    public static class MockAutoMapper
    {
        static MockAutoMapper()
        {
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
        }

        public static IMapper GetAutoMapper() => Mapper.Instance;
    }
}
