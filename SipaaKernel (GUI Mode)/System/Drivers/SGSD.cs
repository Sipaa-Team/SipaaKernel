using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernel.System.Drivers
{
    /// <summary>
    /// Result for SetResolution() function
    /// </summary>
    public enum SetResolutionResult
    {
        ModeNotFinded,
        Sucess
    }

    /// <summary>
    /// Sipaa Graphical Screen Driver
    /// </summary>
    public class SGSD
    {
        public static Canvas Screen;
        public static uint Width, Height;
        public static void Initialize()
        {
            Screen = FullScreenCanvas.GetFullScreenCanvas();
        }
        public static void DisplayScreen()
        {
            Screen.Display();
        }
        public static void StopDriver()
        {
            Screen.Disable();
            Screen = null;
        }
        public static SetResolutionResult SetResolution(uint width, uint height)
        {
            bool finded = false;
            foreach (Mode mode in Screen.AvailableModes)
            {
                if (width == mode.Columns && height == mode.Rows)
                {
                    finded = true;
                    Width = width;
                    Height = height;
                    Screen = FullScreenCanvas.GetFullScreenCanvas(new Mode((int)width, (int)height, ColorDepth.ColorDepth32));
                }
            }
            if (!finded)
            {
                return SetResolutionResult.ModeNotFinded;
            }
            else
            {
                return SetResolutionResult.Sucess;
            }
        }
        public static bool IsGraphicsEnabled()
        {
            if (Screen == null)
            { return false; }
            else
            { return true; }
        }
    }
}
