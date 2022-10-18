using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsV2.Interfaces
{
    internal interface IGameObjectFactory
    {
        IGameObject CreateObject();
    }
}
