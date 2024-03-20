using Imagestore.Data;
using Imagestore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using Mysqlx.Notice;
using System.Data.Entity;

namespace Imagestore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly AppDbContext _dbContext;


        public ImagesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpPost]
        public async Task<IActionResult> Upload(ImageApi image)
        {

            var imageEntity = new ImageEntity();
            

            byte[] byteArray = Encoding.ASCII.GetBytes(image.Data);
    
             imageEntity.Data = byteArray;
             //imageEntity.Data = Convert.;
            imageEntity.FileName= image.FileName;
            imageEntity.Id = image.Id;
          
            await _dbContext.Images.AddAsync(imageEntity);
            await _dbContext.SaveChangesAsync();
            return Ok(imageEntity.FileName);
        }


        //[HttpGet("{id}")]
        //public async Task<IActionResult> Download(int id)
        //{
        //    var imageEntity =  _dbContext.Images.Find(id);

        //    if (imageEntity == null)
        //        return NotFound();


        //    return Ok(Encoding.ASCII.GetString(imageEntity.Data));
        //}

        [HttpGet]
        public ActionResult<IEnumerable<ImageApi>> GetAll()
        {
            var imageslist = _dbContext.Images.Select(i =>  new ImageApi
            {
                Id = i.Id,
                FileName = i.FileName,
                Data = Encoding.ASCII.GetString(i.Data)
            }).ToList();
            return Ok(imageslist);

        }




    }
}
