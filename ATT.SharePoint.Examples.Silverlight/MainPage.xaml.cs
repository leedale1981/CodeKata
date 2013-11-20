using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ATT.SharePoint.Examples.Silverlight.ATT.SharePoint.Examples.Silverlight;
using System.Data.Services.Client;

namespace ATT.SharePoint.Examples.Silverlight
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the GetDataButton. 
        /// Uses the SharePoint REST service to returns results.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetDataButton_Click(object sender, RoutedEventArgs e)
        {
            string siteUrl = "http://centrica.dev.athousandthreads.com/";
            MyMIDataContext context = new MyMIDataContext(new Uri(siteUrl));

            DataServiceQuery<MasterListItem> masterListItemsQuery = 
                context.MasterList as DataServiceQuery<MasterListItem>;

            masterListItemsQuery.BeginExecute(
                (IAsyncResult asyncResult) => Dispatcher.BeginInvoke(() =>
                    {
                        DataListBox.ItemsSource = masterListItemsQuery.EndExecute(asyncResult);

                    }), masterListItemsQuery
                );
        }
    }
}
