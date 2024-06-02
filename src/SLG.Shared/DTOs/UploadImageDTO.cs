using SLG.Shared.Attributes;
using Microsoft.AspNetCore.Http;
using SLG.Shared.Attributes;

namespace SLG.Shared.DTOs
{
    public record UploadImageDTO
    {
        [MaxFileSize(1048576)] // 1 MB
        [AllowedFileExtensions("jpg,png,gif,jpeg")]
        public IFormFile File { get; set; } = default!;
    }
}
