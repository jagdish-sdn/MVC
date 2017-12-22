using System;
using System.Collections.Generic;
using System.Web;

namespace Model.Utilities
{



    public enum InnerFolders
    {
        Requests,
        Offers
    }


    public class SaveFileInFolder
    {
        readonly string _uploadFileLocation = System.Web.Configuration.WebConfigurationManager.AppSettings["AppPostedFiles"];

        public List<Tuple<bool, string>> SaveImageToFolder(HttpPostedFile file, string fileName, string toInnerFolderName, bool allowOverride)
        {
            var list = new List<Tuple<bool, string>>();

            if (! IsFileSupported(file))
            {
                list.Add(new Tuple<bool, string>(false,"This file is not an image!"));
                return list;
            }

            var serverFolderPath = HttpContext.Current.Server.MapPath("~/"+ _uploadFileLocation +  toInnerFolderName);
            var serverFullFilePath = serverFolderPath + "/"+  fileName;

            var isFileExist = IsFileExists(serverFullFilePath);
            
            // Check if this file is already exists and user allow override.
            if ((isFileExist) && (! allowOverride))
            {
                list.Add(new Tuple<bool, string>(false, "This file is already exist."));
                return list;               
            }


            // save the file.
            file.SaveAs( serverFullFilePath);
            list.Add(new Tuple<bool, string>(true, "The image was successfuly saved!"));
            return list;
             
        }


        public bool IsFileSupported(HttpPostedFile file)
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

                case ("audio/mpeg"): // audio file
                    isSupported = true;
                    break;

                case ("audio/mp3"): // audio file
                    isSupported = true;
                    break;

                case ("audio/wav"): // audio file
                    isSupported = true;
                    break;

                case ("audio/x-wav"): // audio file
                    isSupported = true;
                    break;    
                                      
            }

            return isSupported;
        }


        private bool IsFileExists(string serverFullFilePath)
        {           
            if (System.IO.File.Exists(serverFullFilePath))
                return true;
            else
                return false;
        }
    }
}
