﻿using System.Linq;
using System.Web.Mvc;

namespace Sitecore.Feature.Events.Controllers
{
    using System.Globalization;
    using Sitecore.Data;
    using Sitecore.Feature.Events.Models;
    using Sitecore.Feature.Events.Repositories;
    using Sitecore.Shell.Applications.ContentEditor;

    public class EventsApiController : Controller
    {
        [HttpGet]
        public ActionResult GetCalendarEventsJson(string id)
        {
            ID eventListId;
            if (!ID.TryParse(id, out eventListId))
            {
                //throw new Exception("Invalid event list id");
                return new EmptyResult();
            }

            //get event list item
            var eventListItem = Sitecore.Context.Database.GetItem(eventListId);
            if (eventListItem == null)
            {
                return new EmptyResult();
            }

            //set context item
            Context.Item = eventListItem;

            //initialize event repository
            var eventRepository = new EventRepository(eventListItem);
            var events = eventRepository.Get().Select(c => new EventModel(c) as EventHeaderModel);
                
            return Json(events.Where(e=>e.StartDate.HasValue).Select(c => 
            new { title = c.Title,
                startsAtTxt = c.StartDate?.ToUniversalTime().ToString(CultureInfo.InvariantCulture) ?? "",
                endsAtTxt = c.EndDate?.ToUniversalTime().ToString(CultureInfo.InvariantCulture) ?? "",
                description = c.Description,
                location=c.Location,
              //  image=c.Image
                
            }).ToArray(), JsonRequestBehavior.AllowGet);

        }
    }
}