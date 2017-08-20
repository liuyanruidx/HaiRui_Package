using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HaiRui.Net;

namespace HaiRui.File.FileHelper
{
    public static class ShareFile
    {
        #region 共享

        /// <summary>
        /// 共享目录:获取文件列表
        /// </summary>
        /// <param name="path">共享路线  例如：\\172.18.226.52\预报科各种预报和服务</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>文件列表</returns>
        public static List<FileInfo> FileInfoList(string path, string username, string password)
        {
            string localpath = "Q:";

            int status = NetworkConnection.Connect(path, localpath, @username, password);
            if (status == (int)ERROR_ID.ERROR_SUCCESS)
            {
                List<FileInfo> list = LocalFile.FileInfoList(@"Q:\");
                NetworkConnection.Disconnect(localpath);
                return list;
            }
            else
            {
                NetworkConnection.Disconnect(localpath);
                return null;
            }
        }
        /// <summary>
        /// 共享目录:获取文件列表
        /// </summary>
        /// <param name="path">目录</param>
        /// <param name="para">搜索参数</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>文件列表</returns>
        public static List<FileInfo> FileInfoList(string path, string para, string username, string password)
        {
            string localpath = "Q:";

            int status = NetworkConnection.Connect(path, localpath, @username, password);
            if (status == (int)ERROR_ID.ERROR_SUCCESS)
            {
                List<FileInfo> list = LocalFile.FileInfoList(@"Q:\", para);
                NetworkConnection.Disconnect(localpath);
                return list;
            }
            else
            {
                NetworkConnection.Disconnect(localpath);
                return null;
            }
        }







        /// <summary>
        /// 共享目录:复制文件
        /// </summary>
        /// <param name="sharefilename">共享文件名称</param>
        /// <param name="tolocalpath">本地目标地址</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>是否成功</returns>
        public static bool CopyFile(string sharefilename, string tolocalpath, string username, string password)
        {
            string localpath = "Q:";


            int status = NetworkConnection.Connect(Path.GetFullPath(sharefilename), localpath, @username, password);
            if (status == (int)ERROR_ID.ERROR_SUCCESS)
            {
                string fromfile = @"Q:\" + Path.GetFileName(sharefilename);
                string tofile = tolocalpath + @"\" + Path.GetFileName(sharefilename);

                if (System.IO.File.Exists(fromfile))
                {
                    System.IO.File.Copy(fromfile, tofile, true);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                NetworkConnection.Disconnect(localpath);
                return false;
            }
        }



        /// <summary>
        /// 共享目录:获取目录列表
        /// </summary>
        /// <param name="path">目录</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>目录列表</returns>
        public static List<DirectoryInfo> DirectoryList(string path, string username, string password)
        {
            string localpath = "Q:";

            int status = NetworkConnection.Connect(path, localpath, @username, password);
            if (status == (int)ERROR_ID.ERROR_SUCCESS)
            {

                DirectoryInfo forder = new DirectoryInfo(@"Q:\");
                List<DirectoryInfo> list = forder.GetDirectories().OrderByDescending(a => a.FullName).ToList();
                return list;

            }
            else
            {
                NetworkConnection.Disconnect(localpath);
                return null;
            }
        }
        /// <summary>
        /// 共享目录:获取目录列表
        /// </summary>
        /// <param name="path">目录</param>
        /// <param name="para">搜索参数</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static List<DirectoryInfo> DirectoryList(string path, string para, string username, string password)
        {
            string localpath = "Q:";

            int status = NetworkConnection.Connect(path, localpath, @username, password);
            if (status == (int)ERROR_ID.ERROR_SUCCESS)
            {

                DirectoryInfo forder = new DirectoryInfo(@"Q:\");
                List<DirectoryInfo> list = forder.GetDirectories(para).OrderByDescending(a => a.FullName).ToList();
                return list;

            }
            else
            {
                NetworkConnection.Disconnect(localpath);
                return null;
            }
        }
        /// <summary>
        /// 共享目录:读取Txt文档所有行
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>Txt文档所有行</returns>
        public static string[] TextLines(string filename, string username, string password, Encoding encoding)
        {
            string localpath = "Q:";
            string path = filename.Substring(0, filename.LastIndexOf(@"\"));
            string name = Path.GetFileName(filename);

            int status = NetworkConnection.Connect(path, localpath, username, password);
            if (status == (int)ERROR_ID.ERROR_SUCCESS)
            {
                string[] content = System.IO.File.ReadAllLines(@"Q:\" + name, encoding);



                NetworkConnection.Disconnect(localpath);
                return content;
            }
            else
            {
                NetworkConnection.Disconnect(localpath);
                return null;
            }
        }
        /// <summary>
        /// 共享目录:读取Txt文档所有内容
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>文档所有内容</returns>
        public static string TextConent(string filename, string username, string password, Encoding encoding)
        {
            string localpath = "Q:";
            string path = filename.Substring(0, filename.LastIndexOf(@"\"));
            string name = Path.GetFileName(filename);

            int status = NetworkConnection.Connect(path, localpath, username, password);
            if (status == (int)ERROR_ID.ERROR_SUCCESS)
            {



                string content = System.IO.File.ReadAllText(@"Q:\" + name, encoding);



                NetworkConnection.Disconnect(localpath);
                return content;
            }
            else
            {
                NetworkConnection.Disconnect(localpath);
                return null;
            }
        }
        /// <summary>
        /// 共享目录:读取图片
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>图片字节</returns>
        public static byte[] ImageByte(string filename, string username, string password)
        {
            string localpath = "Q:";
            string path = filename.Substring(0, filename.LastIndexOf(@"\"));
            string name = Path.GetFileName(filename);

            int status = NetworkConnection.Connect(path, localpath, username, password);
            if (status == (int)ERROR_ID.ERROR_SUCCESS)
            {


                string imgpath = @"Q:\" + name;

                FileStream stream = new FileStream(imgpath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                int length = (int)stream.Length;
                byte[] buffer = new byte[length];
                stream.Read(buffer, 0, length);
                stream.Close();




                NetworkConnection.Disconnect(localpath);
                return buffer;
            }
            else
            {
                NetworkConnection.Disconnect(localpath);
                return null;
            }
        }




        #endregion


    }
}
