using System;
using System.Collections.Generic;
using ControlMedicoApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ControlMedicoApi.Models.UtlilityModel;

namespace ControlMedicoApi.Tests.Controllers
{
    [TestClass]
    public class CatalogoControllerTest
    {
        [TestMethod]
        public void GetAllEstatusOrdensTest()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<object> listaEstatusOrden = new List<object>();

                listaEstatusOrden.Add(new { IdEstatusOrden = (int)EstatusOrdenEnum.ENTO, Descripcion = "Entregada a Origen" });
                listaEstatusOrden.Add(new { IdEstatusOrden = (int)EstatusOrdenEnum.REC, Descripcion = "Recibido" });
                listaEstatusOrden.Add(new { IdEstatusOrden = (int)EstatusOrdenEnum.PRO, Descripcion = "En proceso" });
                listaEstatusOrden.Add(new { IdEstatusOrden = (int)EstatusOrdenEnum.ENTR, Descripcion = "Entregada a Receptor" });

                response.List = listaEstatusOrden;
                response.Response = true;
            }
            catch (Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            Assert.IsNotNull(response);
        }
    }
}
