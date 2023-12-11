using CarAdvertisementService.Interfaces;

namespace CarAdvertisementService
{
    public class CarAdvertisementService
    {
        private IRepository<CarAdvertisement> _repository;

        public CarAdvertisementService(IRepository<CarAdvertisement> repository)
        {
            _repository = repository
                ?? throw new ArgumentException(nameof(repository));
        }

        public IReadOnlyCollection<CarAdvertisement> FindByPrice(int lowestPrice, int highestPrice)
        {
            var ads = _repository.GetEntities();

            return ads.Where(item => item.Price >= lowestPrice || item.Price <= highestPrice).ToArray();
        }

        public void Save()
        {
            _repository.SaveEntities();
        }
    }
}