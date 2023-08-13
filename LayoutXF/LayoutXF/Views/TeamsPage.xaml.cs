using LayoutXF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LayoutXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamsPage : ContentPage
    {
        public TeamsPage()
        {
            InitializeComponent();
            UpdateSelectionData(Enumerable.Empty<Team>(), Enumerable.Empty<Team>());

        }

        private void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectionData(e.PreviousSelection, e.CurrentSelection);
        }

        private void UpdateSelectionData(IEnumerable<object> previousSelectedItems, IEnumerable<object> currentSelectedItems)
        {
            string lastItem = (previousSelectedItems.FirstOrDefault() as Team)?.Name;
            string currentItem = (currentSelectedItems.FirstOrDefault() as Team)?.Name;

            previousSelectedItemLabel.Text = string.IsNullOrEmpty(lastItem) ? "[none]" : lastItem;
            currenSelectedItemLabel.Text = string.IsNullOrEmpty(currentItem) ? "[none]" : currentItem;
        }
    }
}
