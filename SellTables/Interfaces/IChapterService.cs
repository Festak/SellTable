﻿using SellTables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellTables.Interfaces
{
    public interface IChapterService
    {
        Chapter GetChapter(int id);
        void UpdateChapterPos(int oldPosition, int newPosition, int fromChapterId, int toChapterId);
    }
}