﻿using Azure.Storage.Blobs;
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

        public async Task<BlobResponseDto> UploadAsync(IFormFile file, string containerName, CancellationToken cancellationToken)
        {
            BlobContainerClient containerClient = new BlobContainerClient(_connectionString, containerName);
            var response = new BlobResponseDto();

            try
            {
                var extension = Path.GetExtension(file.FileName);
                BlobClient blob = containerClient.GetBlobClient($"{Guid.NewGuid()}{extension}");
            
                await using (Stream stream = file.OpenReadStream())
                {
                    await blob.UploadAsync(stream, cancellationToken);
                }
                response.ImageUrl = blob.Uri.AbsoluteUri;
                response.ImageName = blob.Name;
            }
            catch (Exception) 
            {
            }

            return response;
        }

        public async Task DeleteAsync(string blobFilename, string containerName, CancellationToken cancellationToken)
        {
            BlobContainerClient containerClient = new BlobContainerClient(_connectionString, containerName);
            BlobClient file = containerClient.GetBlobClient(blobFilename);
            
            try
            {
                await file.DeleteAsync(Azure.Storage.Blobs.Models.DeleteSnapshotsOption.None, null, cancellationToken);
            }
            catch (Exception)
            {
            }
        }
    }
}
