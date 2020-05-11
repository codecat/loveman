using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

// Microsoft internalizes System.Windows.Forms.Layout.LayoutUtils.
// This mimicks the behavior of some functions in LayoutUtils.
// There might be a better way with public methods, but this works too, for now.

namespace Nimble.Controls
{
  public class LayoutUtils
  {
    public const ContentAlignment AnyOnTop = ContentAlignment.TopLeft | ContentAlignment.TopCenter | ContentAlignment.TopRight;
    public const ContentAlignment AnyOnBottom = ContentAlignment.BottomLeft | ContentAlignment.BottomCenter | ContentAlignment.BottomRight;
    public const ContentAlignment AnyOnLeft = ContentAlignment.TopLeft | ContentAlignment.MiddleLeft | ContentAlignment.BottomLeft;
    public const ContentAlignment AnyOnRight = ContentAlignment.TopRight | ContentAlignment.MiddleRight | ContentAlignment.BottomRight;
    public const ContentAlignment AnyOnCenter = ContentAlignment.TopCenter | ContentAlignment.MiddleCenter | ContentAlignment.BottomCenter;
    public const ContentAlignment AnyOnMiddle = ContentAlignment.MiddleLeft | ContentAlignment.MiddleCenter | ContentAlignment.MiddleRight;

    public static Rectangle AlignHorizontal(Size size, Rectangle container, ContentAlignment alignment)
    {
      if ((alignment & AnyOnRight) != 0) {
        container.X += container.Width - size.Width;
      } else if ((alignment & AnyOnCenter) != 0) {
        container.X += (container.Width - size.Width) / 2;
      }
      container.Width = size.Width;
      return container;
    }

    public static Rectangle AlignVertical(Size size, Rectangle container, ContentAlignment alignment)
    {
      if ((alignment & AnyOnBottom) != 0) {
        container.Y += container.Height - size.Height;
      } else if((alignment & AnyOnMiddle) != 0) {
        container.Y += (container.Height - size.Height) / 2;
      }
      container.Height = size.Height;
      return container;
    }

    public static Rectangle Align(Size size, Rectangle container, ContentAlignment alignment)
    {
      return AlignVertical(size, AlignHorizontal(size, container, alignment), alignment);
    }
  }
}
