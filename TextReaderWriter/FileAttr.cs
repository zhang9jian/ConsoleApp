using System;
using System.IO;

namespace TextReaderWriter
{
    internal class FileAttr
    {
        //设置文件隐藏和只读属性
        public void SetAttrByFile(string filePath)
        {
            Console.WriteLine(File.GetAttributes(filePath));
            File.SetAttributes(filePath, FileAttributes.Hidden | FileAttributes.ReadOnly);
            Console.WriteLine(File.GetAttributes(filePath));
        }

        public void SetArrtByFileInfo(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            Console.WriteLine(fi.Attributes.ToString());
            fi.Attributes = FileAttributes.Hidden | FileAttributes.ReadOnly; //隐藏与只读
            Console.WriteLine(fi.Attributes.ToString());
            fi.Attributes = FileAttributes.Archive;
            Console.WriteLine(fi.Attributes.ToString());
        }
    }
}