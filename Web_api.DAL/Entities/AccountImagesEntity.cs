using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spr311_web_api.DAL.Entities.Identity;

namespace Web_api.DAL.Entities
{
    public class AccountImagesEntity : BaseEntity<string>
    {
        public override string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Name { get; set; }
        public required string Path { get; set; }

        [ForeignKey("AppUser")]
        public required string UserId { get; set; }
        public AppUser? AppUser { get; set; }

        [NotMapped]
        public string ImagePath { get => System.IO.Path.Combine(Path, Name); }
    }
}
