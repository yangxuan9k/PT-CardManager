using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;
namespace Bouwa.Helper.Class
{   
    public class RFVersionInfo
    {
        public static string GetSystemVersion()
        {
            Assembly assembly = null;
            AssemblyName name = new AssemblyName();
            name.Version = new System.Version("0.0.0");

            // Try obtaining assembly version
            string sPath = GetCurrentDirectory() + @"\" + "Bouwa.ITSP2V31.Win.exe";
            try
            {
                if (File.Exists(sPath))
                {
                    assembly = Assembly.LoadFrom(sPath);
                    name = assembly.GetName();
                }
            }
            catch (Exception ex)
            {
               Log.WriterLine(ELevel.error,"获取系统版本" , ex.ToString());
            }
            assembly = null;
            
            return name.Version.Major + "." + name.Version.Minor + "." + name.Version.Build + "." + name.Version.Revision;        
            
        }
        /// <summary>
        /// 获得本程序路径
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="dir">目录路径</param>
        /// <param name="delname">待删除文件或文件夹名称</param>
        public void DeleteFolder(string dir, string delname)
        {
            if (Directory.Exists(dir))
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    string tmpd = d.Substring(0, d.LastIndexOf("\\")) + "\\" + delname;
                    if (Directory.Exists(d))
                    {
                        if (d == tmpd)
                            Directory.Delete(d, true);
                        else
                            DeleteFolder(d, delname);//递归删除子文件夹   
                    }
                    else if (File.Exists(d))
                    {
                        if (d == tmpd)
                            File.Delete(d);
                    }
                }
            }
        }
 
        public void FindFile(string path,string file)
        {
            //string str=null;
            //    DirectoryInfo dir = new DirectoryInfo(@path); //路径  
            //    foreach(DirectoryInfo dChild in dir.GetFiles(file))//文件
            //    {
                    //str=dChild.Name;
                    //如果用GetFiles("*.txt"),那么全部txt文件会被显示
                    //Response.Write(dChild.Name + "<BR>");//打印文件名
                    //Response.Write(dChild.FullName + "<BR>");//打印路径和文件名
                //}

        }

　　  }



    
}
