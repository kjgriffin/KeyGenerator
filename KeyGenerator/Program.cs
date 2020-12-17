using System;
using System.Drawing;

namespace KeyGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Alpha Key Generator v0.1!");
            Console.Write("Filename: ");
            string filename = Console.ReadLine();

            int width, height;
            double keywidth, keyheight, keyxloc, keyyloc, keyborder;

            Console.Write("Image Width: ");
            width = Convert.ToInt32(Console.ReadLine());

            Console.Write("Image Height: ");
            height = Convert.ToInt32(Console.ReadLine());

            Console.Write("KeyHole Width (%): ");
            keywidth = Convert.ToDouble(Console.ReadLine());

            Console.Write("KeyHole Height (%): ");
            keyheight = Convert.ToDouble(Console.ReadLine());

            Console.Write("KeyHole Location X (% top left): ");
            keyxloc = Convert.ToDouble(Console.ReadLine());

            Console.Write("KeyHole Location Y (% top left): ");
            keyyloc = Convert.ToDouble(Console.ReadLine());

            Console.Write("KeyHoleBorderFeather (%): ");
            keyborder = Convert.ToDouble(Console.ReadLine());



            Console.WriteLine("Generating ...");

            Bitmap bmp = new Bitmap(width, height);
            Graphics gfx = Graphics.FromImage(bmp);


            // set all opaque
            gfx.Clear(Color.FromArgb(255, 255, 255, 255));



            int keyx = (int)(width * keyxloc);
            int keyy = (int)(height * keyxloc);

            int keyw = (int)(width * keywidth);
            int keyh = (int)(height * keyheight);

            // cut key fully
            gfx.FillRectangle(new SolidBrush(Color.FromArgb(255, 0, 0, 0)), keyx, keyy, keyw, keyh);


            // feather border inside key
            int xsteps = (int)(keyw * keyborder / 2);
            int ysteps = (int)(keyh * keyborder / 2);

            int steps = Math.Max(xsteps, ysteps);

            int stepsize = (int)(255 / (double)steps);


            for (int i = 0; i < steps; i++)
            {
                gfx.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(255 - i * stepsize, 255 - i * stepsize, 255 - i * stepsize, 255 - i * stepsize))), keyx + i, keyy + i, keyw - 2 * i, keyh - 2 * i);
            }

            bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Png);

            Console.WriteLine($"Saved to: {filename}");

        }

    }
}
