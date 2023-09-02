using System;
using System.Windows.Forms;
using GraphClasses;

namespace GraphCalcuculator
{
    public partial class GraphCalcOForm : Form
    {
        protected GraphCalcMForm parent;

        public GraphCalcOForm(GraphCalcMForm parent, string windowName,string output, bool changeable)
        {
            InitializeComponent();
            this.parent = parent;
            this.Text = windowName;
            TBox_Output.Enabled = changeable;
            But_Save_Changes.Enabled = changeable;
            But_Save_Changes.Visible = changeable;
            TBox_Output.Text = output;
        }

        private void But_Save_Changes_Click(object sender, EventArgs e)
        {
            try
            {
                Graph newGraph = new Graph(TBox_Output.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries));
                if (StaticElements.MBoxNewGraphRefuse()) return;
                parent.curGraph = newGraph;
                parent.Refresh_Vertices();
            }
            catch (Exception ex) { StaticElements.MBoxGraphCreationFailed(ex.Message); }
        }
    }
}
