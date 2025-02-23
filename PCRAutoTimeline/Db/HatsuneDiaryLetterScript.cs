﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PCRApi.Models.Db
{
    public partial class HatsuneDiaryLetterScript
    {
        public long Id { get; set; }
        public long DiaryId { get; set; }
        public long SeqNum { get; set; }
        public long Type { get; set; }
        public long LineNum { get; set; }
        public long StartPos { get; set; }
        public long EndPos { get; set; }
        public double SeekTime { get; set; }
        public string SheetName { get; set; }
        public string CueName { get; set; }
        public long Command { get; set; }
        public double CommandParam { get; set; }
    }
}
