using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Framework.GUIs
{
    public interface ITypeable
    {
        bool IsTyping { get; set; }
        string Text { get; set; }
    }
}
