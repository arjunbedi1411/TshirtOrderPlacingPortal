using System;
using System.Threading.Tasks;
using TshirtOrderPlacingPortal.DTO.Models;
using TshirtOrderPlacingPortal.Infrastructure.Configuration.Contract;
using TshirtOrderPlacingPortal.Infrastructure.Configuration.Repository;

namespace TshirtOrderPlacingPortal.Service
{
    public class SizeService : ISize
    {
        private readonly IUnitOfWork _unitOfWork;



        public SizeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public Task<bool> Add(Size entity)
        {
            var result = _unitOfWork.Size.Add(entity);
            _unitOfWork.Complete();
            return result;
        }



        public Task<System.Collections.Generic.IEnumerable<Size>> All()
        {
            return _unitOfWork.Size.All();
        }



        public Task<bool> Delete(int id)
        {
            var result = _unitOfWork.Size.Delete(id);
            _unitOfWork.Complete();
            return result;
        }


        public Task<Size> GetById(int id)
        {
            return _unitOfWork.Size.GetById(id);
        }



        public Task<bool> Upsert(Size entity)
        {
            var result = _unitOfWork.Size.Upsert(entity);
            _unitOfWork.Complete();
            return result;
        }
    }
}
