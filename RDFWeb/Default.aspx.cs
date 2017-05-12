using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDFWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DemoModel.DemoEntities svc = new DemoModel.DemoEntities(new Uri("http://localhost:50276/DemoService.svc"));

            var query = svc.Customers;
            Table iriTable = new Table();
            this.Controls.Add(iriTable);

            foreach (DemoModel.Customers sv in query)
            {
                TableRow tRow = new TableRow();
                iriTable.Rows.Add(tRow);
                TableCell tCell = new TableCell();
                tRow.Cells.Add(tCell);
                HyperLink h = new HyperLink();
                h.Text = sv.ContactName;
                h.NavigateUrl = sv.Country;
                tCell.Controls.Add(h);
            }
        }
    }
}
