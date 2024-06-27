using Application.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _environment;

    public FileService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<string> SaveFileAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentNullException(nameof(file), "File is empty");

        if (string.IsNullOrEmpty(_environment.WebRootPath))
            throw new InvalidOperationException("WebRootPath is not set.");

        var uploadFolder = Path.Combine(_environment.WebRootPath, "uploads");
        if (!Directory.Exists(uploadFolder))
            Directory.CreateDirectory(uploadFolder);

        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(uploadFolder, fileName);
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        var relativeFilePath = Path.Combine("uploads", fileName).Replace("\\", "/");
        return relativeFilePath;
    }
}
