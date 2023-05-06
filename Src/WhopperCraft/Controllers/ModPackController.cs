// ModPackController.cs

using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace WhopperCraft.Controllers
{
    public class ModPackController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Download()
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "lib", "mods.zip");

            if (!System.IO.File.Exists(file))
                return NotFound();

            var memory = new MemoryStream();
            using (var stream = new FileStream(file, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, "application/octet-stream", Path.GetFileName(file));
        }
    }

}
