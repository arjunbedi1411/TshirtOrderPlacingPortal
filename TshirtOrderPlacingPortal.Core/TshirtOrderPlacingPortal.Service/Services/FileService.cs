using System;
using System.Threading.Tasks;
using TshirtOrderPlacingPortal.DTO.Models;
using TshirtOrderPlacingPortal.Infrastructure.Configuration.Contract;
using TshirtOrderPlacingPortal.Infrastructure.Configuration.Repository;

namespace TshirtOrderPlacingPortal.Service
{
    public class FileService : IFile
    {
        private readonly IUnitOfWork _unitOfWork;



        public FileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public Task<bool> Add(Files entity)
        {
            try
            {
                var result = _unitOfWork.Files.Add(entity);
                _unitOfWork.Complete();
                return result;

            }
            catch(Exception e)
            {
                throw e;
            }
        }



        public Task<System.Collections.Generic.IEnumerable<Files>> All()
        {
            return _unitOfWork.Files.All();
        }



        public Task<bool> Delete(int id)
        {
            var result = _unitOfWork.Files.Delete(id);
            _unitOfWork.Complete();
            return result;
        }


        public Task<Files> GetById(int id)
        {
            return _unitOfWork.Files.GetById(id);
        }

        public Files GetByFileName(string fileName)
        {
            return _unitOfWork.Files.GetByFileName(fileName);

        }


        public Task<bool> Upsert(Files entity)
        {
            var result = _unitOfWork.Files.Upsert(entity);
            _unitOfWork.Complete();
            return result;
        }
    }
}
