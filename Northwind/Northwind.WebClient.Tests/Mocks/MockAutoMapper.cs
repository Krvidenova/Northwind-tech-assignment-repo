namespace Northwind.WebClient.Tests.Mocks
{
    using AutoMapper;
    using Northwind.WebClient.Mapping;

    public static class MockAutoMapper
    {
        static MockAutoMapper()
        {
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
        }

        public static IMapper GetAutoMapper() => Mapper.Instance;
    }
}
