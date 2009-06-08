using System;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Service;
using DV_Enterprises.Web.Service.Interface;

namespace Greenhouses
{
    public partial class AddCrop : System.Web.UI.Page
    {
        private readonly static IWebContext WebContext = new WebContext();
        private readonly static IRedirector Redirector = new Redirector();

        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            new Preset
                {
                    ID = 0,
                    Name = txtCropName.Text,
                    IdealTemperature = Convert.ToInt32(txtIdealTemp.Text),
                    TemperatureThreshold = Convert.ToInt32(txtTempRange.Text),
                    IdealLightIntensity = Convert.ToInt32(txtLightRange.Text),
                    LightIntensityThreshold = Convert.ToInt32(txtLightRange.Text),
                    IdealHumidity = Convert.ToInt32(txtHumidity.Text),
                    HumidityThreshold = Convert.ToInt32(txtHumidityRange.Text),
                    IdealWaterLevel = Convert.ToInt32(txtWaterLevel.Text),
                    WaterLevelThreshold = Convert.ToInt32(txtWaterThreshold.Text)

                }.Save();
        }
    }
}