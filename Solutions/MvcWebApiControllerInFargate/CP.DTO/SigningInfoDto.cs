﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class SigningInfoDto
    {
        public string EnvelopeId { get; set; }
        public List<SigningRecipientDto> SigningRecipientCollection { get; set; }
    }
}
