using System.Collections.Generic;
using System.Drawing;
using System.Media;

namespace Ateik
{
    partial class FormMain
    {
        /// <summary>
        /// Galimos pelės padėtys kerpančiojo rėmelio atžvilgiu
        /// </summary>
        private enum Border { Outside, Inside, Top, Right, Bottom, Left };

        /// <summary>
        /// Galimi veiksmai su kerpančiuoju rėmeliu
        /// </summary>
        private enum Action { NoAction, ToDraw, ToDrag, ToResize } ;

        /// <summary>
        /// Virš katros rėmelio kraštinės yra pelė
        /// </summary>
        private Border border = Border.Outside;

        /// <summary>
        /// Koks veiksmas bus atliekamas su rėmeliu
        /// </summary>
        private Action action = Action.NoAction;

        /// <summary>
        /// Pelės koordinatė, kai buvo paspaustas kairysis pelės klavišas
        /// </summary>
        private Point mouseDownLocation;

        /// <summary>
        /// Rėmelis kairiojo pelės klavišo nuspaudimo momentu
        /// </summary>
        private Rectangle mdframe;

        /// <summary>
        /// Pradinis rėmelio pločio-aukščio santykis
        /// </summary>
        const double DefaultFrameWHRatio = 1.0d;

        /// <summary>
        /// Pradinis virtualusis rėmelio storis
        /// </summary>
        const int DefaultFrameBorderWidth = 6;

        /// <summary>
        /// Kerpančiojo rėmelio pločio ir aukščio santykis
        /// </summary>
        private double frameWHRatio;

        /// <summary>
        /// Kerpančiojo rėmelio stačiakampis, kurio manipuliuojama -
        /// kuris piešiamas dabar arba nupieštas ką tik
        /// </summary>
        private Rectangle frame;

        /// <summary>
        /// Image File Name
        /// </summary>
        private string imgFileName;

        /// <summary>
        /// The obj in which the current image is stored
        /// </summary>
        private System.Drawing.Bitmap myBmp;

        /// <summary>
        /// Garsas kai fotografuojama
        /// </summary>
        private SoundPlayer shutterSound;

        /// <summary>
        /// Nustatytas kerpančiojo rėmelio virtualusis storis pikseliais
        /// </summary>
        private uint frameBorderWidth = DefaultFrameBorderWidth;

        /// <summary>
        /// Pusė rėmelio virtualaus storio
        /// </summary>
        private float halffbw;

        /// <summary>
        /// Šiuo metu nustatytas kerpančiojo rėmelio widht:height santykis
        /// </summary>
        Size frameFormat;

        /// <summary>
        /// The obj in which MyBitmap's original size is stored
        /// </summary>
        private Size bmpOrigSize = new Size(640, 480);

        /// <summary>
        /// Nustatytas myBmp atvaizdavimo ekrane mastelis (kad tilptų ekrane)
        /// </summary>
        private float bmpScale = 1.00F;

        /// <summary>
        /// Paveikslėlio stačiakampis formos ClientArea zonoje
        /// </summary>
        private Rectangle imageRectangle = new Rectangle();

        /// <summary>
        /// The Form rectangle object
        /// </summary>
        private Rectangle formRectangle = new Rectangle();
        /// <summary>
        /// Minimalus formos plotis, iki kurio ji bus mažinama, jeigu paveikslėlis labai mažas
        /// </summary>
        private int minFormWidth = 445;

        /// <summary>
        /// Minimalus formos aukštis, iki kurio ji gali būti mažinama, jeigu paveikslėlis labai mažas
        /// </summary>
        private int minClArHeight = 100;

        /// <summary>
        /// Darbalaukio darbinės srities stačiakampis
        /// </summary>
        private Rectangle desktopWArea;

        /// <summary>
        /// Šoninių formos paraščių pločių suma
        /// </summary>
        private int formLRMargins;

        /// <summary>
        /// Formos antraštės juostos aukštis
        /// </summary>
        private int titleBarHeight;

        /// <summary>
        /// Ar rodyti taikiklį
        /// </summary>
        private bool showSight;

        /// <summary>
        /// Ar groti muziką, kai fotografuoja
        /// </summary>
        private bool playSound;

        /// <summary>
        /// Ar rėmelis yra piešiamas (jeigu false, reiškia - trinamas)
        /// </summary>
        bool isDrawn;

        /// <summary>
        /// Paskutinis nupieštas stačiakampis
        /// </summary>
        Rectangle drawnRectangle;

        /// <summary>
        /// Viršutinės paraštės aukštis procentais nuo rėmelio aukščio
        /// </summary>
        uint marginTopPerc = 9;

        /// <summary>
        /// Apatinės paraštės aukštis procentais nuo rėmelio aukščio
        /// </summary>
        uint marginBottomPerc = 20;
    }
}