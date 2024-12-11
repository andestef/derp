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
            // Get derp_directory from Registry (Windows only for the moment)
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\App Paths\\derp.exe", false))
            {
                if (key == null)
                {
                    Console.WriteLine("Error: Derp rigestry key is undefined. Please follow correct setup instructions.");
                    System.Environment.Exit(1);
                }
                else
                {
                    derp_directory = key.GetValue("") as string;
                    derp_directory = derp_directory.Replace("derp.exe", "");
                }
            }
            // Open Config/folders.json
            StreamReader sr = new StreamReader(derp_directory+"\\config\\folders.json");
            string file = sr.ReadLine();
            while (file != null)
            {
                file += '\n'+sr.ReadLine();
            }
            sr.Close();
            Dictionary<string,string> weatherForecast =
                JsonSerializer.Deserialize<Dictionary<string, string>>(file);
        }
    }
}