using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ateik
{
    static class Program
    {
        /// <summary>
        /// Kerpančiojo rėmelio formatų sąrašas
        /// </summary>
        static internal List<Size> frameFormats = new List<Size>();
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
