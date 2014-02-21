using Microsoft.Win32;
/********************************************************************************************************
 * 
 * WinPath Manager
 * Copyright 2014 Mohamed Hassan 
 * Apache License 2.0 (Apache)
 * 
 * https://pathmanger.codeplex.com/
 * 
 ******************************************************************************************************/


namespace WinPathManager
{
    public class ProgramInfo
    {
        public string Name = "";
        public string InstallLocation = "";
        public string ProductGuid = "";
        public string DisplayVersion = "";
        //RegistryKey sk

        public string IsNull(object o)
        {

            return o == null ? "" : o.ToString().Trim();
        }
        public ProgramInfo(RegistryKey sk)
        {
            Name = sk.GetValue("DisplayName") == null ? "" : sk.GetValue("DisplayName").ToString().Trim();
            if (Name != "")
            {

                InstallLocation = sk.GetValue("InstallLocation") == null ? "" : sk.GetValue("InstallLocation").ToString().Trim();

                ProductGuid = sk.GetValue("ProductGuid") == null ? "" : sk.GetValue("ProductGuid").ToString().Trim();
                DisplayVersion = sk.GetValue("DisplayVersion") == null ? "" : sk.GetValue("DisplayVersion").ToString().Trim();
                //Console.WriteLine(Name);
            }
        }

        public string ToString()
        {
            if (Name == "") return "";
            return Name + "(" + DisplayVersion + ")";
        }

    }
}
