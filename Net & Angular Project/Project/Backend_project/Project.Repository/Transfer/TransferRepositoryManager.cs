

using MediatR;
using Project.Contracts;

namespace Project.Repository;

public  class TransferRepositoryManager:ITransferRepositoryManager{

        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ITransferRepository> _transferRepository;
        private readonly Lazy<ITransferOperationRepository> _transferOperationRepository;
        private readonly Lazy<ITransferHistoryRepository> _transferHistoryRepository;

        public TransferRepositoryManager(RepositoryContext repositoryContext){

            _repositoryContext = repositoryContext;
            _transferRepository = new Lazy<ITransferRepository>(()=>new TransferRepository(repositoryContext));
            _transferOperationRepository = new Lazy<ITransferOperationRepository>(()=>new TransferOperationRepository(repositoryContext));
            _transferHistoryRepository = new Lazy<ITransferHistoryRepository>(()=>new TransferHistoryRepository(repositoryContext));
        }


        public ITransferRepository Transfer => _transferRepository.Value;
        public ITransferOperationRepository TransferOperation => _transferOperationRepository.Value;
        public ITransferHistoryRepository TransferHistory => _transferHistoryRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesStockAsync();
}