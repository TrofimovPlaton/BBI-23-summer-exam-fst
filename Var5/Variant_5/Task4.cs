using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

#region Выберите библиотеку(и) для сериализации
using System.Text.Json;

#endregion
namespace Variant_5
{
    public class Task4
    {
public interface ISerializer
    {
        void Serialize(string path);
        void Deserialize(string path);
    }

    public class FolderManager
    {
        public void CreateFolder(string path, string folderName)
        {
            Directory.CreateDirectory(Path.Combine(path, folderName));
        }

        public void CreateFile(string path, string fileName)
        {
            File.Create(Path.Combine(path, fileName)).Dispose();
        }

        public void CreateFolders(string path, string[] folderNames)
        {
            foreach (var folderName in folderNames)
            {
                CreateFolder(path, folderName);
            }
        }

        public void CreateFiles(string path, string[] fileNames)
        {
            foreach (var fileName in fileNames)
            {
                CreateFile(path, fileName);
            }
        }
    }

    public class StatisticSerializer : FolderManager, ISerializer
    {
        private Task3.Statistic statistic;

        public Task3.Statistic Statistic => statistic;

        public StatisticSerializer(Task3.Statistic statistic)
        {
            this.statistic = statistic;
        }

        public void Serialize(string path)
        {
            string json = JsonSerializer.Serialize(statistic);
            File.WriteAllText(path, json);
        }

        public void Deserialize(string path)
        {
            string json = File.ReadAllText(path);
            statistic = JsonSerializer.Deserialize<Task3.Statistic>(json);
        }
    }

}
}
