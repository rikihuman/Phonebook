using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Phonebook.Business;
using Phonebook.Model;


public partial class pb : Page
{
    private Collection<Phonebook.Model.Contact> contacts
    {
        get
        {
            if (Session["contacts"] == null)
                Session["contacts"] = new Collection<Phonebook.Model.Contact>();
            return (Collection<Phonebook.Model.Contact>)Session["contacts"];
        }
        set { Session["contacts"] = value; }
    }

    private Phonebook.Model.Contact contactdeat
    {
        get
        {
            if (Session["contact"] == null)
                Session["contact"] = new Phonebook.Model.Contact();
            return (Phonebook.Model.Contact)Session["contact"];
        }
        set { Session["contact"] = value; }
    }

    private Collection<Phonebook.Model.ContactNumber> contactNumbers
    {
        get
        {
            if (Session["contactNumbers"] == null)
                Session["contactNumbers"] = new Collection<Phonebook.Model.ContactNumber>();
            return (Collection<Phonebook.Model.ContactNumber>)Session["contactNumbers"];
        }
        set { Session["contactNumbers"] = value; }
    }

    private Phonebook.Model.ContactNumber contactNumber
    {
        get
        {
            if (Session["contactNumber"] == null)
                Session["contactNumber"] = new Phonebook.Model.ContactNumber();
            return (Phonebook.Model.ContactNumber)Session["contactNumber"];
        }
        set { Session["contactNumber"] = value; }
    }

    private Collection<Phonebook.Model.Relationship> relationships
    {
        get
        {
            if (Session["relationships"] == null)
                Session["relationships"] = new Collection<Phonebook.Model.Relationship>();
            return (Collection<Phonebook.Model.Relationship>)Session["relationships"];
        }
        set { Session["relationships"] = value; }
    }

    private Collection<Phonebook.Model.NumberType> numberTypes
    {
        get
        {
            if (Session["numberTypes"] == null)
                Session["numberTypes"] = new Collection<Phonebook.Model.NumberType>();
            return (Collection<Phonebook.Model.NumberType>)Session["numberTypes"];
        }
        set { Session["numberTypes"] = value; }
    }

    private int contactID
    {
        get
        {
            if (Session["contactID"] == null)
                Session["contactID"] = new int();
            return (int)Session["contactID"];
        }
        set { Session["contactID"] = value; }
    }
    private int contactNumberID
    {
        get
        {
            if (Session["contactNumberID"] == null)
                Session["contactNumberID"] = new int();
            return (int)Session["contactNumberID"];
        }
        set { Session["contactNumberID"] = value; }
    }

    private int editingIndex
    {
        get
        {
            if (Session["editingIndex"] == null)
                Session["editingIndex"] = new int();
            return (int)Session["editingIndex"];
        }
        set { Session["editingIndex"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            relationships = Controller.tRules.exGetRelationships();
            ddlRelationship.DataValueField = "RelationshipID";
            ddlRelationship.DataTextField = "RelationshipName";
            ddlRelationship.DataSource = relationships;
            ddlRelationship.DataBind();

            numberTypes = Controller.tRules.exGetNumberTypes();
            ddlNumberType.DataValueField = "NumberTypeID";
            ddlNumberType.DataTextField = "NumberName";
            ddlNumberType.DataSource = numberTypes;
            ddlNumberType.DataBind();

            getcontacts();
        }
    }

    protected void getcontacts()
    {
        txtContactSurname.Text = "";
        txtName.Text = "";
        txtNumber.Text = "";
        ddlNumberType.SelectedIndex = 0;
        ddlRelationship.SelectedIndex = 0;

        pnlContacts.Visible = false;
        contacts = Controller.tRules.exGetContacts();
        if (contacts.Count != 0)
        {
            gvContacts.DataSource = contacts.Where(c => c.Deleted == false);
            gvContacts.DataBind();
        }
        contactNumbers = Controller.tRules.exGetContactNumbers();
    }
    protected void gvContacts_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            contactID = Int32.Parse(gvContacts.DataKeys[e.RowIndex].Values["ContactID"].ToString());
            contactNumberID = Int32.Parse(gvContacts.DataKeys[e.RowIndex].Values["ContactNumberID"].ToString());

            contactdeat = contacts.Where(c => c.ContactID== contactID).First();
            contactdeat.Deleted = true;
            contactdeat.DateModified = DateTime.Now;

            contactNumber = contactNumbers.Where(c => c.ContactID == contactID && c.ContactNumberID == contactNumberID).First();
            Controller.tRules.exSaveContacts(contactdeat, contactNumber);
            getcontacts();
            Type cstype = this.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = Page.ClientScript;

            // Check to see if the startup script is already registered.
            if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
            {
                String cstext = "alert('Deleted');";
                cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
            }
            //ASPxPopupControlDeleteQuestion.ShowOnPageLoad = true;
        }
        catch (Exception ex)
        {
            
            //Controller.testRules.exUpdateErrorLog(el);
        }
    }

    protected void gvContacts_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }

    protected void gvContacts_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //editingIndex = e.NewEditIndex
        gvContacts.EditIndex = -1;
        contactID = Int32.Parse(gvContacts.DataKeys[e.NewEditIndex].Values["ContactID"].ToString());
        contactNumberID = Int32.Parse(gvContacts.DataKeys[e.NewEditIndex].Values["ContactNumberID"].ToString());

        gvContacts.Visible = false;
        lbNew.Visible = false;
        txtFind.Visible = false;
        pnlContacts.Visible = true;
        contactdeat = new Phonebook.Model.Contact();
        contactdeat = contacts.Where(c => c.ContactID == contactID).First();

        contactNumber = contactNumbers.Where(c => c.ContactID == contactID && c.ContactNumberID == contactNumberID).First();

        txtName.Text = contactdeat.ContactName;
        txtContactSurname.Text = contactdeat.ContactSurname;
        txtNumber.Text = contactNumber.Number;
        ddlNumberType.SelectedIndex = ddlNumberType.Items.IndexOf(ddlNumberType.Items.FindByValue(contactNumber.NumberType.ToString()));
        ddlRelationship.SelectedIndex = ddlRelationship.Items.IndexOf(ddlRelationship.Items.FindByValue(contactdeat.Relationship.ToString()));

    }

    protected void gvContacts_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void gvContacts_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvContacts_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }

    protected void gvContacts_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            Type cstype = this.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = Page.ClientScript;
            //contactID = 0;
            //contactNumberID = 0;

            //if (ddlNumberType.SelectedItem.Text.ToUpper() != "EMAIL")
            //{
            //    if (!txtNumber.Text.ToString().All(Char.IsDigit))
            //    {


            //        // Check to see if the startup script is already registered.
            //        if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
            //        {
            //            String cstext = "alert('Please enter a valid phone number');";
            //            cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);

            //        }
            //        return;
            //    }
            //    else {
            //        if (!txtNumber.Text.Contains("@") && !txtNumber.Text.Contains("."))
            //        {
            //            if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
            //            {
            //                String cstext = "alert('Please enter a valid phone number');";
            //                cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);

            //            }
            //            return;
            //        }
            //    }
            //}
            //else {
                
            //}
            contactdeat = new Phonebook.Model.Contact();
            contactdeat.ContactID = contactID;
            contactdeat.ContactName = txtName.Text.Trim().ToString();
            contactdeat.ContactSurname = txtContactSurname.Text.Trim().ToString();
            contactdeat.Relationship = Int32.Parse(ddlRelationship.SelectedValue);
            contactdeat.Deleted = false;
            contactNumber = new Phonebook.Model.ContactNumber();
            contactNumber.ContactID = contactID;
            contactNumber.ContactNumberID = contactNumberID;
            contactNumber.NumberType = Int32.Parse(ddlNumberType.SelectedValue);
            contactNumber.Number = txtNumber.Text.Trim().ToString();
                contactNumber.Deleted = false;
            Controller.tRules.exSaveContacts(contactdeat, contactNumber);
            getcontacts();
            //Type cstype = this.GetType();

            //// Get a ClientScriptManager reference from the Page class.
            //ClientScriptManager cs = Page.ClientScript;

            // Check to see if the startup script is already registered.
            if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
            {
                String cstext = "alert('Saved');";
                cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                
            }
            gvContacts.Visible = true;
            lbNew.Visible = true;
            lbFind.Visible = true;
            txtFind.Visible = true;
            pnlContacts.Visible = false;
            //ASPxPopupControlDeleteQuestion.ShowOnPageLoad = true;
        }
        catch (Exception ex)
        {

            //Controller.testRules.exUpdateErrorLog(el);
        }
    }

    
    protected void ddlNumberType_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblNumType.Text = ddlNumberType.SelectedItem.Text;
    }

    protected void lbNew_Click(object sender, EventArgs e)
    {
        pnlContacts.Visible = true;
        lblContact.Text = "New Contact";
        gvContacts.Visible = false;
        lbNew.Visible = false;
        txtFind.Visible = false;
        lbFind.Visible = false;
        contactID = 0;
        contactNumberID = 0;
    }

    protected void lbFind_Click(object sender, EventArgs e)
    {

        gvContacts.DataSource = contacts.Where(c => (c.ContactName.ToUpper().Contains(txtFind.Text.Trim().ToUpper().ToString()) || c.ContactSurname.ToUpper().Contains(txtFind.Text.Trim().ToUpper().ToString())) && c.Deleted == false);
        gvContacts.DataBind();
        if (gvContacts.Rows.Count == 0)
        {
            Type cstype = this.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = Page.ClientScript;

            // Check to see if the startup script is already registered.
            if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
            {
                String cstext = "alert('No such contact');";
                cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
            }
        }
    }

    protected void lbUpdate_Click(object sender, EventArgs e)
    {
        try {
            lblContact.Text = "Update Contact";
            var argument = ((LinkButton)sender).CommandArgument;
            contactID = Int32.Parse(argument);
            pnlContacts.Visible = true;
            gvContacts.Visible = false;
            lbNew.Visible = false;
            lbFind.Visible = false;
            txtFind.Visible = false;

            contactdeat = new Phonebook.Model.Contact();
            contactdeat = contacts.Where(c => c.ContactID == contactID).First();

            contactNumber = contactNumbers.Where(c => c.ContactID == contactID).First();

            txtName.Text = contactdeat.ContactName;
            txtContactSurname.Text = contactdeat.ContactSurname;
            txtNumber.Text = contactNumber.Number;
            ddlNumberType.SelectedIndex = ddlNumberType.Items.IndexOf(ddlNumberType.Items.FindByValue(contactNumber.NumberType.ToString()));
            ddlRelationship.SelectedIndex = ddlRelationship.Items.IndexOf(ddlRelationship.Items.FindByValue(contactdeat.Relationship.ToString()));

        }
        catch (Exception ex)
        {

            //Controller.testRules.exUpdateErrorLog(el);
        }
    }

    protected void lbCancel_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
        txtContactSurname.Text = "";
        txtNumber.Text = "";
        ddlNumberType.SelectedIndex = 0;
        ddlRelationship.SelectedIndex = 0;

        pnlContacts.Visible = false;
        gvContacts.Visible = true;
        lbNew.Visible = true;
        lbFind.Visible = true;
        txtFind.Visible = true;
    }
}