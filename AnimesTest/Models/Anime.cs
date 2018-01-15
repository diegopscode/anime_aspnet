using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace AnimesTest.Models
{
    public class Anime
    {
        public int id { get; set; }
        public string name { get; set; }
        public int episodes { get; set; }
        public object Request { get; private set; }

        private List<Anime> allAnimes;

        public Anime(int id, string name, int episodes)
        {
            this.id = id;
            this.name = name;
            this.episodes = episodes;
        }

        public Anime()
        {
            allAnimes = this.index();
        }

        public List<Anime> index()
        {
            var pathData = HostingEnvironment.MapPath(@"~/App_Data\Base.json");

            var json = File.ReadAllText(pathData);

            List<Anime> listAnimes = JsonConvert.DeserializeObject<List<Anime>>(json);

            return listAnimes;
        }

        public bool OverrideAnimes(List<Anime> listAnimes)
        {
            var pathData = HostingEnvironment.MapPath(@"~/App_Data\Base.json");

            var json = JsonConvert.SerializeObject(listAnimes, Formatting.Indented);
            File.WriteAllText(pathData, json);

            return true;
        }

        public Anime Store(Anime anime)
        {
            var maxId = allAnimes.Max(p => p.id);
            anime.id = maxId + 1;

            allAnimes.Add(anime);

            this.OverrideAnimes(allAnimes);

            return anime;
        }

        public Anime Update(int id, Anime anime)
        {
            var animeIndex = allAnimes.FindIndex(a => a.id == anime.id);

            if(animeIndex >= 0)
            {
                anime.id = id;
                allAnimes[animeIndex] = anime;
            }
            else
            {
                return null;
            }

            this.OverrideAnimes(allAnimes);

            return anime;
        }

        public bool Destroy(int id)
        {
            var animeIndex = allAnimes.FindIndex(a => a.id == id);

            if (animeIndex >= 0)
            {
                allAnimes.RemoveAt(animeIndex);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}