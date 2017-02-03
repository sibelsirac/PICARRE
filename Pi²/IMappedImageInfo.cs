using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bin_packing_a_etoile
{
    public interface IMappedImageInfo
    {
        int X { get; }
        int Y { get; }
        IImageInfo ImageInfo { get; }
    }

}
