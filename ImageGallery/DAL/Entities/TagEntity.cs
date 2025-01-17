﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImageGallery.DAL.Entities
{
    public class TagEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IList<ImageEntity> Images { get; set; } = new List<ImageEntity>();
    }
}
