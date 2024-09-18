namespace Personal_Project.Helper
{
    public class DeleteHandler
    {
        private readonly string _imagesFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
        public bool DeleteImage(string imageName)
        {
            try
            {
                string filePath = Path.Combine(_imagesFolderPath, imageName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }
                return false;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error deleting image: {ex.Message}");
                return false;
            }
        }
    }
}
