using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WikiForum
{
    public partial class PublicWiki : System.Web.UI.Page
    {
        WikiDataContext wiki = new WikiDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                IEnumerable<WikiTable> query = from row in wiki.WikiTables
                                               select row;
                foreach (WikiTable w in query)
                {
                    ListItem list = new ListItem();
                    list.Value = w.WikiTitle;
                    if (!DropDownList1.Items.Contains(list))
                    {
                        DropDownList1.Items.Add(w.WikiTitle);
                    }
                }
            }
            catch (Exception)
            { }

        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text == "")
            {

            }

            else if (TextBox2.Text != "")
            {

            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            try
            {


                IEnumerable<WikiTable> query = from row in wiki.WikiTables
                                               select row;
                foreach (WikiTable w in query)
                {
                    if (w.WikiTitle == DropDownList1.Text)
                    {
                        TextBox1.Text = w.Comments;
                    }
                }
            }
            catch
            {
            }
        }
    }
}