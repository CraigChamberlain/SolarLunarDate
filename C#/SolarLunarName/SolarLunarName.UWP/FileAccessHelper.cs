using SolarLunarName.Forms;
using SolarLunarName.UWP;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(FileAccessHelper))]
namespace SolarLunarName.UWP
{
    public class FileAccessHelper : IFileAccessHelper
    {
        public async Task<String> GetDBPathAndCreateIfNotExists()
        {
            String filename = "MoonPhase.sqlite";
            bool isExisting = false;
            try
            {
                StorageFile storage = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
                isExisting = true;
            }
            catch (Exception)
            {
                isExisting = false;
            }
            if (!isExisting)
            {
                StorageFile databaseFile = await Package.Current.InstalledLocation.GetFileAsync(filename);
                await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder, filename, NameCollisionOption.ReplaceExisting);
            }
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}