using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Media;
using System.Windows.Forms;
using Ateik.Properties;
using ewal.Msg;
namespace Ateik
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// Konstruktorius. Inicializuoja ir parodo formą
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            Text = "Ateik čia";
            //ClientSize = bmpOrigSize;
            this.SetStyle(ControlStyles.DoubleBuffer |
                            ControlStyles.UserPaint |
                            ControlStyles.AllPaintingInWmPaint,
                             true);
            this.UpdateStyles();
        }

        /// <summary>
        /// Užkraunama ir nustatoma pagrindinė forma:
        /// - iš xml failo nuskaitomi galimi kerpančiojo rėmelio formatai
        /// - užpildomas formatų combobox'as
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            desktopWArea = Screen.GetWorkingArea(this);
            if (desktopWArea.Size.Width < minFormWidth ||
                desktopWArea.Size.Height < minClArHeight + statusbar.Height + toolbar.Height)
            {
                Msg.ErrorMsg(string.Format("{0}.", Messages.Default.DesktopToSmall));
                Application.Exit();
            }
            base.OnLoad(e);
            this.ClientSize = new Size(720, 444);
            readFormats();
            this.cmbDimensions.SelectedIndexChanged += new System.EventHandler(this.cmbDimensions_SelectedIndexChanged);
            //resetFormatsCmb();
            frameWHRatio = (double)frameFormat.Width / frameFormat.Height;
            shutterSound = new SoundPlayer("shutter.wav");
            this.DoubleBuffered = true;
            marginTopPerc = Settings.Default.MarginTopPerc;
            marginBottomPerc = Settings.Default.MarginBottomPerc;
            formLRMargins = this.Width - this.panel.Width;
            titleBarHeight = this.Height - this.toolbar.Height - this.panel.Height - this.statusbar.Height;
            showSight = Settings.Default.ShowSight;
            playSound = Settings.Default.PlaySound;
        }

        /// <summary>
        /// panel_Paint EventHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            if (myBmp != null)
            {
                e.Graphics.DrawImage(myBmp, imageRectangle);
            }
        }

        /// <summary>
        /// Perskaito kerpančiojo rėmelio formatų (width:height) sąrašą iš xml failo ir jį
        /// užkrauna į sąrašą <c>frameFormats</c>, o formatų reprezentacijas - į sąrašą cmbLines
        /// </summary>
        private void readFormats()
        {
            string[] formats = Settings.Default.FrameFormats.Split(',');
            cmbDimensions.ComboBox.DataSource = formats;
            Program.frameFormats.Clear();
            foreach (string format in formats)
            {
                Program.frameFormats.Add(new Size(
                            Convert.ToInt32(format.Substring(0, format.IndexOf(':'))),
                            Convert.ToInt32(format.Substring(format.IndexOf(':') + 1, format.Length - format.IndexOf(':') - 1))
                            ));
            }
            if (Settings.Default.SelectedFrameSizeIndex <= cmbDimensions.ComboBox.Items.Count-1)
                cmbDimensions.ComboBox.SelectedIndex = Settings.Default.SelectedFrameSizeIndex;
            else
            {
                cmbDimensions.ComboBox.SelectedIndex = 0;
                Settings.Default.SelectedFrameSizeIndex = 0;
                Settings.Default.Save();
            }
            
            frameFormat = Program.frameFormats[0];
            frameWHRatio = (double)frameFormat.Width / frameFormat.Height;
        }

        /// <summary>
        /// cmbDimensions SelectedIndexChanged EventHandler - keičiamas rėmelio formatas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDimensions_SelectedIndexChanged(object sender, EventArgs e)
        {
            frameFormat = Program.frameFormats[cmbDimensions.ComboBox.SelectedIndex];
            frameWHRatio = (double)frameFormat.Width / frameFormat.Height;
            Settings.Default.SelectedFrameSizeIndex = cmbDimensions.ComboBox.SelectedIndex;
            Settings.Default.Save();
        }

        /// <summary>
        /// btnExit_Click EventHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        } 

        /// <summary>
        /// panel_MouseDoubleClick Event Handler - fotografavimas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(frame.Contains(e.Location) && imageRectangle.Contains(frame))             
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = Settings.Default.SaveImageFileDialogTitle;
                sfd.Filter = Settings.Default.SaveImageExtensionFilter;
                sfd.AddExtension = true;
                if (sfd.Filter.Length > Settings.Default.SaveImageExtensionFilterIndex)
                    sfd.FilterIndex = Settings.Default.SaveImageExtensionFilterIndex;
                else
                    sfd.FilterIndex = 0;
                try
                {
                    sfd.InitialDirectory = Settings.Default.SaveImageInitialFolder;
                }
                catch (DirectoryNotFoundException)
                {
                    sfd.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                }
                sfd.FileName = string.Format("{0} {1}", Path.GetFileNameWithoutExtension(imgFileName), Settings.Default.SaveImageFileNameSuffix);
                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    drawReversibleRectangle(frame, false);
                    frame = new Rectangle();
                    sfd.Dispose();
                    panel.Invalidate();
                    return;
                }

                try
                {
                    frame.Location = panelToBmp(frame.Location);
                    frame.X = (int)(frame.X / bmpScale);
                    frame.Y = (int)(frame.Y / bmpScale);
                    frame.Width = (int)(frame.Width / bmpScale);
                    frame.Height = (int)(frame.Height / bmpScale);
                    Image resultImg = processBmp(myBmp, frame, frameFormat.Width, frameFormat.Height);
                    ImageFormat imgformat;
                    switch (sfd.FilterIndex)
                    {
                        case 1:
                            imgformat = ImageFormat.Bmp;
                                break;
                        case 2:
                                imgformat = ImageFormat.Jpeg;
                                break;
                        case 3:
                                imgformat = ImageFormat.Png;
                                break;
                        default:
                                imgformat = ImageFormat.Bmp;
                                break;
                    }
                    resultImg.Save(sfd.FileName, imgformat);
                    // Msg.InformationMsg(string.Format("Index: {0}, ImageFormat: {1}, Filter: {2}", sfd.FilterIndex, imgformat, sfd.Filter));

                    Settings.Default.SaveImageExtensionFilterIndex = sfd.FilterIndex;
                    Settings.Default.SaveImageInitialFolder = Path.GetDirectoryName(sfd.FileName);
                    Settings.Default.Save();

                    if (playSound) shutterSound.Play();
                    else Msg.InformationMsg("Atlikta.");                   
                }
                catch(System.Runtime.InteropServices.ExternalException)
                {
                    Msg.ErrorMsg(string.Format("{0} {1}.", Messages.Default.FailedSaveImageFile, sfd.FileName));
                    return;
                }
                finally
                {
                    drawReversibleRectangle(frame, false);
                    frame = new Rectangle();
                    sfd.Dispose();
                    panel.Invalidate();
                }      

            }
        }

        /// <summary>
        /// btnLoadImage_Click EventHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            drawReversibleRectangle(frame, false);
            frame = new Rectangle();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = Settings.Default.ImageFileExtensionFilter;
            ofd.Title = Settings.Default.SelectImageFileDialogTitle;
            try
            {
                ofd.InitialDirectory = Settings.Default.OpenImageInitialFolder;
            }
            catch(DirectoryNotFoundException)
            {
                ofd.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
            }
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                ofd.Dispose();
                return;
            }

            try
            {
                myBmp = (Bitmap)Bitmap.FromFile(ofd.FileName);
                Settings.Default.OpenImageInitialFolder = Path.GetDirectoryName(ofd.FileName);
                Settings.Default.Save();
                imgFileName = ofd.FileName; // rezultato išsaugojimui
            }
            catch (FileNotFoundException)
            {
                Msg.ErrorMsg(string.Format("{0} {1}.", Messages.Default.FailedOpenImageFile, ofd.FileName));
                return;
            }
            catch (OutOfMemoryException)
            {
                Msg.ErrorMsg(string.Format("{0} {1}.", Messages.Default.FailedOpenImageFile, ofd.FileName));
                return;
            }
            catch (PathTooLongException)
            {
                Msg.ErrorMsg(string.Format("{0} {1}.", Messages.Default.FailedOpenImageFile, ofd.FileName));
                return;
            }            
            finally
            {
                ofd.Dispose();
            }
            changePose.Enabled = true;
            bmpOrigSize = myBmp.Size; // nežinau, ar dar bereikalinga saugoti globaliai
            sutvarkytiFormaByBmpSize(bmpOrigSize);
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
            this.panel.MouseLeave += new System.EventHandler(this.panel_MouseLeave);
            this.panel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDoubleClick);
            panel.Invalidate();

        }

        /// <summary>
        /// Pagal paveikslo išmieras parenka formos dydį,
        /// nustato paveikslėlio stačiakampio koordinates,
        /// išcentruoja formą ekrane
        /// </summary>
        /// <param name="paveiksloSize"></param>
        private void sutvarkytiFormaByBmpSize(Size paveiksloSize)
        {
            calculateBitmapScale(paveiksloSize);
            calculateRectangles(paveiksloSize);
            this.Size = formRectangle.Size;
            this.CenterToScreen();
        }

        /// <summary>
        /// btnSettings_Click EventHandler kad užkrauti nustatymų formą
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettings_Click(object sender, EventArgs e)
        {
            drawReversibleRectangle(frame, false);
            frame = new Rectangle();
            panel.Invalidate();
            using (FormSettings fsettings = new FormSettings())
            {
                fsettings.ShowDialog();
            }
            readFormats();
            showSight = Settings.Default.ShowSight;
            playSound = Settings.Default.PlaySound;
        }

        /// <summary>
        /// panel koordinates verčia image koordinatėmis fotografavimui
        /// </summary>
        /// <param name="panelPoint"></param>
        /// <returns></returns>
        private Point panelToBmp(Point panelPoint)
        {
            return new Point(panelPoint.X - imageRectangle.X, panelPoint.Y - imageRectangle.Y);
        }

        /// <summary>
        /// Atlieka paveikslėlio apkarpymą ir dydžio keitimą
        /// </summary>
        /// <param name="bmp">paveikslėlis</param>
        /// <param name="cropArea">stačiakampis, kurį reikia iškirpti</param>
        /// <param name="toWidth">plotis, iki kurio resizinti</param>
        /// <param name="toHeight">aukštis, iki kurio resizinti</param>
        /// <returns></returns>
        static private Image processBmp(Bitmap bmp, Rectangle cropArea, int toWidth, int toHeight)
        {
            Bitmap croppedBmp = bmp.Clone(cropArea, bmp.PixelFormat);
            Bitmap resizedBmp = new Bitmap(toWidth, toHeight);            
            Graphics resizedGraphics = Graphics.FromImage((Image)resizedBmp);
            resizedGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            resizedGraphics.DrawImage(croppedBmp, 0, 0, toWidth, toHeight);

            croppedBmp.Dispose();
            resizedGraphics.Dispose();

            return (Image)resizedBmp;
        }

        /// <summary>
        /// rotateCW_Click EventHandler - suka foto pagal laikrodžio rodyklę
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rotateCW_Click(object sender, EventArgs e)
        {
            myBmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            sutvarkytiFormaByBmpSize(myBmp.Size);
            panel.Invalidate();
        }

        /// <summary>
        /// rotateCCW_Click EventHandler - suka foto prieš laikrodžio rodyklę
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rotateCCW_Click(object sender, EventArgs e)
        {
            myBmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            sutvarkytiFormaByBmpSize(myBmp.Size);
            panel.Invalidate();
        }

        /// <summary>
        /// flipHorizontal_Click EventHandler - atspindi paveikslėlį horizontaliai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flipHorizontal_Click(object sender, EventArgs e)
        {
            myBmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            sutvarkytiFormaByBmpSize(myBmp.Size);
            panel.Invalidate();
        }

        /// <summary>
        /// flipVertical_Click EventHandler - atspindi paveikslėlį vertikaliai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flipVertical_Click(object sender, EventArgs e)
        {
            myBmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            sutvarkytiFormaByBmpSize(myBmp.Size);
            panel.Invalidate();
        }


    }
    // padaryti, kad resizinant formą, resizintų ir centruotų paveikslą.
    
}
