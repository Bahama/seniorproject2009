using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Data.Filters;
using DV_Enterprises.Web.Service;
using DV_Enterprises.Web.Service.Interface;

namespace Products
{
    public partial class Default : Page
    {
        private readonly static IWebContext WebContext = new WebContext();
        private readonly static IRedirector Redirector = new Redirector();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack) return;
            LoadData(Product.Find().All());
        }

        public void LoadData(IList<Product> products)
        {
            lvProducts.DataSource = products;
            lvProducts.DataBind();
        }

        public void lvProducts_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var litProductId = e.Item.FindControl("litProductID") as Literal;
            var linkProductName = e.Item.FindControl("linkProductName") as HyperLink;
            var lbEdit = e.Item.FindControl("lbEdit") as LinkButton;

            if (litProductId == null) return;
            if (lbEdit != null)
            {
                lbEdit.Visible = Roles.IsUserInRole("Administrator");
                lbEdit.Attributes.Add("ProductID", litProductId.Text);
            }
            if (linkProductName != null)
                linkProductName.NavigateUrl = string.Format("~/Products/ViewProduct.aspx?ProductID={0}",
                                                            litProductId.Text);
        }

        public void lbEdit_Click(object sender, EventArgs e)
        {
            var lbEdit = sender as LinkButton;
            Redirector.GoToManageProduct(Convert.ToInt32(lbEdit.Attributes["ProductID"]));
        }

        protected void lvProducts_SelectedIndexChanged(object sender, EventArgs e){}
    }
}