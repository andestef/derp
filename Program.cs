using Microsoft.Win32;
using System.Text.Json;
using System.IO;
namespace derp
{
    internal class Program
    {
        static string derp_directory = "";
        static void Main(string[] args)
        {
            if (args[0] == "DERPBAT")
            {
                // Get derp_directory from Registry (Windows only for the moment)
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\derp", false))
                {
                    if (key == null)
                    {
                        Console.WriteLine("Error: Derp rigestry key is undefined. Please follow correct setup instructions.");
                        System.Environment.Exit(1);
                    }
                    else
                    {
                        derp_directory = key.GetValue("") as string;
                    }
                }
                // Open Config/folders.json
                StreamReader sr = new StreamReader(derp_directory + "\\config\\folders.json");
                string line = sr.ReadLine();
                string file = "";
                while (line != null)
                {
                    file += line;
                    line = sr.ReadLine();
                }
                sr.Close();
                Dictionary<string, string> folders_data = JsonSerializer.Deserialize<Dictionary<string, string>>(file);
                string start = args[1];
                args = args.Skip(2).ToArray();
                Console.WriteLine(start);
            }
        }
    }
}