using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Bll.Interfaces;
using VolunteeringPlatform.Common.Dtos.Blob;

namespace VolunteeringPlatform.Bll.Services
{
    public class AzureStorageService : IAzureStorageService
    {
        private readonly string _connectionString;

        public AzureStorageService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BlobConnectionString");
        }

        public async Task<BlobResponseDto> UploadAsync(IFormFile file, string containerName)
        {
            BlobContainerClient container = new BlobContainerClient(_connectionString, containerName);
            var response = new BlobResponseDto();

            try
            {
                BlobClient blob = container.GetBlobClient(Guid.NewGuid().ToString());
            
                await using (Stream stream = file.OpenReadStream())
                {
                    await blob.UploadAsync(stream);
                }
                response.ImageUrl = blob.Uri.AbsoluteUri;
                response.ImageName = blob.Name;
            }
            catch (Exception) 
            {
            }

            return response;
        }
    }
}
