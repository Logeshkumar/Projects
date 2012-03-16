using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Wiki
{
    public partial class WikiForum : System.Web.UI.Page
    {
        WikiDataContext ent = new WikiDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<WikiTable> query = from q in ent.WikiTables
                                           select q;
            foreach (WikiTable row in query)
            {
                ListItem list = new ListItem();
                list.Value = row.WikiTitle;
                if (!DropDownList1.Items.Contains(list))
                {
                    DropDownList1.Items.Add(row.WikiTitle);
                }
            }

            
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}