﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PCRApi.Models.Db
{
    public partial class KmkNaviComment
    {
        public long CommentId { get; set; }
        public long WhereType { get; set; }
        public long CharacterId { get; set; }
        public long FaceType { get; set; }
        public string CharacterName { get; set; }
        public string Description { get; set; }
        public long VoiceId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double ChangeFaceTime { get; set; }
        public long ChangeFaceType { get; set; }
        public long EventId { get; set; }
    }
}
