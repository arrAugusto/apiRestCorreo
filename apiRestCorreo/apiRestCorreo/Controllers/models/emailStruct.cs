using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestCorreo.Controllers.models
{
    public class emailStruct
    {
        public int idUserEnvia { get; set; }
        public int idUserRecibe { get; set; }
        public string asuntEnvia { get; set; }
        public string correoCuerpo { get; set; }


    }
}
