﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GetKTVResponse
    {
        public GetKTVResponse(Domain.Entities.KTV KTV)
        {
            KTVId = KTV.KtvId;
            UserId = KTV.UserId ;
            Fullname = KTV.UserldNavigation?.Fullname;
        }

        public int KTVId { get; set; }
        public int UserId { get; set; }
        public string Fullname { get; set; }
    }
}
