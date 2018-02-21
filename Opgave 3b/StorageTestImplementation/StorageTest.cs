using System;
using System.Collections.Generic;
using System.Drawing;
using StorageInterface;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace StorageTestImplementation
{
    public class StorageTest : IStorageInterface
    {
        private Dictionary<string, List<Point>> landscapeStore = new Dictionary<string, List<Point>>();

        public List<Point> LoadLandscape(string name)
        {
            var formatter = new BinaryFormatter();
            using (var bestand = File.OpenRead(name))
            {
                return (List<Point>)formatter.Deserialize(bestand);
            }
        }

        public void SaveLandscape(string name, List<Point> landscape)
        {
            var formatter = new BinaryFormatter();
            using (var bestand = File.OpenWrite(name +".bin"))
            {
                formatter.Serialize(bestand, landscape);
            }
        }
    }
}
