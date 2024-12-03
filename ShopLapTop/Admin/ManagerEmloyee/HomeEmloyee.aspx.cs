using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerEmloyee
{
    public partial class HomeEmloyee : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int page = 1;

                if (Request.QueryString["page"] != null)
                {
                    int.TryParse(Request.QueryString["page"], out page);
                }
                LoadPage(page);
                var roles = Session["Roles"] as List<string>;
                if(roles.Contains("Thêm Tài Khoản Nhân Viên"))
                {
                    btnAddEmloyee.Visible = true;
                }

            }
        }

        public string LoadRole(int idEmloyee)
        {
            var roleNames = (from AccountEmloyeePermission in data.AccountEmloyeePermissions
                             join role in data.AccountEmloyeeRoles
                             on AccountEmloyeePermission.RoleID equals role.RoleID
                             where AccountEmloyeePermission.EmloyeeID == idEmloyee
                             select role.RoleName).ToList();

            return string.Join(", ", roleNames);
        }

        public string LoadStatus(bool status)
        {
            if(status == true)
            {
                return "Đang Online";
            } else
            {
                return "Offline";
            }
        }

        private void LoadPage(int page)
        {
            var emloyee = data.Emloyees.OrderByDescending(p => p.emloyee_id).ToList();
            rptEmloyeeList.DataSource = emloyee;
            rptEmloyeeList.DataBind();
        }

        protected void btnAddEmloyee_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Function/AddEmloyee.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.CommandArgument;
            Response.Redirect("./Function/UpdateEmloyee.aspx?id=" + id);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.CommandArgument;
            Response.Redirect("./Function/DeleteEmloyee.aspx?id=" + id);
        }

        protected void rptEmloyeeList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var roles = Session["Roles"] as List<string>;
                if (roles != null)
                {
                    var btnUpdate = (Button)e.Item.FindControl("btnUpdate");
                    var btnDelete = (Button)e.Item.FindControl("btnDelete");

                    if (btnUpdate != null)
                        btnUpdate.Visible = roles.Contains("Sửa Tài Khoản Nhân Viên");

                    if (btnDelete != null)
                        btnDelete.Visible = roles.Contains("Xóa Tài Khoản Nhân Viên");
                }
            }
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {

        }
    }
}