using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LogicInterface
{
    public enum Filter { Original, GreyScale, Threshold, Invert }
    public interface IImageFilter
    {
        event Action<int> progressEvent;
        Image FilteredImage { get; }

        void Load(string file);

        void ApplyFilter(Filter filterMode);
        
    }
}
