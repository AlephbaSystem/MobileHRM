
using Plugin.AudioRecorder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
        public static ImageSource SaveImageByByte(byte[] imagebytes)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $"Image-{imageindex}.jpg";
                imageindex++;
                if (File.Exists(path))
                {
                    return ImageSource.FromFile(path);
                }

                File.WriteAllBytes(path, imagebytes);
                return ImageSource.FromFile(path);
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }
        private static int imageindex { get; set; } = 0;
        private static int voiceindex { get; set; } = 0;
        public static string SaveAudioByByte(byte[] Audiobytes)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $"Audio-{voiceindex}.wav";
                voiceindex++;
                //if(File.Exists(path))
                //{
                //    return path;
                //}
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
