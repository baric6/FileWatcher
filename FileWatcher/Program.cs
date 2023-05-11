using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Security.AccessControl;
using System.Text;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the path to folder to watch");
        string? line = Console.ReadLine();

        // may be null and break
        Init(line);
        // Run an infinite loop.
        // to keep program running to watch files
        while (true)
        {
            Console.WriteLine("watching: " + line);
            string noData = Console.ReadLine();
        }
    }

    /// <summary>
    /// Watcher.
    /// </summary>
    static FileSystemWatcher? _watcher;

    /// <summary>
    /// Init.
    /// </summary>
    //C:\Users\baric\OneDrive\Desktop

    static void Init(string pathToFolder)
    {
        Console.WriteLine("INIT");
        string directory = @"C:\Users\baric\OneDrive";
        Program._watcher = new FileSystemWatcher(directory);
        // this gets called if remamed, created or deleted
        // Program._watcher.Changed += new FileSystemEventHandler(Program._watcher_Changed);
        Program._watcher.Created += new FileSystemEventHandler(Program.fileSystemWatcher1_Created);
        Program._watcher.Deleted += new FileSystemEventHandler(Program.fileSystemWatcher1_Deleted);
        Program._watcher.Renamed += new RenamedEventHandler(Program.fileSystemWatcher1_Renamed);
        Program._watcher.EnableRaisingEvents = true;
        Program._watcher.IncludeSubdirectories = true;
    }

    /// <summary>
    /// Handler.
    /// </summary>
    /*static void _watcher_Changed(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine("CHANGED, NAME: " + e.Name);
        Console.WriteLine("CHANGED, FULLPATH: " + e.FullPath);
        // Can change program state (set invalid state) in this method.
        // ... Better to use insensitive compares for file names.
    }*/
    static void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
    {
        // FullPath is the new file's path.
        // MessageBox.Show(string.Format("Created: {0} {1}", e.FullPath, e.ChangeType));
        Console.WriteLine("created, NAME: " + e.Name);
        Console.WriteLine("created, FULLPATH: " + e.FullPath);
        
    }

    static void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
    {
        // FullPath is the location of where the file used to be.
        // MessageBox.Show(string.Format("Deleted: {0} {1}", e.FullPath, e.ChangeType));
        Console.WriteLine("deleted, NAME: " + e.Name);
        Console.WriteLine("deleted, FULLPATH: " + e.FullPath);
    }

    static void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
    {
        // FullPath is the new file name.
        // MessageBox.Show(string.Format("Renamed: {0} {1}", e.FullPath, e.ChangeType));
        Console.WriteLine("rename, NAME: " + e.Name);
        Console.WriteLine("rename, FULLPATH: from " + e.OldFullPath + " to " + e.FullPath);

    }

}