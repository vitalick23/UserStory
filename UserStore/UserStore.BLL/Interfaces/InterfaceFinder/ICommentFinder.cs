﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStore.BLL.Entities;

namespace UserStore.BLL.Interfaces.InterfaceFinder
{
    public interface ICommentFinder : IFinder
    {
        List<Comment> GetCommentByIdStory(int storyId);
    }
}
