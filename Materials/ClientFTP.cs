using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
namespace MachinesAndRobotsVKR.Materials
{
    public static class ClientFTP //TODO доделать общение с сервером для закачки материалов
    {

        public static double setValueProductivity = 0;
        public static double setValueEnergy = 0;
        public static double setValueSquare = 0;

        //ClientFTP()
        //{
        //    // Создаем объект FtpWebRequest
        //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://127.0.0.1/test.txt");
        //    // устанавливаем метод на загрузку файлов
        //    request.Method = WebRequestMethods.Ftp.DownloadFile;

        //    // если требуется логин и пароль, устанавливаем их
        //    //request.Credentials = new NetworkCredential("login", "password");
        //    //request.EnableSsl = true; // если используется ssl

        //    // получаем ответ от сервера в виде объекта FtpWebResponse
        //    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        //}
    }
}
