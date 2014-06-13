using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rescuetray
{
    class ListViewItemComparer
        : IComparer
    {
        public int _column;
        public int _ascending;

        public ListViewItemComparer(int column, int ascending)
        {
            _column = column;
            _ascending = ascending;
        }

        public int Compare(object a, object b)
        {
            var la = a as ListViewItem;
            var lb = b as ListViewItem;

            var at = la.SubItems[_column].Text;
            var bt = lb.SubItems[_column].Text;

            if (_ascending != 0)
            {
                var xt = at;
                at = bt;
                bt = xt;
            }

            return String.Compare(at, bt);
        }
    }

    public partial class MainForm : Form
    {
        public RescueDataManager _manager;

        public MainForm()
        {
            var key = "B637R0noLkettPV3rLL8vkdY5jQoJEsiOTM4icZ3";

            _manager = new RescueDataManager(key);

            InitializeComponent();
        }

        private void OnRefreshButton(object sender, EventArgs e)
        {
            _manager.Refresh();
            UpdateDataView();
        }

        private void UpdateDataView()
        {
            var lv = RescueDataListView;

            lv.Columns.Add("Rank");
            lv.Columns.Add("Category");
            lv.Columns.Add("Activity");
            lv.Columns.Add("Time");
            lv.Columns.Add("Productivity");

            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            foreach (var entry in _manager._data.rows)
            {
                var lvi = new ListViewItem(entry.Rank.ToString());
                var time = new TimeSpan(0, 0, entry.TimeSpentSeconds);

                lvi.SubItems.Add(entry.Category);
                lvi.SubItems.Add(entry.Activity);
                lvi.SubItems.Add(time.ToString("mm\\:ss\\.ff"));
                lvi.SubItems.Add(entry.Productivity.ToString());

                lv.Items.Add(lvi);
            }

            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lv.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);


            lv.Refresh();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void RescueDataListColumnClick(object sender, ColumnClickEventArgs e)
        {
            var lv = RescueDataListView;
            var existing = lv.ListViewItemSorter as ListViewItemComparer;
            var ascending = (existing != null && existing._column == e.Column && existing._ascending == 0) ? 1 : 0;
            var cmp = new ListViewItemComparer(e.Column, ascending);

            lv.Sorting = SortOrder.None;
            lv.ListViewItemSorter = cmp as IComparer;
            lv.Sort();
        }
    }
}
