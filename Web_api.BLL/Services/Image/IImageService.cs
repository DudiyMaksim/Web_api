using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Web_api.BLL.Services.Image
{
    public interface IImageService
    {
        Task<string?> SaveImageAsync(IFormFile image, string filePath);
        void DeleteImage(string directory);
        Task<List<string>> SaveProductImagesAsync(List<IFormFile> images, string path);
    }
}
