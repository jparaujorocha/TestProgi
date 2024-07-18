namespace BidCalculationTool.Tests.Mock.Mapper {
    public class MapperMock {
        public static readonly IMapper mockMapper = CreateMockIMapper();

        private static IMapper CreateMockIMapper() {
            var mockMapper = new MapperConfiguration(cfg => {
                cfg.AddProfile(new VehicleProfile());
            });

            return mockMapper.CreateMapper();
        }
    }
}
