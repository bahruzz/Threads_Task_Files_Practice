using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads_Task_Files_Homework.Extensions;
using Threads_Task_Files_Homework.Services;
using Threads_Task_Files_Homework.Services.Interfaces;

namespace Threads_Task_Files_Homework.Controllers
{
    internal class FileController
    {
        private readonly IFileService _fileService;
        public FileController()
        {
            _fileService= new FileService();
        }
        public async Task ReadDataAsync()
        {
            string result = await _fileService.ReadFromFileAsync("C:\\Users\\user\\Desktop\\Threads, Task, Files\file2.txt.txt");
           Console.WriteLine(result);
        }

        public async Task CreateFileWithContentAsync()
        {
            await Console.Out.WriteLineAsync("Add path");
            string path = Console.ReadLine();
            await Console.Out.WriteLineAsync("Add fileName");
            string fileName = Console.ReadLine();
            await Console.Out.WriteLineAsync("Add text");
            string text=Console.ReadLine();
            string resultPath=path.GenerateFullPath(fileName);
            await _fileService.WriteToNewFileAsync(resultPath,text);
        }
    }
}
//C:\\Users\\user\\Desktop\\Threads, Task, Files