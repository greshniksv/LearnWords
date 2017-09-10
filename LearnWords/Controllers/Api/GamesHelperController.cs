using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using LearnWords.Contexts;
using LearnWords.Extensions;
using LearnWords.Games;
using LearnWords.Models.Api;
using LearnWords.Models.Db;

namespace LearnWords.Controllers.Api
{
    public class GamesHelperController : ApiController
    {
        [System.Web.Http.HttpGet]
        public JsonResult<List<GameInfo>> GetList()
        {
            return Json(GamesHelper.ListInfos);
        }
    }
}