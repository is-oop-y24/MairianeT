using System.IO;
using Backups;
using Newtonsoft.Json;

namespace BackupsExtra.Services
{
    public class Saving
    {
        public void SaveJob(BackupExtra backup, string fileToSave)
        {
            string json = JsonConvert.SerializeObject(backup, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
            });
            File.WriteAllText(fileToSave, json);
        }

        public BackupExtra RecoverJob(string fileWithJob)
        {
            string json = File.ReadAllText(fileWithJob);
            return JsonConvert.DeserializeObject<BackupExtra>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
            });
        }
    }
}