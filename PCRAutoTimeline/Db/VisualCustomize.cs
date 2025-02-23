﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PCRApi.Models.Db
{
    public partial class VisualCustomize
    {
        public long Id { get; set; }
        public long TitlePrefab { get; set; }
        public long TitleMovie { get; set; }
        public long TitleVoice { get; set; }
        public long StoryTopMovie { get; set; }
        public long QuestTopMovie { get; set; }
        public long ProfileLogo { get; set; }
        public long WatchedStoryId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
