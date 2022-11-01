using System;
using System.Collections.Generic;
using System.Text;
using Voluntari.Models;

namespace Voluntari.ViewModels
{
    public class CreateRequestViewModel : BaseViewModel
    {
        Request newRequest = new Request();
        public Request NewRequest
        {
            get => newRequest;
            set
            {
                SetProperty(ref newRequest, value);
            }
        }

        bool skill1;
        public bool Skill1
        {
            get => skill1;
            set => SetProperty(ref skill1, value);
        }

        bool skill2;
        public bool Skill2
        {
            get => skill2;
            set => SetProperty(ref skill2, value);
        }

        bool skill3;
        public bool Skill3
        {
            get => skill3;
            set => SetProperty(ref skill3, value);
        }

        bool skill4;
        public bool Skill4
        {
            get => skill4;
            set => SetProperty(ref skill4, value);
        }
        bool skill5;
        public bool Skill5
        {
            get => skill5;
            set => SetProperty(ref skill5, value);
        }
        bool skill6;
        public bool Skill6
        {
            get => skill6;
            set => SetProperty(ref skill6, value);
        }
        bool skill7;
        public bool Skill7
        {
            get => skill7;
            set => SetProperty(ref skill7, value);
        }
        bool skill8;
        public bool Skill8
        {
            get => skill8;
            set => SetProperty(ref skill8, value);
        }
        bool skill9;
        public bool Skill9
        {
            get => skill9;
            set => SetProperty(ref skill9, value);
        }

        public CreateRequestViewModel()
        {

        } 
        public CreateRequestViewModel(Request template) :this()
        {
            NewRequest = template;

            Skill1 = (template.RequiredSkills.Contains("Medical"));
            Skill2 = (template.RequiredSkills.Contains("Gatit"));
            Skill3 = (template.RequiredSkills.Contains("Construit"));
            Skill4 = (template.RequiredSkills.Contains("Timp liber"));
            Skill5 = (template.RequiredSkills.Contains("Organizator"));
            Skill6 = (template.RequiredSkills.Contains("It"));
            Skill7 = (template.RequiredSkills.Contains("Profesor"));
            Skill8 = (template.RequiredSkills.Contains("Masina"));
            Skill9 = (template.RequiredSkills.Contains("Frizer"));
        }
    }
}
