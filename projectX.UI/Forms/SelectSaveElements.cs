using ProjectX.BLL;
using ProjectX.UI.Controls;
using SuperMap.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projectX.UI.Forms
{
    public partial class SelectSaveElements : Form
    {
        UserTabPage utpMap;
        List<string> MapXML;
        List<string> LayoutXML;
        public event EventHandler<SaveArgs> SaveElement;
        public event EventHandler SaveWorkspace;

        public SelectSaveElements(UserTabPage utpMap)
        {
            this.utpMap = utpMap;
            InitializeComponent();
            InitCheckBox();
        }

        private void InitCheckBox()
        {
            MapXML = new List<string>();
            LayoutXML = new List<string>();

            foreach (TabPage tabPage in utpMap.TabPages)
            {
                Control control = tabPage.Controls[0];
                if (control is MapControl)
                {
                    MapControl mapControl = (MapControl)control;
                    checkedListBoxMap.Items.Add(mapControl.Map.Name);
                    MapXML.Add(mapControl.Map.ToXML());
                }
                else if (control is MapLayoutControl)
                {
                    MapLayoutControl mapLayoutControl = (MapLayoutControl)control;
                    checkedListBoxLayout.Items.Add(mapLayoutControl.MapLayout.Name);
                    LayoutXML.Add(mapLayoutControl.MapLayout.ToXML());
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            foreach (int item in checkedListBoxMap.SelectedIndices)
            {
                SaveArgs saveArags = new SaveArgs((string)checkedListBoxMap.SelectedItems[item], MapXML[item],TabType.Map);
                SaveElement(sender,saveArags);
            }
            foreach (int item in checkedListBoxLayout.SelectedIndices)
            {
                SaveArgs saveArags = new SaveArgs((string)checkedListBoxLayout.SelectedItems[item], LayoutXML[item],TabType.Layout);
                SaveElement(sender, saveArags);
            }
            SaveWorkspace(sender, e);
            this.Close();
        }
    }
}
