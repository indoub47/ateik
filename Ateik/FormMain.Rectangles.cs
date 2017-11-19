using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System;
using Ateik.Properties;

namespace Ateik
{
    partial class FormMain
    {
        /// <summary>
        /// Skaičiuojamas mastelis, iki kokio bus mažinamas paveikslas
        /// </summary>
        /// <param name="bitmapSize">Paveikslo išmatavimai pikseliais</param>
        private void calculateBitmapScale(Size bitmapSize)
        {
            int maxCAreaHeight = desktopWArea.Size.Height - titleBarHeight - toolbar.Height - statusbar.Height;
            int maxCAreaWidth = desktopWArea.Size.Width - formLRMargins;

            bmpScale = 1.0F;

            if (bitmapSize.Height > maxCAreaHeight)
                bmpScale = (float)maxCAreaHeight / bitmapSize.Height;

            if (bitmapSize.Width * bmpScale > maxCAreaWidth)
                bmpScale = maxCAreaWidth / bitmapSize.Width * bmpScale;

            // Jeigu paveikslas yra labai labai ilgas arba labai labai aukštas
            // jis gali neprotingai susiaurėti, mėginant jį tiek, sumažint, kad tilptų į formą
            // Šitoje vietoje reikėtų pagalvoti apie scrollinimo galimybę - paveikslas
            // atvaizduojamas nesumažintas, bet galima scrollinti client area.
        }

        /// <summary>
        /// Pagal paveikslo originalų dydį ir apskaičiuotą mastelį
        /// skaičiuojami formos ir panel stačiakampiai
        /// </summary>
        private void calculateRectangles(Size bitmapSize)
        {
            // paveikslėlio stačiakampio plotis po sumažinimo
            imageRectangle.Width = (int)(bitmapSize.Width * bmpScale);
            
            // formos stačiakampio plotis pagal paveikslėlį
            if (bitmapSize.Width * bmpScale + formLRMargins < minFormWidth)
                formRectangle.Width = minFormWidth;
            else
                formRectangle.Width = (int)(bitmapSize.Width * bmpScale + formLRMargins);

            // paveikslėlio stačiakampio aukštis po sumažinimo
            imageRectangle.Height = (int)(bitmapSize.Height * bmpScale);
            
            // formos stačiakampio aukštis pagal paveikslėlį
            if (bitmapSize.Height * bmpScale < minClArHeight)
                formRectangle.Height = minClArHeight + titleBarHeight + statusbar.Height + toolbar.Height;
            else
                formRectangle.Height = (int)(bitmapSize.Height * bmpScale) + titleBarHeight + statusbar.Height + toolbar.Height;            

            // panelArea dydis - tam, kad būtų galima išcentruoti paveikslėlį
            Size panelSize = new Size(formRectangle.Width - formLRMargins, formRectangle.Height - titleBarHeight - toolbar.Height - statusbar.Height);

            // paveikslėlio stačiakampio koordinatės panel koordinačių atžvilgiu
            imageRectangle.X = (int)((panelSize.Width - imageRectangle.Width) / 2);
            imageRectangle.Y = (int)((panelSize.Height - imageRectangle.Height) / 2);
        }
    }
}