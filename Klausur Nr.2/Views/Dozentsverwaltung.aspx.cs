using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Klausur_Nr._2.Views
{
    public partial class Dozentsverwaltung1 : System.Web.UI.Page
    {
        private Controller _verwalter;

        public Controller Verwalter { get => _verwalter; set => _verwalter = value; }
        public Dozentsverwaltung1()
        {
            Verwalter = Global.Verwalter;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Verwalter.LoadAlleDatenFromAPI();

            Data_load();
            Button2.Visible = false;
            Button1.Visible = true;
        }
        static int BearbeitundID;
        public void Data_load()
        {
            for (int index = 0; index < Verwalter.List.Count; index++)
            {
                
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = Verwalter.List[index].ID.ToString();
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = Verwalter.List[index].Name;
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = Verwalter.List[index].Fach;
                row.Cells.Add(cell);
                Table1.Rows.Add(row);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Verwalter.addPerson(TextBox1.Text, TextBox2.Text);
            Response.Redirect("Dozentsverwaltung.aspx");
        }



        protected void Button4_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < Verwalter.List.Count; index++)
            {
                if (Verwalter.List[index].ID.ToString() == TextBox4.Text)
                {
                    TextBox1.Text = Verwalter.List[index].Name;
                    TextBox2.Text = Verwalter.List[index].Fach;
                    Button1.Visible = false;
                    Button2.Visible = true;
                    BearbeitundID = Convert.ToInt32(TextBox4.Text);


                }
                else
                {

                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Verwalter.loeschen(TextBox3.Text);
            Response.Redirect("Dozentsverwaltung.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Verwalter.bearbeiten(BearbeitundID, TextBox1.Text, TextBox2.Text);
            Response.Redirect("Dozentsverwaltung.aspx");

        }
    }
}