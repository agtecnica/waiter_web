using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUI.Ferramentas.Controles
{
    public class ButtomCustom2 : Button
    {

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == (NativeMethods.WM_REFLECT | NativeMethods.WM_NOTIFY))
            {
                NativeMethods.NMCUSTOMDRAW CustomDrawHeader = (NativeMethods.NMCUSTOMDRAW)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.NMCUSTOMDRAW));
                if (CustomDrawHeader.dwDrawStage == NativeMethods.CustomDrawDrawStage.CDDS_PREPAINT)
                {
                    Graphics g = Graphics.FromHdc(CustomDrawHeader.hdc);
                    PaintEventArgs pe = new PaintEventArgs(g, this.Bounds);
                    OnPaint(pe);
                    pe.Dispose();
                    g.Dispose();
                }
            }
        }


        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawImage(e.Graphics);
        }


        protected void DrawImage(Graphics g)
        {
            if (this.Image == null) return;

            PointF pt = new Point();

            switch (this.ImageAlign)
            {
                case ContentAlignment.TopLeft:
                    {
                        pt.X = 5;
                        pt.Y = 5;
                        break;
                    }
                case ContentAlignment.TopCenter:
                    {
                        pt.X = Convert.ToSingle(Width - this.Image.Width) / 2;
                        pt.Y = 5;
                        break;
                    }
                case ContentAlignment.TopRight:
                    {
                        pt.X = Width - this.Image.Width - 5;
                        pt.Y = 5;
                        break;
                    }
                case ContentAlignment.MiddleLeft:
                    {
                        pt.X = 5;
                        pt.Y = Convert.ToSingle(Height - this.Image.Height) / 2;
                        break;
                    }
                case ContentAlignment.MiddleCenter:
                    {
                        pt.X = Convert.ToSingle(Width - this.Image.Width) / 2;
                        pt.Y = Convert.ToSingle(Height - this.Image.Height) / 2;
                        break;
                    }
                case ContentAlignment.MiddleRight:
                    {
                        pt.X = Width - this.Image.Width - 5;
                        pt.Y = Convert.ToSingle(Height - this.Image.Height) / 2;
                        break;
                    }
                case ContentAlignment.BottomLeft:
                    {
                        pt.X = 5;
                        pt.Y = Height - this.Image.Height - 5;
                        break;
                    }
                case ContentAlignment.BottomCenter:
                    {
                        pt.X = Convert.ToSingle(Width - this.Image.Width) / 2;
                        pt.Y = Height - this.Image.Height - 5;
                        break;
                    }
                default:
                    {
                        pt.X = Width - this.Image.Width - 5;
                        pt.Y = Height - this.Image.Height - 5;
                        break;
                    }
            }

            if (this.Enabled)
            {
                if (this.ImageList == null)
                    g.DrawImage(this.Image, pt.X, pt.Y);
                else
                    this.ImageList.Draw(g, Point.Round(pt), this.ImageIndex);
            }
            else
                ControlPaint.DrawImageDisabled(g, this.Image, (int)pt.X, (int)pt.Y, this.BackColor);
        }

    }

    internal class NativeMethods
    {
        private NativeMethods()
        {
            //Uninstantiable Class
        }


        public const int WM_USER = 0x400;
        public const int WM_NOTIFY = 0x4E;
        public const int WM_REFLECT = WM_USER + 0x1C00;
        public const int NM_FIRST = 0;
        public const int NM_CUSTOMDRAW = NM_FIRST | -12;

        public enum CustomDrawDrawStage
        {
            CDDS_PREPAINT = 0x1,
            CDDS_POSTPAINT = 0x2,
            CDDS_PREERASE = 0x3,
            CDDS_POSTERASE = 0x4,
            CDDS_ITEM = 0x10000,
            CDDS_ITEMPREPAINT = (CDDS_ITEM | CDDS_PREPAINT),
            CDDS_ITEMPOSTPAINT = (CDDS_ITEM | CDDS_POSTPAINT),
            CDDS_ITEMPREERASE = (CDDS_ITEM | CDDS_PREERASE),
            CDDS_ITEMPOSTERASE = (CDDS_ITEM | CDDS_POSTERASE),
            CDDS_SUBITEM = 0x20000
        }


        public enum CustomDrawItemState
        {
            CDIS_SELECTED = 0x1,
            CDIS_GRAYED = 0x2,
            CDIS_DISABLED = 0x4,
            CDIS_CHECKED = 0x8,
            CDIS_FOCUS = 0x10,
            CDIS_DEFAULT = 0x20,
            CDIS_HOT = 0x40,
            CDIS_MARKED = 0x80,
            CDIS_INDETERMINATE = 0x100,
            CDIS_SHOWKEYBOARDCUES = 0x200
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct NMHDR
        {
            public IntPtr HWND;
            public int idFrom;
            public int code;
            public override String ToString()
            {
                return String.Format("Hwnd: {0}, ControlID: {1}, Code: {2}", HWND, idFrom, code);
            }
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct NMCUSTOMDRAW
        {
            public NMHDR hdr;
            public CustomDrawDrawStage dwDrawStage;
            public IntPtr hdc;
            public RECT rc;
            public IntPtr dwItemSpec;
            public CustomDrawItemState uItemState;
            public IntPtr lItemlParam;
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left, top, right, bottom;
        }
    }
}
