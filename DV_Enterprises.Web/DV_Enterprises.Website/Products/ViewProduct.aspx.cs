using System;
using System.Web.UI;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Data.Filters;
using DV_Enterprises.Web.Service;
using DV_Enterprises.Web.Service.Interface;

namespace Products
{
    public partial class ViewProduct : Page
    {
        private readonly static IWebContext WebContext = new WebContext();
        private readonly static IRedirector Redirector = new Redirector();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (WebContext.ProductId <= 0) Redirector.GoToProducts();
            LoadData(Product.Find().ByID((WebContext.ProductId)));
        }

        public void LoadData(Product product)
        {
            lblName.Text = product.Name;
            lblPrice.Text = string.Format("Price: {0}", product.Price.ToString("C"));
            lblDescription.Text = product.Description;
            ImgProduct.ImageUrl = product.Image;
        }
    }
}