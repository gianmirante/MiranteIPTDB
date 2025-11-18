using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiranteCIPT101Solution.MiranteFramework.Models;

namespace MiranteCIPT101Solution.MiranteFramework.Commands
{
    public interface ICreateYouTubeViewerCommand
    {
        Task Execute(YouTubeViewer youTubeViewer);
    }
}
