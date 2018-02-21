using System;
using System.Drawing;
using LogicInterface;

namespace LogicImplementation
{
    public class ImageFilter : IImageFilter
    {
        private Image OriginalImage;
        private Image filteredImage;
        public Image FilteredImage
        {
            get
            {
                return filteredImage;
            }
        }
        public event Action<int> progressEvent;

        private delegate Color filterOperation(Color pixel);

        public void Load(string file)
        {
            // Laadt de opgegeven afbeelding in, 
            // stockeer het origineel in een private veld
            // en kopieer het naar een tweede bitmap waarin je de bewerkte versie zal opslaan 
            OriginalImage = new Bitmap(Image.FromFile(file));
            filteredImage = (Image)OriginalImage.Clone();
        }

        public void ApplyFilter(Filter filterMode)
        {
            switch (filterMode)
            {
                case Filter.Original:
                    ExecuteFilter(pxl => { return pxl; });
                    break;

                case Filter.GreyScale:
                    ExecuteFilter(pxl => 
                    {
                        int average = (pxl.G + pxl.R + pxl.B) / 3;
                        return Color.FromArgb(average, average, average);
                    });
                    break;

                case Filter.Threshold:
                    ExecuteFilter(pxl =>
                    {
                        int average = (pxl.G + pxl.R + pxl.B) / 3;
                        average = (average < 128) ? 0 : 255;
                        return Color.FromArgb(average, average, average);
                    });
                    break;

                case Filter.Invert:
                    ExecuteFilter(pxl =>
                    {
                        return Color.FromArgb(255-pxl.R , 255-pxl.G , 255-pxl.B);
                    });
                    break;

                default:
                    throw new Exception("Invalid filterMode");
            }
        }

        private void ExecuteFilter(filterOperation operation)
        {
            using (Bitmap bmp = new Bitmap(OriginalImage))
            {
                for (int i = 0; i < bmp.Width; ++i)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        bmp.SetPixel(i, j, operation(bmp.GetPixel(i, j)));
                        if (progressEvent != null)
                        {
                            int x = i*100 / bmp.Width;
                            progressEvent(x);
                        }
                    }
                }
                filteredImage = (Image)bmp.Clone();
                if (progressEvent != null)
                {
                    progressEvent(100);
                }
            }
        }
    }
}
