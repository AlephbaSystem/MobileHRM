using Plugin.AudioRecorder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileHRM.Helper
{
    public class DataConverter
    {
        /// <summary>
        /// هر نوع فایل رو به بایت  تبدیل میکند و برمیگرداند
        /// </summary>
        /// <param name="path">آدرس فایل</param>
        /// <returns></returns>
        public static byte[] DataToToByte(string path)
        {
            try
            {
                return File.ReadAllBytes(path);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public static ImageSource ByteToImage(byte[] imagebytes)
        {
            try
            {
                if (imagebytes.Length == 0)
                {
                    return null;
                }
                var stream = new MemoryStream(imagebytes);
                return ImageSource.FromStream(() => new MemoryStream(imagebytes));
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }
        /// <summary>
        /// عکس را تلفن ذخیره میکند
        /// </summary>
        /// <param name="imagebytes"></param>
        /// <returns>آدرس آن را برمیگرداند</returns>
        public static ImageSource SaveImageByByte(byte[] imagebytes, DateTime dateTime)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $"Image-{dateTime.ToString("yyyy_MM_dd__HH_mm_ss")}.jpg";
                File.WriteAllBytes(path, imagebytes);
                return ImageSource.FromFile(path);
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }
        public static string SaveAudioByByte(byte[] Audiobytes, DateTime dateTime)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $"Audio-{dateTime.ToString("yyyy_MM_dd__HH_mm_ss")}.wav";
                if (File.Exists(path))
                {
                    return path;
                }
                File.WriteAllBytes(path, Audiobytes);
                return path;
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }
    }
}