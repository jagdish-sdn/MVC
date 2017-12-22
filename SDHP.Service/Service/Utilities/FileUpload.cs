using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace Model.Utilities
{
    public class FileUpload
    {
        public static List<Tuple<bool, string>> SaveFileToFolder(HttpPostedFileBase file, string fileName, string innerFolderName, bool allowOverride)
        {
            var list = new List<Tuple<bool, string>>();

            if (!IsFileSupported(file))
            {
                list.Add(new Tuple<bool, string>(false, "This file is not Supported!"));
                return list;
            }

            var serverFolderPath = HttpContext.Current.Server.MapPath("~/Uploads/" + innerFolderName);

            var serverFullFilePath = Path.Combine(serverFolderPath, fileName);

            //var isFileExist = IsFileExists(serverFullFilePath);

            // Check if this file is already exists and user allow override.
            //if ((isFileExist) && (!allowOverride))
            //{
            //    list.Add(new Tuple<bool, string>(false, "This file is already exist."));
            //    return list;
            //}

            // save the file.
            file.SaveAs(serverFullFilePath);
            list.Add(new Tuple<bool, string>(true, "The file was successfuly saved!"));
            return list;
        }

        public static string CreateDirectoryInUploads(string innerFolderName)
        {
            var serverFolderPath = HttpContext.Current.Server.MapPath("~/Uploads/" + innerFolderName);
            if (!Directory.Exists(serverFolderPath))
            {
                Directory.CreateDirectory(serverFolderPath);
            }
            return serverFolderPath + "/";
        }
        public static List<Tuple<bool, string>> SaveFileInFolder(HttpPostedFileBase file, string fileName, string folderName)
        {
          //  var innerFolderName = Path.Combine(folderName);
            var tupleList = FileUpload.SaveFileToFolder(file, fileName, folderName, true);
            return tupleList;
        }
        public static bool IsFileSupported(HttpPostedFileBase file)
        {
            var isSupported = false;
            switch (file.ContentType)
            {

                case ("image/gif"):
                    isSupported = true;
                    break;

                case ("image/jpeg"):
                    isSupported = true;
                    break;

                case ("image/png"):
                    isSupported = true;
                    break;

                case ("application/pdf"):
                    isSupported = true;
                    break;


                case ("application/vnd.openxmlformats-officedocument.wordprocessingml.document"):
                    isSupported = true;
                    break;
            }
            return isSupported;
        }

        public static Tuple<bool, string> GetFileExtension(HttpPostedFileBase file)
        {
            var isSupported = false;

            var extension = "";
            switch (file.ContentType)
            {

                case ("image/gif"):
                    extension = ".gif";
                    isSupported = true;
                    break;

                case ("image/jpeg"):
                    extension = ".jpg";
                    isSupported = true;
                    break;

                case ("image/png"):
                    extension = ".png";
                    isSupported = true;
                    break;

                case ("application/pdf"):
                    extension = ".pdf";
                    isSupported = true;
                    break;


                case ("application/vnd.openxmlformats-officedocument.wordprocessingml.document"):
                    extension = ".docx";
                    isSupported = true;
                    break;

            }

            var tuple = new Tuple<bool, string>(isSupported, extension);

            return tuple;

            //return new KeyValuePair<bool, string>(isSupported, extension); 
        }

        private static bool IsFileExists(string serverFullFilePath)
        {
            if (File.Exists(serverFullFilePath))
                return true;
            return false;
        }

        public static List<Tuple<bool, string, string>> SaveFileToFolder
            (HttpPostedFileBase file, string fileName, string innerFolderName, bool allowOverride, bool changeFileName)
        {
            var list = new List<Tuple<bool, string, string>>();

            if (!IsFileSupported(file))
            {

                list.Add(new Tuple<bool, string, string>(false, "This file is not Supported!", ""));
                return list;
            }

            var serverFolderPath = HttpContext.Current.Server.MapPath("~/Uploads/" + innerFolderName);

            var serverFullFilePath = Path.Combine(serverFolderPath, fileName);

            var isFileExist = IsFileExists(serverFullFilePath);

            if ((isFileExist) && (changeFileName))
            {
                int fileCount = (Directory.GetFiles(serverFolderPath, "*.*", SearchOption.AllDirectories).Length) + 1;
                fileName = fileName + "-" + fileCount + "." + file.FileName.Split('.')[1];
            }
            else
            {
                fileName = fileName + "." + file.FileName.Split('.')[1];
            }
            serverFullFilePath = Path.Combine(serverFolderPath, fileName);

            // Check if this file is already exists and user allow override.
            //if ((isFileExist) && (!allowOverride))
            //{
            //    list.Add(new Tuple<bool, string>(false, "This file is already exist."));
            //    return list;
            //}

            // save the file.
            file.SaveAs(serverFullFilePath);
            list.Add(new Tuple<bool, string, string>(true, "The file was successfuly saved!", fileName));
            return list;

        }
    }
}
