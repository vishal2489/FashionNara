﻿using System.Collections.Generic;
using Tailoring.Models;

namespace Tailoring.Web.Models {
    public class UserSizeSlection: ProductSizeType {
        public UserSizeSlection() {
            ProductOptions = new List<ProductOption>();
        }
        public List<ProductOption> ProductOptions { get; set; }
    }
}