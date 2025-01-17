﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImageGallery.DAL.Entities
{
    public class ImageEntity
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

        public virtual IList<TagEntity> Tags { get; set; } = new List<TagEntity>();
    }
}
