using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Automasion_Software
{
  public static class FormClass
    {
      public static void MouseLeave_HoverItem(Panel penelID, System.Drawing.Color color)
      {
          penelID.BackColor = color;
          penelID.Cursor = System.Windows.Forms.Cursors.Arrow;
      }
    }
}
