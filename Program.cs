using Microsoft.Win32;
using System.Text.Json;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
namespace derp
{
    internal class Program
    {
        static string derp_directory = "";
        static void Main(string[] args)
        {
            // Get derp_directory from Registry (Windows only for the moment)
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\derp", false))
            {
                if (key == null)
                {
                    Console.WriteLine("Error: Derp rigestry key is undefined. Please follow correct setup instructions.");
                    Environment.Exit(1);
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
            if (file != null)
            {
                Dictionary<string, string> folders_data = JsonSerializer.Deserialize<Dictionary<string, string>>(file);
                if (args[0] == "DERPBAT")
                {
                    if (!folders_data.ContainsKey(args[1]))
                    {
                        Console.WriteLine("`ERR: No such key: " + args[1]);
                    }
                    else
                    {
                        string start = folders_data[args[1]];
                        args = args.Skip(2).ToArray();
                        foreach (string i in args)
                        {
                            start += "\\" + i;
                        }
                        Console.WriteLine(start);
                    }
                }
                else
                {
                    /*string c = "";
                    string key = "";
                    string value = "";
                    bool mode = false;
                    for (int i = 2; i < args.Length; i++)
                    {
                        c = args[i];
                        if (c == "=")
                        {
                            mode = true;
                            continue;
                        }
                        if (mode)
                        {
                            value += c + " ";
                        }
                        else
                        {
                            key += c + " ";
                        }
                    }
                    key = key.Remove(key.Length-1);
                    value = value.Remove(value.Length-1);
                    folders_data[key] = value;
                    File.WriteAllText(derp_directory + "\\config\\folders.json", JsonSerializer.Serialize(folders_data));*/
                }
            }
        }
    }
}