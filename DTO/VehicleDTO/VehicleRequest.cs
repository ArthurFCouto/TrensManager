﻿using TrensManager.Enums;

namespace TrensManager.DTO.VehicleDTO
{
    public class VehicleRequest
    {
        public required string Code { get; set; }
        public List<int>? TrainsId { get; set; }
        public required VehicleType Type { get; set; }
    }
}
