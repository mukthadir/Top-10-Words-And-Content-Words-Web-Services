using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var client = new ServiceReferenceTop10Words.Service1Client();

        try
        {
            if (!String.IsNullOrWhiteSpace(TextBox1.Text))
            {
                var result = client.Top10Words(TextBox1.Text);
                TextBox2.Text = String.Join("\n", result);
            }
            client.Close();
        }
        catch (Exception ex)
        {
            TextBox2.Text = ex.Message;
            client.Abort();
        }
    }
}