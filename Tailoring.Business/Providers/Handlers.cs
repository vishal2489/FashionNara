using System.Collections.Generic;
using Tailoring.Data;
using Tailoring.Models;

namespace Tailoring.Domain.Providers {
    public class Handler<TEntity>: IHandler<TEntity> where TEntity : EntityBase {
        private IRepository<TEntity> _repository;
        public Handler(IRepository<TEntity> repository) {
            _repository = repository;
        }

        //public void CreateProduct(Product product) {
        //     _productRepository.CreateProduct(product);
        //}
        public void Delete(TEntity entity) {
            _repository.Delete(entity);
        }

        public IEnumerable<TEntity> GetAll() {
            return _repository.GetAll();
        }


        public void Insert(TEntity entity) {
            _repository.Insert(entity);
        }

        public TEntity Save(TEntity entity) {
            return _repository.Save(entity);
        }

        public void Update(TEntity entity) {
            _repository.Update(entity);
        }
    }
    public interface IHandler<TEntity> where TEntity : EntityBase {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity Save(TEntity entity);
    }
}