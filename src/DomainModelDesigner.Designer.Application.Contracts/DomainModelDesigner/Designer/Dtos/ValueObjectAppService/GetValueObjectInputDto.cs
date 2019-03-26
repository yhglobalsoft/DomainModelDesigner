﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace DomainModelDesigner.Designer.Dtos
{
    public class GetValueObjectInputDto: PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}