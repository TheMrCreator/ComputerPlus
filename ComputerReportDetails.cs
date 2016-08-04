using ComputerPlus.API;
using ComputerPlus.Extensions;
using System;
using System.Threading;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Rage;
using Rage.Forms;
using Gwen.Control;
using LSPD_First_Response.Engine.Scripting.Entities;
using LSPD_First_Response.Mod.API;

namespace ComputerPlus
{
    internal class ComputerReportDetails : GwenForm
    {
        private ListBox list_reports;
        private Label lbl_report_title, lbl_status, lbl_notes;
        private MultilineTextBox box_info, box_notes;
        private Base base_intialize, base_selected;

        public ComputerReportDetails() : base(typeof(ComputerReportDetailsTemplate))
        {

        }

        public override void InitializeLayout()
        {
            base.InitializeLayout();
            InitializeScreen();
            // Reports listbox
            list_reports = new ListBox(base_intialize);
            list_reports.SetPosition(12, 11);
            list_reports.SetSize(124, 417);
            this.Position = new Point(Game.Resolution.Width / 2 - this.Window.Width / 2, Game.Resolution.Height / 2 - this.Window.Height / 2);
            this.Window.DisableResizing();
            list_reports.RowSelected += listBox1_SelectedIndexChanged;
            FillCallDetails();
        }

        private void InitializeScreen()
        {
            // Report Title label
            lbl_report_title = new Label(base_selected);
            lbl_report_title.Text = "Unit";
            lbl_report_title.SetPosition(142, 11);

            // Status label
            lbl_status = new Label(base_selected);
            lbl_status.Text = "Status: ";
            lbl_status.SetPosition(142, 33);
            lbl_status.TextColor = Color.Black;

            // Notes label
            lbl_notes = new Label(base_selected);
            lbl_notes.Text = "Officer Notes";
            lbl_notes.SetPosition(142, 240);

            // Information textbox
            box_info = new MultilineTextBox(base_selected);
            box_info.SetPosition(142, 53);
            box_info.SetSize(496, 169);
            box_info.KeyboardInputEnabled = false;

            // Notes textbox
            box_notes = new MultilineTextBox(base_selected);
            box_notes.SetPosition(142, 260);
            box_notes.SetSize(496, 133);
            box_notes.KeyboardInputEnabled = true;

            lbl_report_title.Hide();
            lbl_status.Hide();
            lbl_notes.Hide();
            box_info.Hide();
            box_notes.Hide();
        }

        internal void FillCallDetails()
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Get the currently selected item in the ListBox.
            string currentitem = list_reports.SelectedRow.ToString().ToLower();
            if (currentitem == ExternalReports.ExternalReportData)

        }

        #region Properties

        internal string StatusText
        {
            get
            {
                return lbl_status.Text;
            }
            set
            {
                lbl_status.Text = value;
                //out_desc.Text = out_desc.Text.Replace(Environment.NewLine, "");
                //out_desc.WordWrap(450);
            }
        }

        internal string TitleText
        {
            get
            {
                return lbl_report_title.Text;
            }
            set
            {
                lbl_report_title.Text = value.WordWrap(400, lbl_report_title.Font.FaceName.ToString());
                //out_peds.Text = out_peds.Text.Replace(Environment.NewLine, "");
                //out_peds;
            }
        }

        internal string NotesText
        {
            get
            {
                return box_notes.Text;
            }
            set
            {
                box_notes.Text = value.WordWrap(400, box_notes.Font.FaceName.ToString());
                //out_vehs.Text = out_vehs.Text.Replace(Environment.NewLine, "");
                //out_vehs.WordWrap(350);
            }
        }

        internal string InfoText
        {
            get
            {
                return box_info.Text;
            }
            set
            {
                box_info.Text = value.WordWrap(400, box_info.Font.FaceName.ToString());
                //out_vehs.Text = out_vehs.Text.Replace(Environment.NewLine, "");
                //out_vehs.WordWrap(350);
            }
        }

#endregion
    }
}