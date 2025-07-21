using Dapper;
using MandiPOS;
using System;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;

public class SqlBackupHelper
{
    public static void BackupAndMoveDatabase(string destinationDirectory)
    {
        try
        {
            string backupFileName = "";
            string tempPath = "C:\\TempBackup"; ;


            using (var conn = new db())
            {
                // Step 1: Extract database name from connection string
                var builder = new SqlConnectionStringBuilder(conn.ConnectionString);
                string databaseName = builder.InitialCatalog;

                if (string.IsNullOrEmpty(databaseName))
                    throw new Exception("Database name is missing in connection string.");
                Directory.CreateDirectory(tempPath);
                // Step 2: Generate backup file path
                string timestamp = DateTime.Now.ToString("ddMMyy_HHmm");
                backupFileName = $"{databaseName}_{timestamp}.bak";
                tempPath = Path.Combine(tempPath, backupFileName);


                conn.Open();
                string sql = $@"
BACKUP DATABASE [{databaseName}]
TO DISK = N'{tempPath}'
WITH INIT, FORMAT, NAME = N'{databaseName}-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10";

                conn.Execute(sql, commandTimeout: 0); // Set command timeout to 0 for unlimited time

            }

            // Step 4: Compress the .bak file into a .zip
            string zipFileName = Path.ChangeExtension(backupFileName, ".zip");
            string zipFilePath = Path.Combine(Path.GetTempPath(), zipFileName);

            if (File.Exists(zipFilePath))
                File.Delete(zipFilePath);

            using (FileStream zipToOpen = new FileStream(zipFilePath, FileMode.Create))
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
            {
                // Fix: Replace CreateEntryFromFile with manual entry creation
                var entry = archive.CreateEntry(backupFileName, CompressionLevel.Optimal);
                using (var entryStream = entry.Open())
                using (var fileStream = File.OpenRead(tempPath))
                {
                    fileStream.CopyTo(entryStream);
                }
            }

            // Step 5: Move zip to the destination directory
            string finalPath = Path.Combine(destinationDirectory, zipFileName);

            if (File.Exists(finalPath))
                File.Delete(finalPath);

            File.Move(zipFilePath, finalPath);

            // Clean up temporary .bak file
            File.Delete(tempPath);

            Console.WriteLine("Backup completed and moved successfully to: " + finalPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during backup: " + ex.Message);
        }
    }
}

