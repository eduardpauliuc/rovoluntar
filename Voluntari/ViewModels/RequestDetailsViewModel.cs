using System;

using Voluntari.Models;

namespace Voluntari.ViewModels
{
    public class RequestDetailsViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public RequestDetailsViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
