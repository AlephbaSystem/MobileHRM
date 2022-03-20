
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace MobileHRM.Helper
{
    public class ImageConverter
    {
        public byte[] imageToByte(string path)
        {
            try
            {
                byte[] imagebyte = null;
                var strem = new FileStream(path, FileMode.Open, FileAccess.Read);
                strem.ReadByte();
                using (BinaryReader reader = new BinaryReader(strem))
                {
                    imagebyte = new byte[reader.BaseStream.Length];
                    for (int i = 0; i < reader.BaseStream.Length; i++)
                    {
                        imagebyte[i] = reader.ReadByte();
                    }
                }

                return imagebyte;
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
    }
}
