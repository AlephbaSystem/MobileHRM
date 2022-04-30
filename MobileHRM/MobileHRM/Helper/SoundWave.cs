using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Shapes;
using Xamarin.Forms;
namespace MobileHRM.Helper
{
    public class SoundWave
    {
        short[] WaveData;
        public SoundWave(byte[] myWaveData, int audioLengthSec = 20)
        {
            var tmpkWaveData = new short[myWaveData.Length / 2];
            Buffer.BlockCopy(myWaveData, 0, tmpkWaveData, 0, myWaveData.Length);
            int lng = tmpkWaveData.Length / audioLengthSec;

            WaveData = new short[audioLengthSec];
            int k = 0;
            for (int i = 0; i < tmpkWaveData.Length; i += lng)
            {
                for (int j = i; j < i + lng; j++)
                {
                    WaveData[k] += tmpkWaveData[j];
                }
                WaveData[k] = Math.Abs(WaveData[k]);
                k++;
            }
        }
        public StackLayout GetWave(double SpaceBetween = 5, string ActiveColor = "#00A693")
        {
            StackLayout soundWaves = new StackLayout();
            soundWaves.Orientation = StackOrientation.Horizontal;
            soundWaves.Spacing = SpaceBetween;
            int max = 30;
            int min = 1;
            int fmax = WaveData.Max();
            int fmin = WaveData.Min();
            foreach (short item in WaveData)
            {
                int value = (((fmax - fmin) * (item - min)) / (max - min)) + fmin;
                Line li = new Line();
                li.Y1 = 0;
                li.Y2 = value;
                li.HeightRequest = value;
                li.Aspect = Xamarin.Forms.Stretch.None;
                li.StrokeLineCap = PenLineCap.Round;
                li.Stroke = Color.FromHex(ActiveColor);
                li.StrokeThickness = 12;
                li.VerticalOptions = LayoutOptions.Center;
                soundWaves.Children.Add(li);
            }
            return soundWaves;
        }
    }
}