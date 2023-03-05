namespace Movie_Library_Assignment.Services
{
    public class MainService : IMainService
    {
        
        private IFileService _fileService;
        public MainService(IFileService fileService) 
        {
            _fileService = fileService;
        }
        public void Invoke()
        {
            _fileService.Menu();
        }
    }
}
