namespace Personal_Project.Helper
{
        public class UploadHandler
        {
            public string Upload(IFormFile file)
            {
                List<string> validExtensions = new List<string>() { ".jpg", ".png", ".jpeg" };
                string extension = Path.GetExtension(file.FileName);
                if (!validExtensions.Contains(extension))
                {
                    return $"Extension is not supported ({string.Join(',', validExtensions)})";
                }

                long size = file.Length;
                    if (size > (5 * 1024 * 1024))
                    {
                        return "File size is too large";
                    }

                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + timestamp + extension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), "Images\\");
                Console.WriteLine(path);
                using FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
                file.CopyTo(stream);

                return fileName;
            }


        }
}
