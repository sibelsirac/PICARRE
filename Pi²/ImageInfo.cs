using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bin_packing_a_etoile
{
    public class ImageInfo : IImageInfo
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public ImageInfo(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
