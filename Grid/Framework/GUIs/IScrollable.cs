using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Framework.GUIs
{
    public interface Scrollable
    {
        int MaxScrollValue { get; set; }
        int MinScrollValue { get; set; }
        int ScrollValue { get; set; }
        void Scroll(int value);
    }
}
