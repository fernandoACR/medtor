using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            ErrorList = new List<string>();
        }

        public bool Response { get; set; }
        public object Entity { get; set; }
        public dynamic List { get; set; }
        public List<string> ErrorList { get; set; }
    }
}