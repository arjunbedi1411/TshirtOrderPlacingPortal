using System;
using System.Threading.Tasks;
using TshirtOrderPlacingPortal.DTO.Models;
using TshirtOrderPlacingPortal.Infrastructure.Configuration.Contract;
using TshirtOrderPlacingPortal.Infrastructure.Configuration.Repository;

namespace TshirtOrderPlacingPortal.Service
{
    public class TshirtService : ITshirt
    {
        private readonly IUnitOfWork _unitOfWork;



        public TshirtService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public Task<bool> Add(TShirt entity)
        {
            //adding UTC DateTime;
            entity.ProdutionAdditionDate = DateTime.UtcNow;
            var result = _unitOfWork.Tshirt.Add(entity);
            _unitOfWork.Complete();
            return result;
        }



        public Task<System.Collections.Generic.IEnumerable<TShirt>> All()
        {
            return _unitOfWork.Tshirt.All();
        }



        public Task<bool> Delete(int id)
        {
            var result = _unitOfWork.Tshirt.Delete(id);
            _unitOfWork.Complete();
            return result;
        }


        public Task<TShirt> GetById(int id)
        {
            return _unitOfWork.Tshirt.GetById(id);
        }



        public Task<bool> Upsert(TShirt entity)
        {
            var result = _unitOfWork.Tshirt.Upsert(entity);
            _unitOfWork.Complete();
            return result;
        }
    }
}
