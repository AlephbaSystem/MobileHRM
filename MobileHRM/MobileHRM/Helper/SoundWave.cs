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
        public SoundWave(byte[] myWaveData, int audioLengthSec = 80)
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
        public StackLayout GetWave(double SpaceBetween = 1, string ActiveColor = "#00A693")
        {
            StackLayout soundWaves = new StackLayout();
            soundWaves.Orientation = StackOrientation.Horizontal;
            soundWaves.Spacing = SpaceBetween;
            int max = 4;
            int min = 1;
            int fmax = WaveData.Max();
            int fmin = WaveData.Min();
            foreach (short item in WaveData)
            {
                //item = (((fmax - fmin) * (item - min)) / (max - min)) + fmin;
                double value = (item * 0.001);
                Line li = new Line
                {
                    Y1 = 0,
                    Y2 = value,
                    HeightRequest = value,
                    Aspect = Xamarin.Forms.Stretch.None,
                    StrokeLineCap = PenLineCap.Round,
                    Stroke = Color.FromHex(ActiveColor),
                    StrokeThickness = 5,
                    VerticalOptions = LayoutOptions.Center
                };
                soundWaves.Children.Add(li);
            }
            return soundWaves;
        }
    }
}