
using SLG.Shared.DTOs;

namespace SLG.Application.Services.Interfaces
{
    public interface IFileUploadingService
    {
        Task UploadImageAsync(FileDTO fileDTO);
    }
}
