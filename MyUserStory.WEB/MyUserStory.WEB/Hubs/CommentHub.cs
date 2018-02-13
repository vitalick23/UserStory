using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using MyUserStory.BLL.Interfaces.InterfaceService;
using MyUserStory.WEB.Models.Request;
using MyUserStory.WEB.Models.Response;

namespace MyUserStory.WEB.Hubs
{
    [HubName("comment")]
    public class CommentHub : Hub
    {
        
        public void SendToAll([FromBody]CommentHubModelRequst comment)
        {
            
            Clients.All.InvokeAsync(comment);
        }

        public void WhoPrint([FromBody]CommentHubModelRequst comment)
        {
            Clients.Others.Print(comment);
        }
    }

}       
