using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voluntari.Models;

namespace Voluntari.Services
{
    public class MockDataStore : IDataStore<Request>
    {
        readonly List<Request> items;
        readonly List<Category> categories;

        public MockDataStore()
        {
            items = new List<Request>()
            {
                new Request {
                    Title = "Cumpărături pentru vârstnici",
                    Description = "Este nevoie de o persoana sa faca cumparaturi pentru o persoana batrana la 10 kilometri de Suceava. Este necesara masina pentru deplasarea in-afara orasului. Lista de cumparaturi va fi distribuita ulterior.",
                    Address = "Str. Abc, Nr. 144",
                    Status = StatusKind.Asteptare
                },
                new Request { 
                    Title = "O masă caldă",
                    Description = "Actiunea de Joi seara implica pregatirea cinei pentru oamenii strazii. Se cauta doi voluntari pentru pregatirea a doua feluri de mancare.",
                    Address = "Str. Abc, Nr. 144",
                    Status = StatusKind.Refuzat
                },
                new Request {
                    Title = "Am nevoie de insulină",
                    Description = "Am nevoie de un voluntar care să ajute cu un transport de medicamente",
                    Address = "Str. Abc, Nr. 144",
                    Status = StatusKind.Acceptat
                },
                new Request {
                    Title = "Nevoie de medic",
                    Description = "Cautam medic de familie disponibil sa efectueze consultatie la domiciliu unui copil de 8 ani cu ambele picioare rupte, in cartierul Burdujeni.",
                    Address = "Str. Abc, Nr. 144",
                    Status = StatusKind.Finalizat
                },
            };
            categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Cumparaturi",
                    Image = "alimente.png",
                    Template = new Request()
                    {
                        Description = "Am nevoie de o persoană care să ajute cu cumpărături",
                        RequiredSkills = new List<string>
                        {
                            "Timp liber",
                            "Masina"
                        }
                    }
                },
                new Category()
                {
                    Name = "Medical",
                    Image = "medical.png",
                    Template = new Request()
                    {
                        Description = "Am nevoie de ajutor medical",
                        RequiredSkills = new List<string>
                        {
                            "Medical"
                        }
                    }
                },
                new Category()
                {
                    Name = "Masa calda",
                    Image = "hotmeal.png",
                    Template = new Request()
                    {
                        Description = "Am nevoie de o masa calda",
                        RequiredSkills = new List<string>
                        {
                            "Gatit"
                        }
                    }
                },
                new Category()
                {
                    Name = "Pastile",
                    Image = "pastile.png",
                    Template = new Request()
                    {
                        Description = "Am nevoie de o persoană care să ajute cu transport de medicamente",
                        RequiredSkills = new List<string>
                        {
                            "Medical"
                        }
                    }
                   
                },
                new Category()
                {
                    Name = "Altceva",
                    Image = "altceva.png",
                    Template = new Request()
                    {
                    }
                },
            };
        }

        public async Task<bool> AddItemAsync(Request item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }


        public async Task<IEnumerable<Request>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await Task.FromResult(categories);
        }

        public async Task<bool> FinishRequestAsync(Request item)
        {
            var tofinish = items.Where(x => x.Title == item.Title).FirstOrDefault();

            tofinish.Status = StatusKind.Finalizat;
            return await Task.FromResult(true);
        }
    }
}