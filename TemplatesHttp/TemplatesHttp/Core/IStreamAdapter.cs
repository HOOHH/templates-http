﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatesHttp.Core
{
    public interface IStreamAdapter
    {
        Stream Adapt(Stream stream);
    }
}
