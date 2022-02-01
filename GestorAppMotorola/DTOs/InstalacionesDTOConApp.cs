using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorAppMotorola.DTOs
{
    public class InstalacionesDTOConApp: InstalacionGetDTO
    {
        //public int AppId { get; set; }
        public AppGetDTO App { get; set; }
    }
}
