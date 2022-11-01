using System;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace Voluntari.Models
{
    public class Request
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> RequiredSkills { get; set; }
        public string Address { get; set; }
        public StatusKind Status { get; set; }
    }

    public enum StatusKind
    {
        Asteptare,
        Refuzat,
        Acceptat,
        Finalizat
    }
}
