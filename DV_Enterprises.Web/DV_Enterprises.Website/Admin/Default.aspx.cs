using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : Page
{
    private readonly MembershipUserCollection allUsers = Membership.GetAllUsers();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        string[] alphabet = "A;B;C;D;E;F;G;H;I;J;K;L;M;N;O;P;Q;R;S;T;U;V;W;X;Y;Z;ALL".Split(';');

        rptAlphabet.DataSource = alphabet;
        rptAlphabet.DataBind();
    }

    protected void btnUserSearch_Click(object sender, EventArgs e)
    {
        bool searchByEmail = ddlUserSearchTypes.SelectedValue == "E-mail";
        gvUsers.Attributes.Add("SearchText","%" + txtUserSearch.Text + "%");
        gvUsers.Attributes.Add("SearchByEmail", searchByEmail.ToString());
        BindAllUsers(false);
    }

    protected void rptAlphabet_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        gvUsers.Attributes.Add("SearchByEmail", false.ToString());
        switch (e.CommandArgument.ToString().Length)
        {
            case 1:
                gvUsers.Attributes.Add("SearchText", e.CommandArgument.ToString() + "%");
                BindAllUsers(false);
                break;
            default:
                gvUsers.Attributes.Add("SearchText", "");
                BindAllUsers(false);
                break;
        }
    }

    protected void GvUsersDataBind()
    {
        gvUsers.DataSource = Membership.GetAllUsers();
        gvUsers.DataBind();
    }

    protected void BindAllUsers(bool reloadUsers)
    {
        MembershipUserCollection users = null;
        string searchText = string.Empty;
        bool searchByEmail = false;

        if (reloadUsers)
        {
            users = Membership.GetAllUsers();
        }
        if (!string.IsNullOrEmpty(gvUsers.Attributes["SearchText"]))
        {
            searchText = gvUsers.Attributes["SearchText"];
        }
        if (!string.IsNullOrEmpty(gvUsers.Attributes["SeachByEmail"]))
        {
            searchByEmail = bool.Parse(gvUsers.Attributes["SeachByEmail"]);
        }
        if(searchText.Length > 0)
        {
            users = searchByEmail ? Membership.FindUsersByEmail(searchText) : Membership.FindUsersByName(searchText);
        }
        else
        {
            users = allUsers;
        }
        gvUsers.DataSource = users;
        gvUsers.DataBind();
    }
    protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var litUserName = e.Row.FindControl("litUserName") as Literal;
        if (litUserName != null)
        {
            var profile = Profile.GetProfile(litUserName.Text);
            var litName = e.Row.FindControl("litName") as Literal;
            var litAddress = e.Row.FindControl("litAddress") as Literal;
            var litPhone = e.Row.FindControl("litPhone") as Literal;
            var lnkEdit = e.Row.FindControl("lnkEdit") as HyperLink;

            if (litName != null) litName.Text = profile.Details.Name;
            if (litAddress != null)
                litAddress.Text = string.Format("{0} {1} {2}", profile.Details.City, profile.Details.State,
                                                profile.Details.ZipCode);
            if (litPhone != null) litPhone.Text = profile.Details.Phone;
            if (lnkEdit != null)
                lnkEdit.NavigateUrl = string.Format("~/Admin/User.aspx?Username={0}", litUserName.Text);
        }
    }
}
