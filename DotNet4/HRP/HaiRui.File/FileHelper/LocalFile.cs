using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HaiRui.File.FileHelper
{
    public static class LocalFile
    {
        #region 本地
        /// <summary>
        /// 获取文件列表
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>文件列表</returns>
        public static List<FileInfo> FileInfoList(string path)
        {
            DirectoryInfo forder = new DirectoryInfo(path);
            List<FileInfo> list = forder.GetFiles().OrderByDescending(a => a.LastWriteTime).ToList();
            return list;
        }
        /// <summary>
        /// 获取文件列表
        /// </summary>
        /// <param name="path">目录</param>
        /// <param name="para">搜索参数</param>
        /// <returns>文件列表</returns>
        public static List<FileInfo> FileInfoList(string path, string para)
        {
            DirectoryInfo forder = new DirectoryInfo(path);
            List<FileInfo> list = forder.GetFiles(para).OrderByDescending(a => a.LastWriteTime).ToList();
            return list;
        }

        /// <summary>
        /// 如果指定路径的文件夹不存在，则创建文件夹
        /// </summary>
        /// <param name="path">路径</param>

        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }


        /// <summary>
        /// 获取目录列表
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>目录列表</returns>
        public static List<DirectoryInfo> DirectoryList(string path)
        {
            DirectoryInfo forder = new DirectoryInfo(path);
            List<DirectoryInfo> list = forder.GetDirectories().OrderByDescending(a => a.LastWriteTime).ToList();
            return list;
        }
        /// <summary>
        /// 获取目录列表
        /// </summary>
        /// <param name="path">目录</param>
        /// <param name="para">搜索参数</param>
        /// <returns>目录列表</returns>
        public static List<DirectoryInfo> DirectoryList(string path, string para)
        {
            DirectoryInfo forder = new DirectoryInfo(path);
            List<DirectoryInfo> list = forder.GetDirectories(para).OrderByDescending(a => a.LastWriteTime).ToList();
            return list;
        }


        /// <summary>
        /// 读取图片
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <returns>图片字节</returns>
        public static byte[] ImageByte(string filename)
        {
            string imgpath = filename;
            FileStream stream = new FileStream(imgpath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            int length = (int)stream.Length;
            byte[] buffer = new byte[length];
            stream.Read(buffer, 0, length);
            stream.Close();
            return buffer;
        }

        #endregion
    }
}
