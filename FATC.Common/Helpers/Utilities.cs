using FATC.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace FATC.Common.Helpers
{
    public class Utilities
    {
        #region I/O Methods

        public static void CheckPath(ref string serverPath)
        {
            string initPath = string.Empty;
            string tempPath = string.Empty;
            string[] folders;
            try
            {
                folders = serverPath.Split(Convert.ToChar(@"\"));

                // Save file to a server
                if (serverPath.Contains(@"\"))
                    initPath = @"\";

                for (int i = 0; i <= folders.Length - 1; i++)
                {
                    if (tempPath.Trim() == string.Empty & folders[i] != string.Empty)
                        tempPath = initPath + folders[i];
                    else if (tempPath.Trim() != string.Empty & folders[i].Trim() != string.Empty)
                    {
                        tempPath = tempPath + @"\" + folders[i];

                        // Doesn't check if it's a network connection
                        if (!tempPath.Contains(@"\") & !folders[i].Contains("$"))
                        {
                            if (!Directory.Exists(tempPath))
                                Directory.CreateDirectory(tempPath);
                        }
                        else if (!Directory.Exists(tempPath))
                            Directory.CreateDirectory(tempPath);
                    }
                }
                serverPath = tempPath + @"\";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteDirectoryAndFiles(string directory, string directoryToDelete)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(directory);
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    if (directoryToDelete.Contains(dir.Name))
                    {
                        foreach (FileInfo file in dir.GetFiles()) file.Delete();
                        dir.Delete();
                    }
                } 
            }
            catch (IOException ioExp)
            {
                throw ioExp;
            }
        }

        #endregion

        #region Entities Methods

        public static string GetPropertyDisplayName<T>(Expression<Func<T, object>> propertyExpression)
        {
            var memberInfo = propertyExpression.Body.GetPropertyInformation();
            if (memberInfo == null)
                throw new ArgumentException($"No se encontró la propiedad en la expresión proporcionada");

            var attr = memberInfo.GetAttribute<DisplayAttribute>(false);
            if (attr == null)
                return memberInfo.Name;

            return attr.Name;
        }

        public static string GetPropertyRequiredMessage<T>(Expression<Func<T, object>> propertyExpression)
        {
            var memberInfo = propertyExpression.Body.GetPropertyInformation();
            if (memberInfo == null)
                throw new ArgumentException($"No se encontró la propiedad en la expresión proporcionada");

            var attr = memberInfo.GetAttribute<RequiredAttribute>(false);
            if (attr == null)
                return memberInfo.Name;

            return attr.ErrorMessage;
        }

        #endregion
    }
}
