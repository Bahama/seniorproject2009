using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace Admin
{
    public partial class User : Page
    {
        private MembershipUserCollection users = Membership.GetAllUsers();
        private readonly IWebContext _webContext;
        private readonly IRedirector _redirector;

        public User()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (_webContext.Username == string.Empty) _redirector.GoToAdminPage();
            if (IsPostBack) return;
            var username = _webContext.Username;
            var user = users[username];
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
            var roles = string.Empty;
            foreach (var role in Roles.GetRolesForUser(user.UserName))
            {
                roles = role;
            }
            litRoles.Text = roles;
            lvGreenhouses.DataSource = Greenhouse.FindByUsername(user.UserName);
            lvGreenhouses.DataBind();
        }

        protected void lbView_Click(object sender, EventArgs e)
        {
            var lbView = sender as LinkButton;
            if (lbView != null) _redirector.GoToViewGreenhouse(Convert.ToInt32(lbView.Attributes["GreenhouseID"]));
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
            users.Remove(User.Identity.Name);
        }
    }
}