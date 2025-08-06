using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiteTheBullet
{
    public enum LayerEnum
    {
        Background,
        Default,
        Player,
        
    }

    [Flags]
    public enum CollisionLayers
    {
        Default,
        Player,
        Trigger = 1 << 1
    }

}
