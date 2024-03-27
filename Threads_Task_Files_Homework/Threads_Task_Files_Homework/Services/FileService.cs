using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads_Task_Files_Homework.Services.Interfaces;

namespace Threads_Task_Files_Homework.Services
{
    internal class FileService : IFileService
    {
        public async Task<string> ReadFromFileAsync(string path)
        {
            using (FileStream fs=new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr=new StreamReader(fs))
                {
                    return await sr.ReadToEndAsync();
                }
            }
        }

        public async Task WriteToExistFileAsync(string path, string text)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    await sw.WriteAsync(text);
                }
            }
        }

        public async Task WriteToNewFileAsync(string path, string text)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    byte[] datas = Encoding.UTF8.GetBytes(text);
                   await fs.WriteAsync(datas, 0, datas.Length);

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
