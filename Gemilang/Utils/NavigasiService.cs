using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemilang.Utils
{
    public class NavigasiService(Panel panel)
    {
        private Panel panelUtama = panel;

        public void Navigasi(UserControl page)
        {
            panelUtama.Controls.Clear();
            page.Size = panelUtama.Size;
            page.Dock = DockStyle.Fill;
            panelUtama.Controls.Add(page);
        }
    }
}
