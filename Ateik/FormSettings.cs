using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ateik.Properties;

namespace Ateik
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            Text = "Ateik čia";
        }

        private void fSettings_Load(object sender, EventArgs e)
        {
            
            foreach (Size size in Program.frameFormats)
            {
                dgvSizes.Rows.Add(size.Width, size.Height);
            }

            nudTopMarginHeight.Value = Settings.Default.MarginTopPerc;
            nudBottomMarginHeight.Value = Settings.Default.MarginBottomPerc;

            chbShowSight.Checked = Settings.Default.ShowSight;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Program.frameFormats.Clear();
            StringBuilder sb = new StringBuilder();
            int width, height;
            for (int rw = 0; rw < dgvSizes.Rows.Count - 1; rw++ )
            {
                try
                {
                    width = Convert.ToInt32(dgvSizes.Rows[rw].Cells["width"].Value);
                    height = Convert.ToInt32(dgvSizes.Rows[rw].Cells["height"].Value);
                    if (height >= 20 && width >= 20 && (double)width / height < 5 && (double)width / height > .2)
                    {
                        Program.frameFormats.Add(new Size(width, height));
                        sb.Append(string.Format("{0}:{1},", width, height));
                    }
                }
                catch (FormatException)
                {
                    //ewal.Msg.Msg.ErrorMsg(string.Format("{0}:{1}", dgvSizes.Rows[rw].Cells["width"].Value, dgvSizes.Rows[rw].Cells["height"].Value));
                }
                catch (InvalidCastException)
                {
                }
                catch (OverflowException)
                {
                }
                catch (ArgumentOutOfRangeException)
                {
                }

            }
            sb.Remove(sb.Length - 1, 1);
            //MessageBox.Show(sb.ToString());

            Settings.Default.FrameFormats = sb.ToString();
            Settings.Default.MarginTopPerc = Convert.ToUInt32(nudTopMarginHeight.Value);
            Settings.Default.MarginBottomPerc = Convert.ToUInt32(nudBottomMarginHeight.Value);
            Settings.Default.ShowSight = chbShowSight.Checked;
            Settings.Default.PlaySound = chbPlaySound.Checked;
            Settings.Default.Save();
        }
    }
}
