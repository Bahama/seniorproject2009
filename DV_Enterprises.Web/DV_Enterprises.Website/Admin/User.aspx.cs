using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Service;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace Admin
{
    public partial class User : Page
    {
        private readonly MembershipUserCollection _users = Membership.GetAllUsers();
        private static readonly IWebContext WebContext = new WebContext();
        private static readonly IRedirector Redirector = new Redirector();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebContext.Username == string.Empty) Redirector.GoToAdminPage();
            if (IsPostBack) return;
            var username = WebContext.Username;
            var user = _users[username];
            var userProfile = Profile.GetProfile(user.UserName);

            var title = string.IsNullOrEmpty(userProfile.Details.Name)
                            ? username
                            : userProfile.Details.Name;
            Title = litTitle.Text = string.Format("Account Information for {0}", title);
            litUserName.Text = user.UserName;
            linkEmail.NavigateUrl = string.Format("mailto:{0}", user.Email);
            linkEmail.Text = user.Email;
            litFullAddress.Text = userProfile.Details.Address;
            litPhone.Text = userProfile.Details.Phone;
            if (Roles.IsUserInRole(user.UserName, "administrator"))
            {
                butToggleAdmin.Text = "remove from administrators";
                butToggleAdmin.Attributes.Add("IsAdmin", "True");
            }
            else
            {
                butToggleAdmin.Text = "make administrator";
                butToggleAdmin.Attributes.Add("IsAdmin", "False");
            }
            lvGreenhouses.DataSource = Greenhouse.FindByUsername(user.UserName);
            lvGreenhouses.DataBind();
        }

        protected void lbView_Click(object sender, EventArgs e)
        {
            var lbView = sender as LinkButton;
            if (lbView != null) Redirector.GoToViewGreenhouse(Convert.ToInt32(lbView.Attributes["GreenhouseID"]));
        }

        protected void lvGreenhouses_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var litGreenhouseId = e.Item.FindControl("litGreenhouseId") as Literal;
            var linkView = e.Item.FindControl("linkView") as HyperLink;
            if (linkView != null && litGreenhouseId != null)
                linkView.NavigateUrl = string.Format("~/Greenhouses/ViewGreenhouse.aspx?GreenhouseID={0}", litGreenhouseId.Text);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            _users.Remove(User.Identity.Name);
        }

        protected void butToggleAdmin_Click(object sender, EventArgs e)
        {
            var user = _users[litUserName.Text];
            if (bool.Parse(butToggleAdmin.Attributes["IsAdmin"]))
            {
                Roles.RemoveUserFromRole(user.UserName, "administrator");
            }
            else
            {
                Roles.AddUserToRole(user.UserName, "administrator");
            }
            Redirector.GoToAdminUserPage(user.UserName);
        }
    }
}