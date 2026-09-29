using System;
using System.IO;
using SkiaSharp;

namespace ProgrammingPaint
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generating meme...");

            // Make sure you have the file szablon.jpg in your folder!
            using (SKBitmap tlo = SKBitmap.Decode("szablon.jpg"))
            using (SKCanvas canvas = new SKCanvas(tlo))
            {
                // Brush for the semi-transparent strip
                using (SKPaint pasekPaint = new SKPaint())
                {
                    pasekPaint.Color = SKColors.Black.WithAlpha(150);
                    pasekPaint.Style = SKPaintStyle.Fill;

                    // Draw a strip 100px high at the very bottom
                    canvas.DrawRect(0, tlo.Height - 100, tlo.Width, 100, pasekPaint);
                }

                // Brush for the text
                using (SKPaint tekstPaint = new SKPaint())
                {
                    tekstPaint.Color = SKColors.White;
                    tekstPaint.TextSize = 60;
                    tekstPaint.IsAntialias = true; // Font smoothing!
                    tekstPaint.TextAlign = SKTextAlign.Center;

                    // Text at the bottom
                    canvas.DrawText("Me in C# class", tlo.Width / 2, tlo.Height - 30, tekstPaint);
                }

                // Save the generated meme to a new file
                using (var image = SKImage.FromBitmap(tlo))
                using (var data = image.Encode(SKEncodedImageFormat.Jpeg, 100))
                using (var stream = File.OpenWrite("my_super_meme.jpg"))
                {
                    data.SaveTo(stream);
                }
            }

            Console.WriteLine("Meme generated! Open the file my_super_meme.jpg");
            Console.ReadLine();
        }
    }
}
