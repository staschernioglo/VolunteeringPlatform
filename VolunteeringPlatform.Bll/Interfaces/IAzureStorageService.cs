using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Common.Dtos.Blob;

namespace VolunteeringPlatform.Bll.Interfaces
{
    public interface IAzureStorageService
    {
        Task<BlobResponseDto> UploadAsync(IFormFile file, string containerName);
    }
}
