using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemilang.Utils
{
    public class UserControlPrinter
    {
        private readonly UserControl _userControl;

        public UserControlPrinter(UserControl userControl)
        {
            _userControl = userControl;
        }

        public void Print()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintPage;

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 800,
                Height = 600
            };

            if (printPreviewDialog.ShowDialog() == DialogResult.OK)
            {
                PrintDialog printDialog = new PrintDialog
                {
                    Document = printDoc,
                    UseEXDialog = true
                };

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(_userControl.Width, _userControl.Height);
            _userControl.DrawToBitmap(bmp, new Rectangle(0, 0, _userControl.Width, _userControl.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
