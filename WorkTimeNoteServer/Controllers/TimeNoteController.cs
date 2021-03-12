using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using WorkTimeNoteCommon;
using WorkTimeNoteCommon.ApiConsts;
using WorkTimeNoteCommon.ApiConsts.ActionNames;
using WorkTimeNoteCommon.WebApi;
using WorkTimeNoteCommon.WebApi.ResponseFactory.Contracts;
using WorkTimeNoteDomain.Entities;
using WorkTimeNoteServices.TimeNoteServices.Contracts;

namespace WorkTimeNoteServer.Controllers
{
    [ApiController]
    [Route(ApiSegments.TIME_NOTE)]
    public class TimeNoteController : WebApiControllerBase
    {
        private readonly ITimeNoteService _timeNoteService;

        public TimeNoteController(
            IResponseFactory responseFactory,
            ITimeNoteService timeNoteService)
            : base(responseFactory)
        {
            _timeNoteService = timeNoteService;
        }

        [HttpGet]
        [Route(TimeNoteActionNames.GET_ALL)]
        public async Task<IActionResult> GetAllAsync() =>
            Ok(SuccessResponseBody(await _timeNoteService.GetAll()));

        [HttpPost]
        [Route(TimeNoteActionNames.NEW)]
        public async Task<IActionResult> NewAsync(
            [FromBody] TimeNote timeNote)
        {
            try
            {
                return Ok(SuccessResponseBody(await _timeNoteService.New(timeNote), MessageConsts.SUCCESS_NEW_TIME_NOTE));
            }
            catch
            {
                return BadRequest(ErrorResponseBody(MessageConsts.ERROR_NEW_TIME_NOTE, HttpStatusCode.BadRequest));
            }
        }

        [HttpPost]
        [Route(TimeNoteActionNames.UPDATE)]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] TimeNote timeNote)
        {
            try
            {
                if (timeNote.IsNew())
                    return BadRequest(ErrorResponseBody(MessageConsts.ERROR_UPDATE_TIME_NOTE, HttpStatusCode.BadRequest));

                return Ok(SuccessResponseBody(await _timeNoteService.Update(timeNote), MessageConsts.SUCCESS_UPDATE_TIME_NOTE));
            }
            catch
            {
                return BadRequest(ErrorResponseBody(MessageConsts.ERROR_UPDATE_TIME_NOTE, HttpStatusCode.BadRequest));
            }
        }

        [HttpPost]
        [Route(TimeNoteActionNames.REMOVE)]
        public async Task<IActionResult> RemoveAsync(
            [FromQuery] Guid netId)
        {
            try
            {
                if (netId.Equals(Guid.Empty))
                    return BadRequest(ErrorResponseBody(MessageConsts.ERROR_REMOVE_TIME_NOTE, HttpStatusCode.BadRequest));

                return Ok(SuccessResponseBody(await _timeNoteService.Remove(netId), MessageConsts.SUCCESS_REMOVE_TIME_NOTE));
            }
            catch
            {
                return BadRequest(ErrorResponseBody(MessageConsts.ERROR_REMOVE_TIME_NOTE, HttpStatusCode.BadRequest));
            }
        }
    }
}
