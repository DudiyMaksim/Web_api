﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Web_api.BLL.Services.Image
{
    public class ImageService : IImageService
    {
        public void DeleteImage(string filePath)
        {
            if (string.IsNullOrEmpty(Settings.ImagesPath))
            {
                return;
            }

            string workPath = Path.Combine(Settings.ImagesPath, filePath);

            if (File.Exists(workPath))
            {
                File.Delete(workPath);
            }
        }

        public async Task<string?> SaveImageAsync(IFormFile image, string directory)
        {
            if (string.IsNullOrEmpty(Settings.ImagesPath))
            {
                return null;
            }

            var types = image.ContentType.Split('/');

            if (types[0] == "image")
            {
                string imageName = $"{Guid.NewGuid()}.{types[1]}";
                string workPath = Path.Combine(Settings.ImagesPath, directory);
                string filePath = Path.Combine(workPath, imageName);

                if (!Directory.Exists(workPath))
                {
                    Directory.CreateDirectory(workPath);
                }

                using (var stream = File.Create(filePath))
                {
                    await image.CopyToAsync(stream);
                }

                return imageName;
            }

            return null;
        }

        public async Task<ServiceResponse> SaveProductImagesAsync(List<IFormFile> images, string path)
        {
            List<string> imagesName = new List<string>();

            foreach (var image in images)
            {
                string? imageName = await SaveImageAsync(image, path);
                if (imageName != null)
                {
                    imagesName.Add(imageName);
                }
            }

            return ServiceResponse.Success("Картинки збережені");
        }
    }
}
