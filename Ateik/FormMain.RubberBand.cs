using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ateik
{
    partial class FormMain
    {
        // PRINCIPAS
        // Visi EventHandler'iai ir metodai manipuliuoja Rectangle'u band.
        // Senasis stačiakampis saugomas lastband. Prieš atliekant kokį nors veiksmą
        // band kopija išsaugoma lastband ir band modifikuojamas.
        // Tada trinamas senas stačiampis lastBand ir piešiamas naujas band; 

        /// <summary>
        /// MouseUp EventHandler
        /// </summary>
        /// <param name="e"></param>
        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            mdframe = new Rectangle();
            action = Action.NoAction;
        }

        /// <summary>
        /// MouseDown EventHandler
        /// </summary>
        /// <param name="e"></param>
        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            halffbw = frameBorderWidth / 2.0F;
            mouseDownLocation = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                if (frame == null)
                {
                    frame = new Rectangle(mouseDownLocation, new Size(1, 1));
                    // nupaišomas naujas (praktiškai nepaišomas)
                    drawReversibleRectangle(frame, true);
                    action = Action.ToDraw;
                    // šitos dvi sąvybės iš tikrųjų turėtų būti jau tokios. Čia aš apsidraudžiu.
                    this.Cursor = Cursors.Cross;
                    border = Border.Outside;
                }
                else
                {
                    border = isOverBorder(mouseDownLocation);
                    switch (border)
                    {
                        case Border.Inside:
                            action = Action.ToDrag;
                            break;
                        case Border.Outside:
                            // senas rėmelis ištrinamas
                            drawReversibleRectangle(frame, false);
                            // sukuriamas naujas
                            frame = new Rectangle(e.Location.X, e.Location.Y, 1, 1);
                            // nupaišomas naujas (praktiškai nepaišomas)
                            drawReversibleRectangle(frame, true);
                            action = Action.ToDraw;
                            this.Cursor = Cursors.Cross;
                            break;
                        case Border.Top:
                            this.Cursor = Cursors.SizeNS;
                            action = Action.ToResize;
                            border = Border.Top;
                            break;
                        case Border.Bottom:
                            this.Cursor = Cursors.SizeNS;
                            action = Action.ToResize;
                            border = Border.Bottom;
                            break;
                        case Border.Right:
                            this.Cursor = Cursors.SizeWE;
                            action = Action.ToResize;
                            border = Border.Right;
                            break;
                        case Border.Left:
                            this.Cursor = Cursors.SizeWE;
                            action = Action.ToResize;
                            border = Border.Left;
                            break;
                    }

                }
                mdframe = frame;
            }
        }

        /// <summary>
        /// MouseMove EventHandler
        /// </summary>
        /// <param name="e"></param>
        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drawReversibleRectangle(frame, false);
                // atitinkamai pakeičiamas
                if (action == Action.ToDraw)
                {
                    frame.Width = e.X - mdframe.X;
                    frame.Height = Convert.ToInt32(frame.Width / frameWHRatio);
                }
                else if (action == Action.ToDrag)
                {
                    // offset
                    frame.X = mdframe.X + (e.X - mouseDownLocation.X);
                    frame.Y = mdframe.Y + (e.Y - mouseDownLocation.Y);
                }
                else if (action == Action.ToResize)
                {
                    resizeFrame(e.Location);
                }


                if (!imageRectangle.Contains(frame))
                {
                    // galima atimti handlerį, kuris fotkina
                    return;
                }
                // nupaišomas naujas
                drawReversibleRectangle(frame, true);
            }

            else if (e.Button == MouseButtons.None)
            {
                switch (isOverBorder(e.Location))
                {
                    case Border.Outside:
                        this.Cursor = Cursors.Cross;
                        break;
                    case Border.Inside:
                        this.Cursor = Cursors.SizeAll;
                        break;
                    case Border.Top:
                    case Border.Bottom:
                        this.Cursor = Cursors.SizeNS;
                        break;
                    case Border.Right:
                    case Border.Left:
                        this.Cursor = Cursors.SizeWE;
                        break;
                }
            }
        }

        /// <summary>
        /// Parodo, ar pelės kursorius yra virš kurios nors rėmelio kraštinės.
        /// </summary>
        /// <param name="mouse">Pelės kursoriaus koordinatės, <see cref="System.Drawing.Point"/></param>
        /// <returns>Virš katros <see cref="ImageCropper.Border"/> kraštinės yra kursorius
        /// arba <c>Border.NoBorder</c>, jeigu kursorius ne virš kraštinės.</returns>
        private Border isOverBorder(Point mouse)
        {
            int mx = mouse.X;
            int my = mouse.Y;
            int fRight = frame.Right;
            int fTop = frame.Top;
            int fLeft = frame.Left;
            int fBottom = frame.Bottom;

            // ar viduje
            if ((mx > fLeft + halffbw) && (my > fTop + halffbw) && (mx < fRight - halffbw) & (my < fBottom - halffbw))
                return Border.Inside;
            // ar virš viršutinio borderio
            if ((mx >= fLeft + halffbw) && (mx <= fRight - halffbw) && (my >= fTop - halffbw) && (my <= fTop + halffbw))
                return Border.Top;
            // ar virš dešiniojo borderio
            if ((mx >= fRight - halffbw) && (mx <= fRight + halffbw) && (my >= fTop + halffbw) && (my <= fBottom - halffbw))
                return Border.Right;
            // ar virš apatinio borderio
            if ((mx >= fLeft + halffbw) && (mx <= fRight - halffbw) && (my >= fBottom - halffbw) && (my <= fBottom + halffbw))
                return Border.Bottom;
            // ar virš kairiojo borderio
            if ((mx >= fLeft - halffbw) && (mx <= fLeft + halffbw) && (my >= fTop + halffbw) && (my <= fBottom - halffbw))
                return Border.Left;
            // išorėje
            return Border.Outside;
        }

        /// <summary>
        /// Priklausomai nuo to, virš katros rėmelio kraštinės braukoma pelė, keičia rėmelio išmatavimus
        /// </summary>
        /// <param name="mouseCurrentLocation">Pelės dabartinė pozicija, <see cref="System.Drawing.Point"/></param>
        /// <returns>Grąžinamas pagrindinių stačiakampio parametrų rinkinys <see cref="ImageCropper.RecParams"/> 
        /// naujam stačiakampiui piešti.</returns>
        private void resizeFrame(Point mouseCurrentLocation)
        {
            switch (border)
            {
                case Border.Top:
                    resizedTop(mouseCurrentLocation);
                    break;
                case Border.Right:
                    resizedRight(mouseCurrentLocation);
                    break;
                case Border.Bottom:
                    resizedBottom(mouseCurrentLocation);
                    break;
                case Border.Left:
                    resizedLeft(mouseCurrentLocation);
                    break;
                default:
                    return;
            }
        }

        /// <summary>
        /// Rėmelio stačiakampis keičiamas perstūmiant aukštyn arba žemyn viršutinę kraštinę.
        /// </summary>
        /// <param name="mouseCurrentLoc">
        /// Dabartinė kursoriaus padėtis (po perstūmimo nuspaudus pelės klavišą), <see cref="System.Drawing.Point"/>
        /// </param>
        private void resizedTop(Point mouseCurrentLoc)
        {
            // padaryti, kad persiverstų

            // pelės poslinkis nuo mouseDown
            int displacementY = mouseCurrentLoc.Y - mouseDownLocation.Y;
            int displacementX = Convert.ToInt32(displacementY * frameWHRatio);

            // jeigu jau visai suplonėjo, tai nedaroma nieko
            if (displacementY >= mdframe.Height - frameBorderWidth) return;

            // jeigu dar yra kur plonėti - ploninamas arba storinamas;
            // frame.X = mdband.X + displacementX;
            // frame.Y = mdband.Y + displacementY;
            frame.Width = mdframe.Width - displacementX;
            frame.Height = mdframe.Height - displacementY;
            frame.X = (mdframe.X + mdframe.Width / 2) - frame.Width / 2;
            frame.Y = (mdframe.Bottom - (int)(marginBottomPerc / 100.0 * mdframe.Height)) + (int)(marginBottomPerc / 100.0 * frame.Height) - frame.Height;
            return;
        }

        /// <summary>
        /// Rėmelio stačiakampis keičiamas perstūmiant kairėn arba dešinėn dešiniąją rėmelio kraštinę.
        /// </summary>
        /// <param name="mouseCurrentLoc">
        /// Dabartinė kursoriaus padėtis (po perstūmimo nuspaudus pelės klavišą), <see cref="System.Drawing.Point"/>
        /// </param>
        private void resizedRight(Point mouseCurrentLoc)
        {
            // padaryti, kad persiverstų

            // pelės poslinkis nuo mouseDown
            int displacementX = mouseCurrentLoc.X - mouseDownLocation.X;
            int displacementY = Convert.ToInt32(displacementX / frameWHRatio);

            // jeigu jau visai suplonėjo, tai nedaroma nieko
            if (-displacementX >= mdframe.Width - frameBorderWidth) return;

            // jeigu dar yra kur plonėti - ploninamas arba storinamas;
            frame.X = mdframe.X;
            frame.Y = mdframe.Y;
            frame.Width = mdframe.Width + displacementX;
            frame.Height = mdframe.Height + displacementY;
            return;
        }

        /// <summary>
        /// Rėmelio stačiakampis keičiamas perstūmiant aukštyn arba žemyn apatiniąją rėmelio kraštinę.
        /// </summary>
        /// <param name="mouseCurrentLoc">
        /// Dabartinė kursoriaus padėtis (po perstūmimo nuspaudus pelės klavišą), <see cref="System.Drawing.Point"/>
        /// </param>
        private void resizedBottom(Point mouseCurrentLoc)
        {
            // padaryti, kad persiverstų

            // pelės poslinkis nuo mouseDown
            int displacementY = mouseCurrentLoc.Y - mouseDownLocation.Y;
            int displacementX = Convert.ToInt32(displacementY * frameWHRatio);

            // jeigu jau visai suplonėjo, tai nedaroma nieko
            if (-displacementY >= mdframe.Height - frameBorderWidth) return;

            // jeigu dar yra kur plonėti - ploninamas arba storinamas;
            // frame.X = mdband.X;
            // frame.Y = mdband.Y;
            // pabandom šitaip:
            frame.Width = mdframe.Width + displacementX;
            frame.X = (mdframe.X + mdframe.Width / 2) - frame.Width / 2;
            frame.Height = mdframe.Height + displacementY;
            frame.Y = (mdframe.Y + (int)(marginTopPerc * mdframe.Height / 100.0)) - (int)(marginTopPerc * frame.Height / 100.0);
            return;
        }

        /// <summary>
        /// Rėmelio stačiakampis keičiamas perstūmiant kairėn arba dešinėn kairiąją rėmelio kraštinę.
        /// </summary>
        /// <param name="mouseCurrentLoc">
        /// Dabartinė kursoriaus padėtis (po perstūmimo nuspaudus pelės klavišą), <see cref="System.Drawing.Point"/>
        /// </param>
        void resizedLeft(Point mouseCurrentLoc)
        {
            // padaryti, kad persiverstų

            // pelės poslinkis nuo mouseDown
            int displacementX = mouseCurrentLoc.X - mouseDownLocation.X;
            int displacementY = Convert.ToInt32(displacementX / frameWHRatio);

            // jeigu jau visai suplonėjo, tai nedaroma nieko
            if (displacementX >= mdframe.Width - frameBorderWidth) return;

            // jeigu dar yra kur plonėti - ploninamas arba storinamas;
            frame.X = mdframe.X + displacementX;
            frame.Y = mdframe.Y + displacementY;
            frame.Width = mdframe.Width - displacementX;
            frame.Height = mdframe.Height - displacementY;
            return;
        }

        /// <summary>
        /// MouseLeave EventHandler
        /// </summary>
        /// <param name="e"></param>
        private void panel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Convert and normalize the points and prepare to draw or eraze the reversible frame
        /// </summary>
        /// <param name="rc"></param>
        /// <param name="toDraw"></param>
        private void drawReversibleRectangle(Rectangle rc, bool toDraw)
        {
            // kad šitas normaliai veiktų, reikia žinoti, kokį ruošiesi piešti.
            // nes paduodant trinti, rc (nutrinamas) būna paveikslo viduje ir būna trinamas.            

            rc.Y += toolbar.Height; // toolbarheight

            // prieš piešiant, tikrina, ar telpa

            rc.Location = PointToScreen(rc.Location);

            // trynimas ir yra nupieštas
            if (!toDraw && isDrawn)
            {
                drawReversibleWithMargins(drawnRectangle);
                isDrawn = false;
                return;
            }

            // trynimas, bet nupiešto nėra
            if (!toDraw && !isDrawn)
                return;

            // piešimas ir nėra nupiešto
            if (toDraw && !isDrawn)
            {
                drawReversibleWithMargins(rc);

                isDrawn = true;
                drawnRectangle = rc;
            }

            // piešimas ir yra nupieštas
            if (toDraw && isDrawn)
            {
                drawReversibleWithMargins(drawnRectangle);
                drawReversibleWithMargins(rc);
            }
        }

        /// <summary>
        /// draw the reversible frame wiht margins if any
        /// </summary>
        /// <param name="rc"></param>
        void drawReversibleWithMargins(Rectangle rc)
        {
            int topMarginHeight = (int)(rc.Height * marginTopPerc / 100.0);
            int bottomMarginHeight = (int)(rc.Height * marginBottomPerc / 100.0);
            ControlPaint.DrawReversibleFrame(rc, Color.Black, FrameStyle.Thick);
            if (showSight)
            {
                Point point1 = new Point(rc.Left, rc.Top + topMarginHeight);
                Point point2 = new Point(rc.Right, rc.Top + topMarginHeight);
                Point point3 = new Point(rc.Left, rc.Bottom - bottomMarginHeight);
                Point point4 = new Point(rc.Right, rc.Bottom - bottomMarginHeight);
                Point point5 = new Point(rc.Left + (int)(rc.Width / 2), rc.Top);
                Point point6 = new Point(rc.Left + (int)(rc.Width / 2), rc.Bottom);                
                ControlPaint.DrawReversibleLine(point1, point2, Color.White);
                ControlPaint.DrawReversibleLine(point3, point4, Color.White);
                ControlPaint.DrawReversibleLine(point5, point6, Color.White);
            }
        }
    }
}