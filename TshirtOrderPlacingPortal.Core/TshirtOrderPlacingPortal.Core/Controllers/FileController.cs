
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using TshirtOrderPlacingPortal.DTO.Models;
using TshirtOrderPlacingPortal.Infrastructure.Configuration.Contract;

namespace TshirtOrderPlacingPortal.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFile _fileRepository;
        public FileController(IFile file)
        {
            _fileRepository = file;
        }
        [HttpPost]
        public ActionResult Post([FromForm] FileModel file)
        {
            try
            {

                Files imageFile = new Files();
                imageFile.FileName = file.FileName;

                //Convveryting Image into memorystream to get byte array
                MemoryStream ms = new MemoryStream();
                file.FormFile.CopyTo(ms);
                imageFile.FileData = ms.ToArray();

                //open stream disposed to prevent memory leak
                ms.Close();
                ms.Dispose();

                //Storing byte array into database
                _fileRepository.Add(imageFile);

                return StatusCode(StatusCodes.Status201Created);
            }


            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{filename}")]
        public ActionResult GetByFileName(string filename)
        {
            FilesRetrieve filesRetrieve = new FilesRetrieve();
            try
            {
                var data = _fileRepository.GetByFileName(filename).FileData;
                
                //Converting Binary data into 64String type to data imageUrl
                string imageBase64Data = Convert.ToBase64String(data);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                filesRetrieve.FileName = "";
                filesRetrieve.ImageUrl = imageDataURL ;
                return Ok(filesRetrieve);
            }
            catch(Exception ex)
            {
                return Ok(filesRetrieve);
            }
           
        }

    }
}
