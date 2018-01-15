using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AnimesTest.Models;

namespace AnimesTest.Controllers
{
    public class AnimeController : ApiController
    {
        // GET: api/Anime
        public IEnumerable<Anime> Get()
        {
            Anime anime = new Anime();

            return anime.index();
        }

        // GET: api/Anime/5
        public Anime Get(int id)
        {
            Anime anime = new Anime();

            return anime.index().Where(x => x.id == id).FirstOrDefault();
        }

        // POST: api/Anime
        public Anime Post(Anime anime)
        {
            Anime _anime = new Anime();

            return _anime.Store(anime);
        }

        // PUT: api/Anime/5
        public Anime Put(int id, [FromBody]Anime anime)
        {
            Anime _anime = new Anime();

            return _anime.Update(id, anime);
        }

        // DELETE: api/Anime/5
        public bool Delete(int id)
        {
            Anime _anime = new Anime();

            return _anime.Destroy(id);
        }
    }
}
