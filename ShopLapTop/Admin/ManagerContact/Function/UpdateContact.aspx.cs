using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerContact.Function
{
    public partial class UpdateContact : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"]);
                LoadContact(id);
            }
        }

        public void LoadContact(int id)
        {
            var contact = data.Contacts.SingleOrDefault(p => p.ContactID == id);
            txtAddress.Text = contact.Address;
            txtPhone.Text = contact.Phone;
            txtEmail.Text = contact.Email;
        }

        private bool UpdateContacts(int id, string address, string phone, string email)
        {
            
            var Contact = data.Contacts.SingleOrDefault(p => p.ContactID == id);
            if(Contact != null)
            {
                Contact.Address = address;
                Contact.Phone = phone;
                Contact.Email = email;
                data.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
                
            
        }
        protected void btnUpdateContact_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtAddress.Text) || !string.IsNullOrWhiteSpace(txtPhone.Text) || !string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                int id = int.Parse(Request.QueryString["id"]);
                if (UpdateContacts(id, txtAddress.Text, txtPhone.Text, txtEmail.Text))
                {
                    lblMessage.Text = "Dữ liệu đã được cập nhật thành công!";
                }
                else
                {
                    lblMessage.Text = "Lỗi khi cập nhật dữ liệu!";
                }
            }
        }

        protected void btnHomeContact_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomeContact.aspx");
        }
    }
}