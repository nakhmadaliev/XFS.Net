using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFSNet
{
    public interface ISTATUS 
    {
        ISTATUS UnMarshal(IntPtr pointer);
    }
}
