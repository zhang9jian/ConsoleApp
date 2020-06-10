﻿using System;
using System.IO;

namespace TextReaderWriter
{
    internal class EnvVariable
    {
        public static void retrieveEnvVar()
        {
            string dirPath = @"D:\TestDir";
            string filePath = @"D:\TestDir\TestFile.txt";
            Console.WriteLine("<<<<<<<<<<<{0}>>>>>>>>>>", "文件路径");
            //获得当前路径
            Console.WriteLine(Environment.CurrentDirectory);
            //文件或文件夹所在目录
            Console.WriteLine(Path.GetDirectoryName(filePath));     //D:\TestDir
            Console.WriteLine(Path.GetDirectoryName(dirPath));      //D:\
                                                                    //文件扩展名
            Console.WriteLine(Path.GetExtension(filePath));         //.txt
                                                                    //文件名
            Console.WriteLine(Path.GetFileName(filePath));          //TestFile.txt
            Console.WriteLine(Path.GetFileName(dirPath));           //TestDir
            Console.WriteLine(Path.GetFileNameWithoutExtension(filePath)); //TestFile
                                                                           //绝对路径
            Console.WriteLine(Path.GetFullPath(filePath));          //D:\TestDir\TestFile.txt
            Console.WriteLine(Path.GetFullPath(dirPath));           //D:\TestDir
                                                                    //更改扩展名
            Console.WriteLine(Path.ChangeExtension(filePath, ".jpg"));//D:\TestDir\TestFile.jpg
                                                                      //根目录
            Console.WriteLine(Path.GetPathRoot(dirPath));           //D:\
                                                                    //生成路径
            Console.WriteLine(Path.Combine(new string[] { @"D:\", "BaseDir", "SubDir", "TestFile.txt" })); //D:\BaseDir\SubDir\TestFile.txt
                                                                                                           //生成随即文件夹名或文件名
            Console.WriteLine(Path.GetRandomFileName());
            //创建磁盘上唯一命名的零字节的临时文件并返回该文件的完整路径
            Console.WriteLine(Path.GetTempFileName());
            //返回当前系统的临时文件夹的路径
            Console.WriteLine(Path.GetTempPath());
            //文件名中无效字符
            Console.WriteLine(Path.GetInvalidFileNameChars());
            //路径中无效字符
            Console.WriteLine(Path.GetInvalidPathChars());
            Console.ReadKey();
        }
    }
}