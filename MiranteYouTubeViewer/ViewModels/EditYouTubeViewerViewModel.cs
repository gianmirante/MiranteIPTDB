using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MiranteCIPT101Solution.MiranteYouTubeViewer.Commands;
using MiranteCIPT101Solution.MiranteFramework.Models;
using MiranteCIPT101Solution.MiranteYouTubeViewer.Stores;

namespace MiranteCIPT101Solution.MiranteYouTubeViewer.ViewModels
{
    public class EditYouTubeViewerViewModel : ViewModelBase
    {
        public Guid YouTubeViewerId { get; }

        public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; }

        public EditYouTubeViewerViewModel(YouTubeViewer youTubeViewer, YouTubeViewersStore youTubeViewersStore, ModalNavigationStore modalNavigationStore)
        {
            YouTubeViewerId = youTubeViewer.Id;

            ICommand submitCommand = new EditYouTubeViewerCommand(this, youTubeViewersStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel(submitCommand, cancelCommand)
            { 
                Username = youTubeViewer.Username,
                IsSubscribed = youTubeViewer.IsSubscribed,
                IsMember = youTubeViewer.IsMember,
            };
        }
    }
}
