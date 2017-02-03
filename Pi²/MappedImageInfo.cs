using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bin_packing_a_etoile
{
    public class MappedImageInfo : IMappedImageInfo
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public IImageInfo ImageInfo { get; private set; }

        public MappedImageInfo(int x, int y, IImageInfo imageInfo)
        {
            X = x;
            Y = y;
            ImageInfo = imageInfo;
        }

    }
}
