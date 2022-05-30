﻿namespace VolunteeringPlatform.Common.Dtos.Organization
{
    public class OrganizationDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Description { get; set; }
        public string? Locality { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
    }
}
