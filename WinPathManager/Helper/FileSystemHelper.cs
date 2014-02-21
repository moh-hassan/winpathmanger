using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PathUtilty
{
    /// <summary>
    /// API Get short path name 8.3 / long file name for folder
    /// </summary>
    public class FileSystemHelper
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private   static extern int GetShortPathName(
            [MarshalAs(UnmanagedType.LPTStr)] string path,
            [MarshalAs(UnmanagedType.LPTStr)] StringBuilder shortPath,
            int shortPathLength);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.U4)]
        private   static extern int GetLongPathName(
            [MarshalAs(UnmanagedType.LPTStr)] string lpszShortPath,
            [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszLongPath,
            [MarshalAs(UnmanagedType.U4)] int cchBuffer);

        public  static string GetShortPathName(string path)
        {
            StringBuilder shortPath = new StringBuilder(500);
            if (0 == GetShortPathName(path, shortPath, shortPath.Capacity))
            {
                if (Marshal.GetLastWin32Error() == 2)
                {
                    //File does not exist
                    return path;
                }
                //else
                //{
                //    //throw new Exception("GetLastError returned: " + Marshal.GetLastWin32Error());
                //    return path;
                //}
            }
            return shortPath.ToString();
        }


        public static string GetLongPathName(string shortPath)
        {
            if (String.IsNullOrEmpty(shortPath))
            {
                return shortPath;
            }

            StringBuilder builder = new StringBuilder(255);
            int result = GetLongPathName(shortPath, builder, builder.Capacity);
            if (result > 0 && result < builder.Capacity)
            {
                return builder.ToString(0, result);
            }
            else
            {
                if (result > 0)
                {
                    builder = new StringBuilder(result);
                    result = GetLongPathName(shortPath, builder, builder.Capacity);
                    return builder.ToString(0, result);
                }
                //TODO: if part of path is not valid, exclude with warning , add it to not exist list
                else
                {
                    throw new FileNotFoundException(
                    string.Format(
                    CultureInfo.CurrentCulture,
                    null,
                    shortPath),
                    shortPath);
                }
            }
        }

        //---------------------------
        public static List<T> RemoveRepeatElement<T>(List<T> source)
        {
            Dictionary<T, int> listofUniqueElement = new Dictionary<T, int>();
            List<T> listofdest = new List<T>();

            foreach (T item in source)
            {
                if (!listofUniqueElement.ContainsKey(item))
                {
                    listofdest.Add(item);
                    listofUniqueElement.Add(item, 0);
                }
            }
            return listofdest;
        }

        
    }//
}//
