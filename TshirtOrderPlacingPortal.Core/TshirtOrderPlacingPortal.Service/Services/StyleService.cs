using System;
using System.Threading.Tasks;
using TshirtOrderPlacingPortal.DTO.Models;
using TshirtOrderPlacingPortal.Infrastructure.Configuration.Contract;
using TshirtOrderPlacingPortal.Infrastructure.Configuration.Repository;

namespace TshirtOrderPlacingPortal.Service
{
    public class StyleService : IStyle
    {
        private readonly IUnitOfWork _unitOfWork;



        public StyleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public Task<bool> Add(Style entity)
        {
            var result = _unitOfWork.Style.Add(entity);
            _unitOfWork.Complete();
            return result;
        }



        public Task<System.Collections.Generic.IEnumerable<Style>> All()
        {
            return _unitOfWork.Style.All();
        }



        public Task<bool> Delete(int id)
        {
            var result = _unitOfWork.Style.Delete(id);
            _unitOfWork.Complete();
            return result;
        }


        public Task<Style> GetById(int id)
        {
            return _unitOfWork.Style.GetById(id);
        }



        public Task<bool> Upsert(Style entity)
        {
            var result = _unitOfWork.Style.Upsert(entity);
            _unitOfWork.Complete();
            return result;
        }
    }
}
