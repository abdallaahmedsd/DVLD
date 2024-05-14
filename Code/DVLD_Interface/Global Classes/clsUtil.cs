using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DVLD_Interface.Global_Classes
{
    public static class clsUtil
    {
        private static string PathToSaveLoginInfo = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
        public static string GenerateGUID()
        {
            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;
        }

        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            // Full file name. Change your file name   
            FileInfo fi = new FileInfo(sourceFile);
            string extn = fi.Extension;
            return GenerateGUID() + extn;
        }

        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            /* 
                this function will copy the image to the
                project images folder after renaming it
                with GUID with the same extension, then it will update the sourceFileName with the new name.
            */

            string DestinationFolder = @"P:\Projects\DVLD - ProgrammingAdvices\People_Images\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }

        public static bool SaveLoginInfo(string username, string password)
        {
            bool isSaved = false;
            // Save login info into Windows Registry
            try
            {
                Registry.SetValue(PathToSaveLoginInfo, "Username", username);
                Registry.SetValue(PathToSaveLoginInfo, "Password", password);
                isSaved = true;
            }
            catch
            {
                isSaved = false;
            }

            return isSaved;
        }

        public static string ComputeHash(string input)
        {
            //SHA stands for Secured Hash Algorithm.

            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
             
    }
}
