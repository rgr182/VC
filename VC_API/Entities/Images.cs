﻿using Microsoft.CSharp;

namespace VC_API.Entities
{
    public class Images
    {
        public int Id { get; set; }
        public int PetId {  get; set; }
        public required IFormFile File { get; set; }
    }
}