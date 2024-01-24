namespace Businesses_Accounting.Helper
{
    public static class FileHelper
    {
        public static List<string> SaveFiles(IEnumerable<IFormFile> postedFiles, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment, string folderName="", string fileName="")
        {
            string wwwPath = environment.WebRootPath;
            string contentPath = environment.ContentRootPath;
            List<string> fileNames = new List<string>();
            string path = Path.Combine(environment.WebRootPath, "Uploads") + (string.IsNullOrWhiteSpace(folderName) ? "" : $"/{folderName}");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (IFormFile postedFile in postedFiles)
            {
                string fullname = string.IsNullOrWhiteSpace(fileName) ? GenerateFileName() + Path.GetExtension(postedFile.FileName) : $"{fileName}.{Path.GetExtension(postedFile.FileName)}";
                if (ExistsFile($"{path}\\{fullname}"))
                {
                    fullname = GenerateFileName() + Path.GetExtension(postedFile.FileName);
                }
                using (FileStream stream = new FileStream(Path.Combine(path, fullname), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    fileNames.Add($"{path.Replace(wwwPath, "").Replace("\\", "/")}/{fullname}");
                }
            }
            return fileNames;
        }
        public static bool ExistsFile(string fullpath)
        {
            FileInfo fi = new FileInfo(fullpath);
            return fi.Exists;
        }
        public static string GenerateFileName()
        {
            string guid = Guid.NewGuid().ToString().Replace("-","");
            return guid;
        }
    }
}
