﻿namespace CurrencyExchange.Application.Dtos
{
    public class RegistureDto
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
