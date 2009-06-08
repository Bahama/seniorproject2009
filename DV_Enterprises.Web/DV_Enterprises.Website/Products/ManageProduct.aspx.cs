using System;
using System.Web.UI;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Service;
using DV_Enterprises.Web.Service.Interface;

namespace Products
{
    public partial class ManageProduct : Page
    {
        private readonly static IWebContext WebContext = new WebContext();
        private readonly static IRedirector Redirector = new Redirector();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Administrator")) Redirector.GoToHomePage();
            if (IsPostBack) return;
            if (WebContext.ProductId <= 0) Redirector.GoToProducts();
            LoadData(Product.Find((WebContext.ProductId)));
        }

        public void LoadData(Product product)
        {
            litProductId.Text = product.ID.ToString();
            txtName.Text = product.Name;
            txtDescription.Text = product.Description;
            txtPrice.Text = product.Price.ToString();
            cboIsActive.Checked = product.IsActive;
            txtImage.Text = product.Image;
        }

        protected void butSubmit_Click(object sender, EventArgs e)
        {
            new Product
                {
                    ID = string.IsNullOrEmpty(litProductId.Text) ? 0 : Convert.ToInt32(litProductId.Text),
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Price = Convert.ToDecimal(txtPrice.Text),
                    IsActive = cboIsActive.Checked,
                    Image = txtImage.Text,
                }.Save();
            Redirector.GoToProducts();
        }
    }
}